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
using DVLD.Licenses.Detained_Licenses;
using DVLD.Licenses.Local_Licenses;
using DVLD_BLL;

namespace DVLD.Applications.Detain_Driving_License
{
    public partial class frmManageDetainedDrivingLicenseApplication : Form
    {
        enum enTSMI
        {
            ShowLicense = 1,
            ShowLicenseHistory = 2,
            ReleaseDetainedLicense = 3
        }

        clsFormsUtility.enInputType _InputType { get; set; } = clsFormsUtility.enInputType.None;
        clsDetainedLicense.enReadMode _ReadMode { get; set; } = clsDetainedLicense.enReadMode.None;
        clsDetainedLicense.enFilterColumn _FilterColumn { get; set; } = clsDetainedLicense.enFilterColumn.None;

        void AddNewRowToDetainedLicensesList(DataRow Row)
        {
            string IsReleasedImage = (Convert.ToBoolean(Row["IsReleased"]))
                                ? clsSettings.ImgUnlocked
                                : clsSettings.ImgLocked;

            string StrReleaseApplicationID = (string.IsNullOrEmpty(Row["ReleaseApplicationID"].ToString()) || Row["ReleaseApplicationID"] == DBNull.Value)
                                             ? string.Empty
                                             : Row["ReleaseApplicationID"].ToString();

            string StrReleaseDate = (Row["ReleaseDate"] == DBNull.Value)
                                    ? string.Empty
                                    : Convert.ToDateTime(Row["ReleaseDate"]).ToString("g");


            DGVDetainedLicenses.Rows.Add(
                   Row["DetainedLicenseID"].ToString(),
                   Row["LicenseID"].ToString(),
                   Row["SerialNumber"].ToString(),
                   Row["NationalNo"].ToString(),

                   clsUtility.GetFullName(Row["FirstName"].ToString(), 
                                          Row["SecondName"].ToString(), 
                                          Row["ThirdName"].ToString(), 
                                          Row["LastName"].ToString()),

                   Convert.ToDateTime(Row["DetainDate"]).ToString("g"),
                   Convert.ToDecimal(Row["FineFees"]).ToString(),

                   "",
                   Image.FromFile(IsReleasedImage),
                   "",

                   StrReleaseApplicationID,
                   StrReleaseDate
                );
        }
        async void RefreshDetainedLicensesList()
        {
            await Task.Delay(30);

            DGVDetainedLicenses.Rows.Clear();
            DataTable DTDetainedLicenses = new DataTable();
            DTDetainedLicenses = clsDetainedLicense.GetDetainedLicensesList(txtBoxFilter.Text.Trim(), _FilterColumn, _ReadMode);

            foreach (DataRow Row in DTDetainedLicenses.Rows)
                AddNewRowToDetainedLicensesList(Row);

            lblSystemRecords.Text = clsDetainedLicense.GetSystemRecordsNumber(_ReadMode).ToString(); // Count system records per read mode
            lblRecords.Text = DTDetainedLicenses.Rows.Count.ToString();
        }

        public frmManageDetainedDrivingLicenseApplication()
        {
            InitializeComponent();

            clsFormsUtility.SetDGVHeaderColor(DGVDetainedLicenses, System.Drawing.Color.FromArgb(26, 45, 80));

            CmbBoxFilterBy.SelectedIndex = CmbBoxFilterBy.FindString("None");
            CmbBoxReadMode.SelectedIndex = CmbBoxReadMode.FindString("None");
        }


        void btnClose_Click(object sender, EventArgs e) => this.Close();
        void btnNewDetainedLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();

            RefreshDetainedLicensesList();
        }

        void txtBoxFilter_KeyPress(object sender, KeyPressEventArgs e) => clsFormsUtility.txtBox_KeyPress(sender, e, _InputType);
        void txtBoxFilter_TextChanged(object sender, EventArgs e) => RefreshDetainedLicensesList();
        void PicBoxRefresh_Click(object sender, EventArgs e) => RefreshDetainedLicensesList();

        void CmbBoxFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterColumn = (clsDetainedLicense.enFilterColumn)CmbBoxFilterBy.SelectedIndex;

            txtBoxFilter.TextChanged -= txtBoxFilter_TextChanged;
            txtBoxFilter.Clear();
            txtBoxFilter.TextChanged += txtBoxFilter_TextChanged;

