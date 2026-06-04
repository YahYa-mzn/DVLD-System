using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Global_Classes;
using DVLD_BLL;

namespace DVLD.Drivers
{
    public partial class frmManageDrivers : Form
    {
        clsDriver.enFilterColumn _FilterColumn { get; set; } = clsDriver.enFilterColumn.None;

        clsFormsUtility.enInputType _InputType { get; set; } = clsFormsUtility.enInputType.None;

        
        void AddNewRowToDriversList(DataRow Row)
        {
            DGVDrivers.Rows.Add(
                   Row["DriverID"].ToString(),

                   string.Empty, //Separator

                   Row["PersonID"].ToString(),
                   Row["NationalNo"].ToString(),

                   clsUtility.GetFullName(Row["FirstName"].ToString(),
                                          Row["SecondName"].ToString(),
                                          Row["ThirdName"].ToString(),
                                          Row["LastName"].ToString()),

                   string.Empty, //Separator

                   Convert.ToDateTime(Row["CreationDate"]).ToString("f"),
                   Row["ActiveLicenses"].ToString()

                   );
        }
        async void RefreshDriversList()
        {
            DGVDrivers.Rows.Clear();
            DataTable DTDrivers = clsDriver.GetDriversList(_FilterColumn, txtBoxFilter.Text.Trim());

            await Task.Delay(50);

            foreach (DataRow Row in DTDrivers.Rows)
                AddNewRowToDriversList(Row);

            lblSystemRecords.Text = clsDriver.GetSystemRecordsNumber().ToString();
            lblRecords.Text = DTDrivers.Rows.Count.ToString();        
        }

        public frmManageDrivers()
        {
            InitializeComponent();

            clsFormsUtility.SetDGVHeaderColor(DGVDrivers, System.Drawing.Color.FromArgb(26, 45, 80));
            CmbBoxFilterBy.SelectedIndex = CmbBoxFilterBy.FindString("None");
        }



        // Shows context menu when right-clicking a row
        void DGVDrivers_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                DGVDrivers.ClearSelection();
                DGVDrivers.Rows[e.RowIndex].Selected = true;

                DGVDrivers.Tag = e.RowIndex;

                CMSDriver.Show(Cursor.Position);
            }
        }
        // Shows context menu on double-click
        void DGVDrivers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DGVDrivers.ClearSelection();
                DGVDrivers.Rows[e.RowIndex].Selected = true;

                DGVDrivers.Tag = e.RowIndex;

                CMSDriver.Show(Cursor.Position);
            }
        }


        // Gets Driver from the selected row
        clsDriver GetDriverFromSelectedDriver()
        {
            if (DGVDrivers.SelectedCells.Count >= 1)
            {
                DataGridViewRow row = DGVDrivers.SelectedCells[0].OwningRow;
                int DriverID = Convert.ToInt32(row.Cells["colDriverID"].Value);

                return clsDriver.Find(DriverID);
            }

            return null;
        }

        void CmbBoxFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterColumn = (clsDriver.enFilterColumn)CmbBoxFilterBy.SelectedIndex;

            // avoids duplicated rows
            txtBoxFilter.TextChanged -= txtBoxFilter_TextChanged;
            txtBoxFilter.Clear();
            txtBoxFilter.TextChanged += txtBoxFilter_TextChanged;

            switch (_FilterColumn)
            {
                case clsDriver.enFilterColumn.None:
                    _InputType = clsFormsUtility.enInputType.None;
                    txtBoxFilter.Enabled = false;
                    break;

                case clsDriver.enFilterColumn.DriverID:
                case clsDriver.enFilterColumn.PersonID:
                    _InputType = clsFormsUtility.enInputType.Numbers;
                    txtBoxFilter.Enabled = true;
                    break;

                case clsDriver.enFilterColumn.NationalNo:
                    _InputType = clsFormsUtility.enInputType.LettersAndNumbers;
                    txtBoxFilter.Enabled = true;
                    break;

                default:
                    _InputType = clsFormsUtility.enInputType.None;
                    txtBoxFilter.Enabled = true;
                    break;
            }

            RefreshDriversList();
        }

        void btnClose_Click(object sender, EventArgs e) => this.Close();

        void txtBoxFilter_KeyPress(object sender, KeyPressEventArgs e) => clsFormsUtility.txtBox_KeyPress(sender, e, _InputType);
        void txtBoxFilter_TextChanged(object sender, EventArgs e) => RefreshDriversList();

        void TSMIShowLicenseHistory_Click(object sender, EventArgs e)
        {
            clsDriver Driver = GetDriverFromSelectedDriver();
            if (Driver == null) return;

            frmDriverLicenseHistory frm = new frmDriverLicenseHistory(Driver);
            frm.ShowDialog();
        }

        void PicBoxRefresh_Click(object sender, EventArgs e) => RefreshDriversList();


        // Permissions checking !
        private void frmManageDrivers_Load(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions(clsUser.enPermissions.DriversManagement)) this.Close();
        }
    }
}
