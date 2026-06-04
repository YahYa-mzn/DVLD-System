using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Global_Classes;
using DVLD_BLL;

namespace DVLD.Tests.TestAppointments
{
    public partial class frmTodaysTestAppointments : Form
    {
        string GetResultImage(bool Result) 
            => (Result) ? clsSettings.ImgTrue : clsSettings.ImgFalse;   

        void AddNewTestAppointmentToList(DataRow Row)
        {
            string IsLockedImage = Convert.ToBoolean(Row["IsLocked"])
                                   ? clsSettings.ImgLocked
                                   : clsSettings.ImgUnlocked;

            string Examiner = (Row["Examiner"] != null && !string.IsNullOrEmpty(Row["Examiner"].ToString()))
                              ? Row["Examiner"].ToString()
                              : "[Not assigned yet]";

            string ResultImage = (Row["TestResult"] != null && Row["TestResult"] != DBNull.Value)
                                 ? GetResultImage(Convert.ToBoolean(Row["TestResult"]))
                                 : clsSettings.ImgPending;
          
            DGVTodaysTestAppointments.Rows.Add(
                Row["TestAppointmentID"].ToString(),

                string.Empty, //Separator

                Row["NationalNo"].ToString(),
                clsUtility.GetFullName(Row["FirstName"].ToString(),
                                       Row["SecondName"].ToString(),
                                       Row["ThirdName"].ToString(),
                                       Row["LastName"].ToString()),

                string.Empty, //Separator

                Row["PaidFees"].ToString(),
                Image.FromFile(IsLockedImage),

                string.Empty, //Separator

                Examiner,       
                Image.FromFile(ResultImage)
            );
        }
        DataTable GetTodaysTestAppointmentsDataTable()
        {
            switch (CmbBoxReadMode.SelectedIndex)
            {
                case 0:
                    return clsTestAppointment.GetTodaysTestAppointmentsList();

                case 1:
                    return clsTestAppointment.GetTodaysTestAppointmentsList(true);

                case 2:
                    return clsTestAppointment.GetTodaysTestAppointmentsList(false);

                default:
                    return clsTestAppointment.GetTodaysTestAppointmentsList();
            }
        }

        // I just copied the code from chat gpt to make the UX more better
        async void RefreshTodaysTestAppointmentsList()
        {
            DGVTodaysTestAppointments.Rows.Clear();
            DataTable DTTodaysTestAppointments = GetTodaysTestAppointmentsDataTable(); // Get tests

            await Task.Delay(70);

            foreach (DataRow Row in DTTodaysTestAppointments.Rows)
                AddNewTestAppointmentToList(Row);

            lblRecords.Text = DTTodaysTestAppointments.Rows.Count.ToString();
        }

        public frmTodaysTestAppointments()
        {
            InitializeComponent();

            clsFormsUtility.SetDGVHeaderColor(DGVTodaysTestAppointments, System.Drawing.Color.FromArgb(26, 45, 80));
            CmbBoxReadMode.SelectedIndex = CmbBoxReadMode.FindString("Pending");
        }


        void DGVTodaysTestAppointments_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                DGVTodaysTestAppointments.ClearSelection();
                DGVTodaysTestAppointments.Rows[e.RowIndex].Selected = true;

                DGVTodaysTestAppointments.Tag = e.RowIndex;

                CMSTestAppointment.Show(Cursor.Position);
            }
        }
        // Gets Test Appointment from selected row
        clsTestAppointment GetTestAppointmentFromSelectedTestAppointment()
        {
            if (DGVTodaysTestAppointments.SelectedCells.Count >= 1)
            {
                DataGridViewRow row = DGVTodaysTestAppointments.SelectedCells[0].OwningRow;
                int TestAppointmentID = Convert.ToInt32(row.Cells["colTestAppointmentID"].Value);
                return clsTestAppointment.Find(TestAppointmentID);
            }

            return null;
        }

        void CMSTestAppointment_Opening(object sender, CancelEventArgs e)
        {
            clsTestAppointment TestAppointment = GetTestAppointmentFromSelectedTestAppointment();
            if (TestAppointment == null) return;

            TSMIEdit.Enabled = !TestAppointment.IsLocked;
            TSMITakeTest.Enabled = !TestAppointment.IsLocked;
        }

        void TSMIEdit_Click(object sender, EventArgs e)
        {
            clsTestAppointment TestAppointment = GetTestAppointmentFromSelectedTestAppointment();
            if (TestAppointment == null) return;

            clsLocalDrivingLicenseApplication LDLApp = TestAppointment.GetLocalDrivingLicenseApplication();
            if (LDLApp == null) return;

            if (!clsFormsUtility.MsgBoxConfirm("Changing the appointment date will remove it from today's appointments list. \n\n" +
                                               "Are you sure you want to edit this appointment?")) return;

            frmEditTestAppointment frm = new frmEditTestAppointment(LDLApp, TestAppointment);
            frm.ShowDialog();

            RefreshTodaysTestAppointmentsList();
        }
        void TSMITakeTest_Click(object sender, EventArgs e)
        {
            clsTestAppointment TestAppointment = GetTestAppointmentFromSelectedTestAppointment();
            if (TestAppointment == null) return;

            clsLocalDrivingLicenseApplication LDLApp = TestAppointment.GetLocalDrivingLicenseApplication();
            if (LDLApp == null) return;

            if (LDLApp == null) return;
            if (LDLApp.ApplicationStatus != clsApplication.enApplicationStatus.New) return;

            if (TestAppointment.TestAppointmentDate.Date != DateTime.Today)
            {
                clsFormsUtility.MsgBoxExclamation($"Appointment Date is not today. \n" +
                                                  $"you can only take this test at [{TestAppointment.TestAppointmentDate.Date.ToString("d")}]."
                                                  , "Not Allowed");
                return;
            }

            if (TestAppointment.IsLocked)
            {
                clsFormsUtility.MsgBoxError("Appointment is locked, test has been taken before.", "Locked");
                return;
            }

            frmTakeTest frm = new frmTakeTest(LDLApp, TestAppointment);
            frm.ShowDialog();

            RefreshTodaysTestAppointmentsList();
        }

        void btnClose_Click(object sender, EventArgs e) => this.Close();
        void picBoxRefresh_Click(object sender, EventArgs e) => RefreshTodaysTestAppointmentsList();
        void CmbBoxReadMode_SelectedIndexChanged(object sender, EventArgs e) => RefreshTodaysTestAppointmentsList();


        // Permissions checking !
        private void frmTodaysTestAppointments_Load(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions(clsUser.enPermissions.TodaysTestAppointments)) this.Close();
        }
    }
}
