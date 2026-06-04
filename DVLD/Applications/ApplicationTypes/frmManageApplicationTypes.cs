using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Global_Classes;
using DVLD_BLL;

namespace DVLD.Applications.ApplicationTypes
{
    public partial class frmManageApplicationTypes : Form
    {

        void AddRowToAppTypesList(DataRow Row)
        {
            DGVAppTypes.Rows.Add(
                Row["ApplicationTypeID"].ToString(),
                Row["ApplicationTypeTitle"].ToString(),
                Row["ApplicationTypeFees"].ToString()
                );
        }
        void RefreshAppTypesList()
        {
            DGVAppTypes.Rows.Clear();
            DataTable DTAppTypes = clsApplicationType.GetApplicationTypesList();

            foreach (DataRow Row in DTAppTypes.Rows) 
                AddRowToAppTypesList(Row);


            lblRecords.Text = DTAppTypes.Rows.Count.ToString();
        }

        public frmManageApplicationTypes()
        {
            InitializeComponent();

            clsFormsUtility.SetDGVHeaderColor(DGVAppTypes, System.Drawing.Color.FromArgb(26, 45, 80));

            RefreshAppTypesList();
        }

       
        void DGVAppTypes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DGVAppTypes.ClearSelection();
                DGVAppTypes.Rows[e.RowIndex].Selected = true;

                DGVAppTypes.Tag = e.RowIndex;

                CMSAppType.Show(Cursor.Position);
            }
        }
        void DGVAppTypes_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                DGVAppTypes.ClearSelection();
                DGVAppTypes.Rows[e.RowIndex].Selected = true;

                DGVAppTypes.Tag = e.RowIndex;

                CMSAppType.Show(Cursor.Position);
            }
        }

        int GetAppTypeIDFromSelectedAppType()
        {
            if (DGVAppTypes.SelectedCells.Count >= 1)
            {
                DataGridViewRow row = DGVAppTypes.SelectedCells[0].OwningRow;
                return Convert.ToInt32(row.Cells["colAppTypeID"].Value);
            }

            return -1;
        }

        void TSMIEdit_Click(object sender, EventArgs e)
        {
            clsApplicationType.enApplicationType AppTypeID = (clsApplicationType.enApplicationType)GetAppTypeIDFromSelectedAppType();
            clsApplicationType AppType = clsApplicationType.Find(AppTypeID);            

            frmEditApplicationType frm = new frmEditApplicationType(AppType);
            frm.ShowDialog();

            RefreshAppTypesList();
        }

        void btnClose_Click(object sender, EventArgs e) => this.Close();


        // Permissions checking !
        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions(clsUser.enPermissions.ManageApplicationTypes)) this.Close();
        }
    }
}
