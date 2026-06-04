using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using DVLD.Global_Classes;
using DVLD.Tests.TestAppointments;
using DVLD_BLL;

namespace DVLD.Tests
{
    public partial class frmScheduleTest : Form
    {
        private clsLocalDrivingLicenseApplication _LDLApp { get; set; } = null;
        private clsTestType.enTestType _TestTypeID { get; set; }

        enum enBtn
        {
            AddNewAppointment = 1,
            Close = 2
        }
        enum enTSMI
        {
            Edit = 1,
            Cancel = 2,
            TakeTest = 3
        }

        string GetResultImage(bool Result) 
            => (Result) ? clsSettings.ImgTrue : clsSettings.ImgFalse;
        void AddAppointmentToAppointmentsList(DataRow Row)
        {
            string IsLockedImage = Convert.ToBoolean(Row["IsLocked"])
                                   ? clsSettings.ImgLocked
                                   : clsSettings.ImgUnlocked;

            string Examiner = (string.IsNullOrEmpty(Row["Examiner"].ToString()) || Row["Examiner"] == DBNull.Value)
                              ? "[Not assigned yet]"
                              : Row["Examiner"].ToString();

            string ResultImage = (Row["Result"] == DBNull.Value || Row["Result"] == null)
                          ? clsSettings.ImgPending
                          : GetResultImage(Convert.ToBoolean(Row["Result"]));

            DGVAppointments.Rows.Add(
                    Row["TestAppointmentID"].ToString(),
                    Convert.ToDateTime(Row["Date"]).ToString("d"),
                    Convert.ToDecimal(Row["PaidFees"]).ToString(),
                    Image.FromFile(IsLockedImage),

                    string.Empty, //Separator

                    Examiner,
                    Image.FromFile(ResultImage)
                );
        }
        void RefreshAppointmentsList()
        {
            if (_LDLApp == null) return;
            if (this._LDLApp.ApplicationStatus != clsApplication.enApplicationStatus.New) return;

            DGVAppointments.Rows.Clear();
            DataTable DTAppointments = clsTestAppointment.GetTestAppointmentsList(_LDLApp.LocalDrivingLicenseApplicationID, _TestTypeID); // Get Appointments by LocalDrivingLicenseApplicationID !

            foreach (DataRow Row in DTAppointments.Rows)
            {
                AddAppointmentToAppointmentsList(Row);
            }
        }

        void LoadDefaults()
        {
           if (this._LDLApp == null) return;
           if (this._LDLApp.ApplicationStatus != clsApplication.enApplicationStatus.New) return;


            switch (_TestTypeID) 
            {
                case clsTestType.enTestType.VisionTest:
                    lblTitletxt.Text = "Vision Test Appointment";
                    PicBoxTitleImage.ImageLocation = clsSettings.clsTests.VisionTestImagePath;
                    break;

                case clsTestType.enTestType.WrittenTest:
                    lblTitletxt.Text = "Written Test Appointment";
                    PicBoxTitleImage.ImageLocation = clsSettings.clsTests.WrittenTestImagePath;
                    break;

                case clsTestType.enTestType.PracticalTest:
                    lblTitletxt.Text = "Practical Test Appointment";
                    PicBoxTitleImage.ImageLocation = clsSettings.clsTests.PracticalTestImagePath;
                    break;

                default:
                    break;
            }

            CtrlLocalDrivingLicenseApplicationCard.LoadLocalDrivingLicenseApplicationInfo(_LDLApp);
            RefreshAppointmentsList();
        }

        public frmScheduleTest(clsLocalDrivingLicenseApplication LDLApp, clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();

            this._LDLApp = LDLApp;
            this._TestTypeID = TestTypeID;

            clsFormsUtility.SetDGVHeaderColor(DGVAppointments, System.Drawing.Color.FromArgb(26, 45, 80));

            LoadDefaults();
        }
           

