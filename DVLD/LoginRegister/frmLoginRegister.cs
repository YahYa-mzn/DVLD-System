// Form: Login Register (Login History)
// Displays all user login/logout records
// Supports filtering by:
//   - Login time (date range)
//   - Logout time (date range)
//   - Currently logged-in users (null logout time)
// Shows UserID, UserName, Login Time, and Logout Time
// Allows viewing user details from context menu

using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Global_Classes;
using DVLD.Users.Users;
using DVLD_BLL;

namespace DVLD.Users.LoginRegister
{
    public partial class frmLoginRegister : Form
    {
        clsLoginRegister.enFilterColumn _FilterColumn { get; set; } = clsLoginRegister.enFilterColumn.None;
        clsFormsUtility.enInputType _InputType { get; set; } = clsFormsUtility.enInputType.None;

        void AddNewRow(DataRow Row)
        {
            string LogoutTime = default(string);

            DGVLoginRegister.Rows.Add(
                Row["LoginRegisterID"].ToString(),

                string.Empty, //Separator

                Row["UserID"].ToString(),
                Row["UserName"].ToString(),

                string.Empty, //Separator

                Convert.ToDateTime(Row["LoginTime"]).ToString("F"),
                // Show "[Logged in]" if no logout time
                LogoutTime = (Row["LogoutTime"] != null && Row["LogoutTime"] != DBNull.Value)
                            ? Convert.ToDateTime(Row["LogoutTime"]).ToString("F")
                            : "[Logged in]"
            );
        }
        async void RefreshLoginRegisterList()
        {
            DGVLoginRegister.Rows.Clear();
            DataTable DTLoginRegister = new DataTable();

            DateTime StartDate = clsUtility.GetDate(MskdTxtBoxStartDate.Text);
            DateTime EndDate = clsUtility.GetDate(MskdTxtBoxEndDate.Text);

            DTLoginRegister = (txtBoxFilterBy.Visible)
                              ? clsLoginRegister.GetLoginRegisterList(_FilterColumn, txtBoxFilterBy.Text.Trim())                  
                              : clsLoginRegister.GetLoginRegisterList(_FilterColumn, StartDate, EndDate);

            await Task.Delay(30);

            foreach (DataRow Row in DTLoginRegister.Rows)
                AddNewRow(Row);

            lblSystemRecords.Text = clsLoginRegister.GetSystemRecordsNumber().ToString();
            lblRecords.Text = DTLoginRegister.Rows.Count.ToString();
        }

        public frmLoginRegister()
        {
            InitializeComponent();


            clsFormsUtility.SetDGVHeaderColor(DGVLoginRegister, System.Drawing.Color.FromArgb(26, 45, 80));
            CmbBoxFilterBy.SelectedIndex = Convert.ToInt32(_FilterColumn);
        }


        void ShowDetailsForm(clsUser User)
        {
            if (User == null) return;

            frmUserInfo frm = new frmUserInfo(User);
            frm.ShowDialog();
        }

        // Shows context menu on right-click
        void DGVLoginRegister_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                DGVLoginRegister.ClearSelection();
                DGVLoginRegister.Rows[e.RowIndex].Selected = true;

                DGVLoginRegister.Tag = e.RowIndex;

