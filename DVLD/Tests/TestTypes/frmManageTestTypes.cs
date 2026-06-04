using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Applications.ApplicationTypes;
using DVLD.Global_Classes;
using DVLD_BLL;

namespace DVLD.Tests.TestTypes
{
    public partial class frmManageTestTypes : Form
    {
        void AddRowToAppTypesList(DataRow Row)
        {
            DGVTestTypes.Rows.Add(
                Row["TestTypeID"].ToString(),
                Row["TestTypeTitle"].ToString(),
                Row["TestTypeDescription"].ToString(),
                Row["TestTypeFees"].ToString()
                );
        }
        void RefreshTestTypesList()
        {
            DGVTestTypes.Rows.Clear();
            DataTable DTTestTypes = clsTestType.GetTestTypesList();

            foreach (DataRow Row in DTTestTypes.Rows)
                AddRowToAppTypesList(Row);

        }

        public frmManageTestTypes()
        {
            InitializeComponent();
            clsFormsUtility.SetDGVHeaderColor(DGVTestTypes, System.Drawing.Color.FromArgb(26, 45, 80));

            RefreshTestTypesList();
        }


        void DGVTestTypes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DGVTestTypes.ClearSelection();
                DGVTestTypes.Rows[e.RowIndex].Selected = true;

                DGVTestTypes.Tag = e.RowIndex;

                CMSTestType.Show(Cursor.Position);
            }
        }
        void DGVTestTypes_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                DGVTestTypes.ClearSelection();
                DGVTestTypes.Rows[e.RowIndex].Selected = true;

                DGVTestTypes.Tag = e.RowIndex;

                CMSTestType.Show(Cursor.Position);
            }
        }

        int GetTestTypeIDFromSelectedTestType()
        {
            if (DGVTestTypes.SelectedCells.Count >= 1)
            {
                DataGridViewRow row = DGVTestTypes.SelectedCells[0].OwningRow;
                return Convert.ToInt32(row.Cells["colTestTypeID"].Value);
            }

            return -1;
        }

        void TSMIEdit_Click(object sender, EventArgs e)
        {
            clsTestType.enTestType TestTypeID = (clsTestType.enTestType)GetTestTypeIDFromSelectedTestType();
            clsTestType TestType = clsTestType.Find(TestTypeID);

            frmEditTestType frm = new frmEditTestType(TestType);
            frm.ShowDialog();

            RefreshTestTypesList();
        }

        void btnClose_Click(object sender, EventArgs e) => this.Close();


        // Permissions checking !
        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions(clsUser.enPermissions.ManageTestTypes)) this.Close();
        }
    }
}