        void AddNewAppointmentForm()
        {
            if (this._LDLApp == null) return;
            if (this._LDLApp.ApplicationStatus != clsApplication.enApplicationStatus.New) return;   

            // LDLApp has an active appointment (check it from the LDLApp)
            if (_LDLApp.HasActiveAppointmentForCurrentTest())
            {
                clsFormsUtility.MsgBoxError("Cannot add an appointment to this local driving license application due to an existing active Appointment.", "Not Allowed");
                return;
            }

            string TestName = (_TestTypeID == clsTestType.enTestType.VisionTest)
                              ? "Vision test"
                              : (_TestTypeID == clsTestType.enTestType.WrittenTest)
                                        ? "Written test"
                                        : "Practical test";

            if (_LDLApp.CurrentTestType != _TestTypeID || _LDLApp.IsPassedAllTests())
            {
                clsFormsUtility.MsgBoxInfo($"{TestName} has been completed. " +
                                           $"\nCannot add new {TestName} Appointment.",
                                           "Test Completed");
                return;
            }

            frmAddNewTestAppointment frm = new frmAddNewTestAppointment(this._LDLApp, this._TestTypeID);
            frm.ShowDialog();

            LoadDefaults();
        }
        void Btn_Click(object sender, EventArgs e)
        {
            enBtn enumTag = clsFormsUtility.GetEnumType<enBtn>(sender);

            switch (enumTag)
            {
                case enBtn.AddNewAppointment:
                    AddNewAppointmentForm();
                    LoadDefaults();
                    break;

                case enBtn.Close:
                    this.Close();
                    break;

                default:
                    break;
            }
        }

        void Edit(clsTestAppointment TestAppointment)
        {
            if (_LDLApp == null || TestAppointment == null) return;


            frmEditTestAppointment frm = new frmEditTestAppointment(_LDLApp, TestAppointment);
            frm.ShowDialog();
        }        
        void Cancel(clsTestAppointment TestAppointment)
        {
            if (_LDLApp == null || TestAppointment == null) return;

            if (TestAppointment.IsLocked)
            {
                clsFormsUtility.MsgBoxExclamation("This appointment cannot be canceled because it is locked or the test has already been taken.",
                                                  "Not Allowed");
                return;
            }

            if (!TestAppointment.CancelAppointment())
            {
                clsFormsUtility.MsgBoxError("Appointment canceling could not be Completed.\n" +
                                            "The appointment may no longer exist or canceling failed.",
                                            "Failed");
                return;
            }

            clsFormsUtility.MsgBoxInfo("Appointment has been canceled successfully.", "Success");
        }
        void TakeTest(clsTestAppointment TestAppointment)
        {
            if (this._LDLApp == null) return;
            if (this._LDLApp.ApplicationStatus != clsApplication.enApplicationStatus.New) return;
            
            if (TestAppointment.TestAppointmentDate.Date != DateTime.Today)
            {
                clsFormsUtility.MsgBoxExclamation($"Appointment Date is not today, " +
                                                  $"you can only take this test at [{TestAppointment.TestAppointmentDate.Date.ToString("d")}]."
                                                  , "Not Allowed");
                return;
            }

            if (TestAppointment.IsLocked)
            {
                clsFormsUtility.MsgBoxError("Appointment is locked, test has been taken before.", "Locked");
                return;
            }

            frmTakeTest frm = new frmTakeTest(this._LDLApp, TestAppointment);
            frm.ShowDialog();
        }
       
        void TSMI_Click(object sender, EventArgs e)
        {
            enTSMI enumTag = clsFormsUtility.GetEnumType_TSMI<enTSMI>(sender);
            clsTestAppointment TestAppointment = GetAppointmentFromSelectedAppointment();

            switch (enumTag)
            {
                case enTSMI.Edit:
                    Edit(TestAppointment);
                    break;

                case enTSMI.Cancel:
                    Cancel(TestAppointment);
                    break;

                case enTSMI.TakeTest:
                    TakeTest(TestAppointment);
                    break;

                default:
                    break;
            }

            LoadDefaults();
        }


        // Shows context menu when right-clicking a row
        void DGVAppointments_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                DGVAppointments.ClearSelection();
                DGVAppointments.Rows[e.RowIndex].Selected = true;

                DGVAppointments.Tag = e.RowIndex;

                CMSTestAppointment.Show(Cursor.Position);
            }
        }
        clsTestAppointment GetAppointmentFromSelectedAppointment()
        {
            if (DGVAppointments.SelectedCells.Count >= 1)
            {
                DataGridViewRow Row = DGVAppointments.SelectedCells[0].OwningRow;
                int TestAppointmentID = Convert.ToInt32(Row.Cells["colTestAppointmentID"].Value);

                return clsTestAppointment.Find(TestAppointmentID);
            }

            return null;
        }
    }
}
