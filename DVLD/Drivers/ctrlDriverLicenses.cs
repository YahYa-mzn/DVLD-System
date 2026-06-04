using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using DVLD.Global_Classes;
using DVLD.Licenses.International_Licenses;
using DVLD.Licenses.Local_Licenses;
using DVLD_BLL;

namespace DVLD.Licenses.Controls
{
    public partial class ctrlDriverLicenses : UserControl
    {
        clsDriver _Driver { get; set; } = null;

        void AddNewLocalDrivingLicenseToList(DataRow Row)
        {
            string IsActiveImg = (Convert.ToBoolean(Row["IsActive"]))
                              ? clsSettings.ImgTrue
                              : clsSettings.ImgFalse;

            DGVLocalDrivingLicense.Rows.Add(
                    Row["LicenseID"].ToString(),
                    Row["SerialNumber"].ToString(),
                    Row["LicenseClass"].ToString(),
                    Row["ApplicationID"].ToString(),
                     Convert.ToDateTime(Row["IssueDate"]).ToString("d"),
                    Convert.ToDateTime(Row["ExpirationDate"]).ToString("d"),
                    Image.FromFile(IsActiveImg)
            );
        }
        void AddNewInternationalDrivingLicenseToList(DataRow Row)
        {
            string IsActiveImg = (Convert.ToBoolean(Row["IsActive"]))
                              ? clsSettings.ImgTrue
                              : clsSettings.ImgFalse;

            DGVInternationalLicense.Rows.Add(
                    Row["InternationalLicenseID"].ToString(),
                    Row["InternationalSerialNumber"].ToString(),
                    Row["LicenseID"].ToString(),
                    Row["ApplicationID"].ToString(),
                    Convert.ToDateTime(Row["IssueDate"]).ToString("d"),
                    Convert.ToDateTime(Row["ExpirationDate"]).ToString("d"),
                    Image.FromFile(IsActiveImg)
            );
        }

        void LoadLocalLicenses()
        {
            DataTable DTLocalDrivingLicenses = _Driver.GetLicensesList();

            foreach (DataRow Row in DTLocalDrivingLicenses.Rows)
                AddNewLocalDrivingLicenseToList(Row);

            lblLocalLicensesRecords.Text = DTLocalDrivingLicenses.Rows.Count.ToString();
        }
        void LoadInternationalLicenses()
        {
            DataTable DTInternationalDrivingLicenses = _Driver.GetInternationalLicensesList();

            foreach (DataRow Row in DTInternationalDrivingLicenses.Rows)
                AddNewInternationalDrivingLicenseToList(Row);

            lblInternationalLicenseRecords.Text = DTInternationalDrivingLicenses.Rows.Count.ToString();
        }

        public void LoadDriverLicensesInLists(clsDriver Driver)
        {
            if (Driver == null) return;

            _Driver = Driver;

            LoadLocalLicenses();
            LoadInternationalLicenses();
        }

        public ctrlDriverLicenses()
        {
            InitializeComponent();

            clsFormsUtility.SetDGVHeaderColor(DGVLocalDrivingLicense, System.Drawing.Color.FromArgb(26, 45, 80));
            clsFormsUtility.SetDGVHeaderColor(DGVInternationalLicense, System.Drawing.Color.FromArgb(26, 45, 80));
        }


        // Shows context menu when right-clicking a row
        void DGVLocalDrivingLicense_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                DGVLocalDrivingLicense.ClearSelection();
                DGVLocalDrivingLicense.Rows[e.RowIndex].Selected = true;

                DGVLocalDrivingLicense.Tag = e.RowIndex;

                CMSLicense.Show(Cursor.Position);
            }
        }

        // Shows context menu when double click a row
        void DGVLocalDrivingLicense_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DGVLocalDrivingLicense.ClearSelection();
                DGVLocalDrivingLicense.Rows[e.RowIndex].Selected = true;

                DGVLocalDrivingLicense.Tag = e.RowIndex;

                CMSLicense.Show(Cursor.Position);
            }
        }
        clsLicense GetLicenseFromSelectedLicense()
        {
            if (DGVLocalDrivingLicense.SelectedCells.Count >= 1)
            {
                DataGridViewRow row = DGVLocalDrivingLicense.SelectedCells[0].OwningRow;
                int LicenseID = Convert.ToInt32(row.Cells["colLicenseID"].Value);

                return clsLicense.Find(LicenseID);
            }

            return null;
        }

        void TSMIShowLicense_Click(object sender, EventArgs e)
        {
            clsLicense License = GetLicenseFromSelectedLicense();
            if (License == null) return; 

            frmLicenseInfo frm = new frmLicenseInfo(License);
            frm.ShowDialog();
        }



        // Shows context menu when right-clicking a row
        void DGVInternationalLicensesList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                DGVInternationalLicense.ClearSelection();
                DGVInternationalLicense.Rows[e.RowIndex].Selected = true;

                DGVInternationalLicense.Tag = e.RowIndex;

                CMSInternationalLicense.Show(Cursor.Position);
            }
        }
        // Shows context menu when double click a row
        void DGVInternationalLicensesList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DGVInternationalLicense.ClearSelection();
                DGVInternationalLicense.Rows[e.RowIndex].Selected = true;

                DGVInternationalLicense.Tag = e.RowIndex;

                CMSInternationalLicense.Show(Cursor.Position);
            }
        }
        clsInternationalLicense GetInternationalLicenseFromSelectedInternationalLicense()
        {
            if (DGVInternationalLicense.SelectedCells.Count >= 1)
            {
                DataGridViewRow row = DGVInternationalLicense.SelectedCells[0].OwningRow;
                int InternationalLicenseID = Convert.ToInt32(row.Cells["colInternationalLicense"].Value);

                return clsInternationalLicense.Find(InternationalLicenseID);
            }

            return null;
        }

        void TSMIShowInternationalLicense_Click(object sender, EventArgs e)
        {
            clsInternationalLicense InternationalLicense = GetInternationalLicenseFromSelectedInternationalLicense();
            if (InternationalLicense == null) return;

            frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo(InternationalLicense);
            frm.ShowDialog();
        }
    }
}
