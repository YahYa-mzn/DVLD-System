using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Drivers;
using DVLD.Global_Classes;
using DVLD.Licenses.International_Licenses;
using DVLD.Licenses.Local_Licenses;
using DVLD_BLL;

namespace DVLD.Applications.International_Driving_License
{
    public partial class frmManageInternationalDrivingLicenseApplication : Form
    {
        clsInternationalLicense.enFilterColumn _FilterColumn { get; set; } = clsInternationalLicense.enFilterColumn.None;
        clsFormsUtility.enInputType _InputType { get; set; } = clsFormsUtility.enInputType.None;

        void AddNewRowToInternationalLicenseApplicationsList(DataRow Row)
        {
            string IsActiveImage = (Convert.ToBoolean(Row["IsActive"]) == true)
                              ? clsSettings.ImgTrue
                              : clsSettings.ImgFalse;


            DGVInternationalLicenseApplications.Rows.Add(
                Row["InternationalLicenseID"].ToString(),
                Row["InternationalSerialNumber"].ToString(),
                Row["ApplicationID"].ToString(),

                string.Empty, // Separator

                Row["DriverID"].ToString(),
                Row["NationalNo"].ToString(),

                clsUtility.GetFullName(Row["FirstName"].ToString(),
                                       Row["SecondName"].ToString(),
                                       Row["ThirdName"].ToString(),
                                       Row["LastName"].ToString()),

                Row["LicenseID"].ToString(),

                string.Empty, // Separator

                Convert.ToDateTime(Row["IssueDate"]).ToString("d"),
                Convert.ToDateTime(Row["ExpirationDate"]).ToString("d"),
                Image.FromFile(IsActiveImage)
                );
        }
        async void RefreshInternationalLicenseApplicationsList()
        {
            DGVInternationalLicenseApplications.Rows.Clear();

            DataTable DTInternationalDrivingLicenseApps = clsInternationalLicense.GetInternationalLicensesList(_FilterColumn, txtBoxFilter.Text.Trim());

            await Task.Delay(40);

            foreach (DataRow Row in DTInternationalDrivingLicenseApps.Rows)
                AddNewRowToInternationalLicenseApplicationsList(Row);

            lblSystemRecords.Text = clsInternationalLicense.GetSystemRecordsNumber().ToString();
            lblRecords.Text = DTInternationalDrivingLicenseApps.Rows.Count.ToString();
        }

        public frmManageInternationalDrivingLicenseApplication()
        {
            InitializeComponent();

            clsFormsUtility.SetDGVHeaderColor(DGVInternationalLicenseApplications, System.Drawing.Color.FromArgb(26, 45, 80));

            CmbBoxFilterBy.SelectedIndex = CmbBoxFilterBy.FindString("None");
        }


        void btnClose_Click(object sender, EventArgs e) => this.Close();
        void btnAddNewInternationalDrivingLicenseApp_Click(object sender, EventArgs e)
        {
            frmIssueInternationalDrivingLicense frm = new frmIssueInternationalDrivingLicense();
            frm.ShowDialog();

            RefreshInternationalLicenseApplicationsList();
        }

        void CmbBoxFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterColumn = (clsInternationalLicense.enFilterColumn)CmbBoxFilterBy.SelectedIndex;

            txtBoxFilter.TextChanged -= txtBoxFilter_TextChanged;
            txtBoxFilter.Clear();
            txtBoxFilter.TextChanged += txtBoxFilter_TextChanged;

            switch (_FilterColumn)
            {
                case clsInternationalLicense.enFilterColumn.None:
                    _InputType = clsFormsUtility.enInputType.None;
                    txtBoxFilter.Enabled = false;
                    break;

                case clsInternationalLicense.enFilterColumn.InternationalLicenseID:
                case clsInternationalLicense.enFilterColumn.DriverID:
                case clsInternationalLicense.enFilterColumn.LicenseID:
                    _InputType = clsFormsUtility.enInputType.Numbers;
                    txtBoxFilter.Enabled = true;
                    break;

                case clsInternationalLicense.enFilterColumn.InternationalSerialNumber:
                    _InputType = clsFormsUtility.enInputType.All;
                    txtBoxFilter.Enabled = true;
                    break;

                case clsInternationalLicense.enFilterColumn.NationalNo:
                    _InputType = clsFormsUtility.enInputType.LettersAndNumbers;
                    txtBoxFilter.Enabled = true;
                    break;

                default:
                    _InputType = clsFormsUtility.enInputType.None;
                    break;
            }

            RefreshInternationalLicenseApplicationsList();
        }


        // Shows context menu when right-clicking a row
        void DGVInternationalDrivingLicenseApps_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                DGVInternationalLicenseApplications.ClearSelection();
                DGVInternationalLicenseApplications.Rows[e.RowIndex].Selected = true;

                DGVInternationalLicenseApplications.Tag = e.RowIndex;

                CMSInternationalLicenseApp.Show(Cursor.Position);
            }
        }
        // Shows context menu on double-click
        void DGVInternationalDrivingLicenseApps_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DGVInternationalLicenseApplications.ClearSelection();
                DGVInternationalLicenseApplications.Rows[e.RowIndex].Selected = true;

                DGVInternationalLicenseApplications.Tag = e.RowIndex;

                CMSInternationalLicenseApp.Show(Cursor.Position);
            }
        }

        clsInternationalLicense GetInternationalLicenseFromSelectedInternationalLicense()
        {
            if (DGVInternationalLicenseApplications.SelectedCells.Count >= 1)
            {
                DataGridViewRow row = DGVInternationalLicenseApplications.SelectedCells[0].OwningRow;
                int InternationalLicenseID = Convert.ToInt32(row.Cells["colInternationalLicenseID"].Value);

                return clsInternationalLicense.Find(InternationalLicenseID);
            }

            return null;
        }

        void TSMIShowDetails_Click(object sender, EventArgs e)
        {
            clsInternationalLicense InternationalLicense = GetInternationalLicenseFromSelectedInternationalLicense();
            if (InternationalLicense == null) return;

            frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo(InternationalLicense);
            frm.ShowDialog();
        }
        void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsInternationalLicense InternationalLicense = GetInternationalLicenseFromSelectedInternationalLicense();
            if (InternationalLicense == null) return;

            frmDriverLicenseHistory frm = new frmDriverLicenseHistory(InternationalLicense.License.Driver);
            frm.ShowDialog();
        }

        void txtBoxFilter_TextChanged(object sender, EventArgs e) => RefreshInternationalLicenseApplicationsList();
        void txtBoxFilter_KeyPress(object sender, KeyPressEventArgs e) => clsFormsUtility.txtBox_KeyPress(sender, e, _InputType);
        void PicBoxRefresh_Click(object sender, EventArgs e) => RefreshInternationalLicenseApplicationsList();


        // Permissions checking !
        private void frmManageInternationalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions(clsUser.enPermissions.InternationalDrivingLicenseApplicationsManagement)) this.Close();
        }
    }
}