                CMSLogin.Show(Cursor.Position);
            }
        }
        // Shows context menu on double-click
        void DGVLoginRegister_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DGVLoginRegister.ClearSelection();
                DGVLoginRegister.Rows[e.RowIndex].Selected = true;

                DGVLoginRegister.Tag = e.RowIndex;

                CMSLogin.Show(Cursor.Position);
            }
        }
        // Gets User from selected row
        clsUser GetUserFromSelectedLoginRegister()
        {
            if (DGVLoginRegister.SelectedCells.Count >= 1)
            {
                DataGridViewRow row = DGVLoginRegister.SelectedCells[0].OwningRow;
                int UserID = Convert.ToInt32(row.Cells["colUserID"].Value);
                return clsUser.FindByUserID(UserID);
            }

            return null;
        }

        // Handles context menu click
        void TSMI_Click(object sender, EventArgs e) => ShowDetailsForm(GetUserFromSelectedLoginRegister());


        void ClearFilters()
        {
            txtBoxFilterBy.TextChanged -= txtBoxFilterBy_TextChanged;
            txtBoxFilterBy.Clear();
            txtBoxFilterBy.TextChanged += txtBoxFilterBy_TextChanged;

            MskdTxtBoxStartDate.TextChanged -= MskTxtBox_TextChanged;
            MskdTxtBoxStartDate.Clear();
            MskdTxtBoxStartDate.TextChanged += MskTxtBox_TextChanged;

            MskdTxtBoxEndDate.TextChanged -= MskTxtBox_TextChanged;
            MskdTxtBoxEndDate.Clear();
            MskdTxtBoxEndDate.TextChanged += MskTxtBox_TextChanged;
        }

        // Changes filter column and enables/disables date pickers
        void CmbBoxFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterColumn = (clsLoginRegister.enFilterColumn)CmbBoxFilterBy.SelectedIndex;

            ClearFilters();

            switch (_FilterColumn)
            {
                case clsLoginRegister.enFilterColumn.None:
                case clsLoginRegister.enFilterColumn.LoggedInUsers:
                    _InputType = clsFormsUtility.enInputType.None;
                    txtBoxFilterBy.Hide();

                    MskdTxtBoxStartDate.Enabled = false;
                    MskdTxtBoxStartDate.Show();

                    MskdTxtBoxEndDate.Enabled = false;
                    MskdTxtBoxEndDate.Show();

                    lblStartDate.Show();
                    lblEndDate.Show();
                    break;

                case clsLoginRegister.enFilterColumn.UserID:
                    _InputType = clsFormsUtility.enInputType.Numbers;
                    txtBoxFilterBy.Show();

                    MskdTxtBoxStartDate.Enabled = false;
                    MskdTxtBoxStartDate.Hide();

                    MskdTxtBoxEndDate.Enabled = false;
                    MskdTxtBoxEndDate.Hide();

                    lblStartDate.Hide();
                    lblEndDate.Hide();
                    break;

                case clsLoginRegister.enFilterColumn.UserName:
                    _InputType = clsFormsUtility.enInputType.All;
                    txtBoxFilterBy.Show();

                    MskdTxtBoxStartDate.Enabled = false;
                    MskdTxtBoxStartDate.Hide();

                    MskdTxtBoxEndDate.Enabled = false;
                    MskdTxtBoxEndDate.Hide();

                    lblStartDate.Hide();
                    lblEndDate.Hide();
                    break;   

                case clsLoginRegister.enFilterColumn.LoginTime:
                case clsLoginRegister.enFilterColumn.LogoutTime:
                    _InputType = clsFormsUtility.enInputType.None;
                    txtBoxFilterBy.Hide();
                    MskdTxtBoxStartDate.Enabled = true;
                    MskdTxtBoxStartDate.Show();

                    MskdTxtBoxEndDate.Enabled = true;
                    MskdTxtBoxEndDate.Show();

                    lblStartDate.Show();
                    lblEndDate.Show();
                    break;

                default:
                    break;
            }

            RefreshLoginRegisterList();
        }

        // Checks if masked textbox is empty
        bool IsMskTxtBoxEmpty(MaskedTextBox MskTxtBox)
        {
            return MskTxtBox.Text.Replace(MskTxtBox.PromptChar.ToString(), "")
                       .Replace("/", "")
                       .Trim()
                       .Length == 0;
        }

        // Validates date range and refreshes list
        void MskTxtBox_TextChanged(object sender, EventArgs e)
        {
            MaskedTextBox MskTxtBox = (MaskedTextBox)sender;

            if (MskTxtBox.MaskCompleted)
            {
                DateTime Date = clsUtility.GetDate(MskTxtBox.Text);

                // Validate date is within logs date range
                if (!clsValidation.IsDateBetween(Date.Date, clsLoginRegister.LogsStartDate, clsLoginRegister.LogsEndDate))
                {
                    errorProviderValidation.SetError(MskTxtBox,
                                                     $"Please enter a date between {clsLoginRegister.LogsStartDate:yyyy/MM/dd} " +
                                                     $"and {clsLoginRegister.LogsEndDate:yyyy/MM/dd}.");
                    return;
                }

                errorProviderValidation.SetError(MskTxtBox, "");
                RefreshLoginRegisterList();
            }
            else if (IsMskTxtBoxEmpty(MskTxtBox))
            {
                RefreshLoginRegisterList();
            }
        }

        void btnClose_Click(object sender, EventArgs e) => this.Close();

        void txtBoxFilterBy_TextChanged(object sender, EventArgs e) => RefreshLoginRegisterList();
        void txtBoxFilterBy_KeyPress(object sender, KeyPressEventArgs e) => clsFormsUtility.txtBox_KeyPress(sender, e, _InputType);
        void PicBoxRefresh_Click(object sender, EventArgs e) => RefreshLoginRegisterList();


        // Permissions checking !
        private void frmLoginRegister_Load(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions(clsUser.enPermissions.LoginRegister)) this.Close();
        }
    }
}