            switch (_FilterColumn)
            {
                case clsDetainedLicense.enFilterColumn.None:
                    txtBoxFilter.Enabled = false;
                    _InputType = clsFormsUtility.enInputType.None; 
                    break;

                case clsDetainedLicense.enFilterColumn.DetainedLicenseID:
                case clsDetainedLicense.enFilterColumn.LicenseID:
                    txtBoxFilter.Enabled = true;
                    _InputType = clsFormsUtility.enInputType.Numbers;
                    break;

                case clsDetainedLicense.enFilterColumn.SerialNumber:
                    txtBoxFilter.Enabled = true;
                    _InputType = clsFormsUtility.enInputType.All;
                    break;

                case clsDetainedLicense.enFilterColumn.NationalNo:
                    txtBoxFilter.Enabled = true;
                    _InputType = clsFormsUtility.enInputType.LettersAndNumbers;
                    break;

                default:
                    _InputType = clsFormsUtility.enInputType.None;
                    break;
            }

            RefreshDetainedLicensesList();
        }
        void CmbBoxReadMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ReadMode = (clsDetainedLicense.enReadMode)CmbBoxReadMode.SelectedIndex;

            switch (_ReadMode)
            {
                case clsDetainedLicense.enReadMode.None:
                    lblSystemRecordstxt.Text = "    # System Records:";
                    break;

                case clsDetainedLicense.enReadMode.Detained:
                    lblSystemRecordstxt.Text = "# Detained Records:";
                    TSMIReleaseDetainedLicense.Enabled = true;
                    break;

                case clsDetainedLicense.enReadMode.Released:
                    lblSystemRecordstxt.Text = "# Released Records:";
                    TSMIReleaseDetainedLicense.Enabled = false;
                    break;

                default:
                    break;
            }

            RefreshDetainedLicensesList();
        }

        // Shows context menu when right-clicking a row
        void DGVDetainedLicenses_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                DGVDetainedLicenses.ClearSelection();
                DGVDetainedLicenses.Rows[e.RowIndex].Selected = true;

                DGVDetainedLicenses.Tag = e.RowIndex;

                CMSDetainedLicense.Show(Cursor.Position);
            }
        }

        // Shows context menu on double-click
        void DGVDetainedLicenses_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DGVDetainedLicenses.ClearSelection();
                DGVDetainedLicenses.Rows[e.RowIndex].Selected = true;

                DGVDetainedLicenses.Tag = e.RowIndex;

                CMSDetainedLicense.Show(Cursor.Position);
            }
        }

        // Gets the selected detained license 
        clsDetainedLicense GetDetainedLicenseFromSelectedDetainedLicense()
        {
            if (DGVDetainedLicenses.SelectedCells.Count >= 1)
            {
                DataGridViewRow row = DGVDetainedLicenses.SelectedCells[0].OwningRow;
                int DetainedLicenseID = Convert.ToInt32(row.Cells["colDetainedLicenseID"].Value);

                return clsDetainedLicense.Find(DetainedLicenseID);
            }

            return null;
        }

        // Gets License from the selected detained license
        clsLicense GetLicenseFromSelectedDetainedLicense()
        {
            if (DGVDetainedLicenses.SelectedCells.Count >= 1)
            {
                DataGridViewRow row = DGVDetainedLicenses.SelectedCells[0].OwningRow;
                int LicenseID = Convert.ToInt32(row.Cells["colLicenseID"].Value);

                return clsLicense.Find(LicenseID);
            }

            return null;
        }

        void CMSDetainedLicense_Opening(object sender, CancelEventArgs e)
        {
            if (_ReadMode != clsDetainedLicense.enReadMode.None) return;

            clsDetainedLicense DetainedLicense = GetDetainedLicenseFromSelectedDetainedLicense();
            TSMIReleaseDetainedLicense.Enabled = !(DetainedLicense.IsReleased);
        }

        void TSMI_Click(object sender, EventArgs e)
        {
            clsLicense License = GetLicenseFromSelectedDetainedLicense();
            enTSMI enumTag = clsFormsUtility.GetEnumType_TSMI<enTSMI>(sender);

            switch (enumTag)
            {
                case enTSMI.ShowLicense:
                    frmLicenseInfo frm1 = new frmLicenseInfo(License);
                    frm1.ShowDialog();
                    break;

                case enTSMI.ShowLicenseHistory:
                    frmDriverLicenseHistory frm2 = new frmDriverLicenseHistory(License.Driver);
                    frm2.ShowDialog();
                    break;

                case enTSMI.ReleaseDetainedLicense:
                    frmReleaseDrivingLicenseApplication frm3 = new frmReleaseDrivingLicenseApplication(License);
                    frm3.ShowDialog();  
                    break;

                default:
                    break;
            }

            RefreshDetainedLicensesList();
        }


        // Permissions checking !
        private void frmManageDetainedDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions(clsUser.enPermissions.DetainedDrivingLicenseManagement)) this.Close();
        }

        private void DGVDetainedLicenses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
