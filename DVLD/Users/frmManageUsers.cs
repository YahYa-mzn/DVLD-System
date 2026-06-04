// Form: Manage Users
// Displays and manages all system users
// Supports filtering by UserID, PersonID, UserName, CreatedByUserID
// Supports viewing Active/Inactive/Deleted/All users
// Allows activating, deactivating, editing, deleting, and recovering users
// Prevents operations on logged-in user for safety

using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Global_Classes;
using DVLD.People;
using DVLD.Users.Users;
using DVLD_BLL;

namespace DVLD.Users
{
    public partial class frmManageUsers : Form
    {
        enum enBtn
        {
            AddNewUser = 1,
            Close = 2
        }
        enum enTSMIItems
        {
            ShowDetails = 1,
            EditAll = 2,
            Activate = 3,
            Deactivate = 4,
            MoveToTrash = 5,
            Recover = 6,
            ChangePassword = 7,
            SendEmail = 8,
            PhoneCall = 9
        }

        clsUser.enReadMode _ReadMode { get; set; } = clsUser.enReadMode.Active;
        clsUser.enFilterColumn _FilterColumn { get; set; } = clsUser.enFilterColumn.None;
        clsFormsUtility.enInputType _InputType { get; set; }

        void AddRowToUsersList(DataRow Row)
        {
            string StrStatus = string.Empty;
            string StrCreatedByUserID = string.Empty;

            DGVUsers.Rows.Add(
                    Row["UserID"].ToString(),
                    Row["UserName"].ToString(),

                    string.Empty, // Separator

                    Row["PersonID"].ToString(),
                    clsUtility.GetFullName(Row["FirstName"].ToString(), Row["SecondName"].ToString()
                                           , Row["ThirdName"].ToString(), Row["LastName"].ToString()),

                    string.Empty, // Separator

                    // Convert status number to enum name
                    StrStatus = ((clsUser.enStatus)Convert.ToInt32(Row["Status"])).ToString(),

                    // Show "Admin" if created by system (null CreatedByUserID)
                    StrCreatedByUserID = (Row["CreatedByUserID"] != DBNull.Value && Row["CreatedByUserID"] != null)
                                         ? Row["CreatedByUserID"].ToString()
                                         : "No UserID [Admin]"
                );
        }
        async void RefreshUsersList()
        {
            DGVUsers.Rows.Clear();
            DataTable DTUsers = new DataTable();

            DTUsers = clsUser.GetUsersList(_ReadMode, _FilterColumn, txtBoxFilter.Text.Trim());

            await Task.Delay(50);

            foreach (DataRow Row in DTUsers.Rows) 
                AddRowToUsersList(Row);
            

            lblSystemRecords.Text = clsUser.GetSystemRecordsNumber(_ReadMode).ToString();
            lblRecords.Text = DTUsers.Rows.Count.ToString();
        }

        public frmManageUsers()
        {
            InitializeComponent();

            clsFormsUtility.SetDGVHeaderColor(DGVUsers, System.Drawing.Color.FromArgb(26, 45, 80));

            // Set default values
            CmbBoxReadMode.SelectedIndex = Convert.ToInt32(_ReadMode);
            CmbBoxFilterBy.SelectedIndex = Convert.ToInt32(_FilterColumn);
        }


        void AddNewUserForm()
        {
            frmAddNewUser frm = new frmAddNewUser();
            frm.ShowDialog();
        }
        void ShowDetailsForm(clsUser User)
        {
            if (User == null) return;

            frmUserInfo frm = new frmUserInfo(User);
            frm.ShowDialog();
        }
        void EditAllForm(clsUser User)
        {
            if (User == null) return;

            if (User.IsDeleted())
            {
                clsFormsUtility.MsgBoxError("The User is in the trash list. \nPlease recover it first to edit it", "Not Allowed");
                return;
            }

            // If editing logged-in user, use the global user object
            if (clsGlobal.CurrentUser.IsSameAs(User))
                User = clsGlobal.CurrentUser;

            frmEditUserInfo frm = new frmEditUserInfo(User);
            frm.ShowDialog();  
        }

        void Activate(clsUser User)
        {
            if (User == null) return;

            // Prevent activating logged-in user
            if (clsGlobal.CurrentUser.IsSameAs(User))
            {
                clsFormsUtility.MsgBoxExclamation("Cannot activate a logged in user.\t", "Not Allowed");
                return;
            }

            if (User.IsActive())
            {
                clsFormsUtility.MsgBoxError("The User is already Active.", "Not Allowed");
                return;
            }
            if (User.IsDeleted())
            {
                clsFormsUtility.MsgBoxExclamation("The User may have been moved to Trash. \nPlease recover it first to perform this Action\t", "Not Allowed");
                return;
            } 

            if (User.Activate())
            {
                clsFormsUtility.MsgBoxActionSucceeded("Activated", $"User");
            }
            else
            {
                clsFormsUtility.MsgBoxActionFailed("Activating", $"User");
            }
        }
        new void Deactivate(clsUser User)
        {
            if (User == null) return;

            // Prevent activating logged-in user
            if (clsGlobal.CurrentUser.IsSameAs(User))
            {
                clsFormsUtility.MsgBoxExclamation("Cannot deactivate a logged in user.\t", "Not Allowed");
                return;
            }

            if (!(User.IsActive() || User.IsDeleted()))
            {
                clsFormsUtility.MsgBoxError("The Person is already Inactive.", "Not Allowed");
                return;
            }
            if (User.IsDeleted())
            {
                clsFormsUtility.MsgBoxExclamation("The User may have been moved to Trash. \nPlease recover it first to perform this Action\t", "Not Allowed");
                return;
            } 

            if (User.Deactivate())
            {
                clsFormsUtility.MsgBoxActionSucceeded("Deactivated", $"User");
            }
            else
            {
                clsFormsUtility.MsgBoxActionFailed("Deactivating", $"User");
            }
        }
        void MoveToTrash(clsUser User)
        {
            if (User == null) return;

            // Prevent activating logged-in user
            if (clsGlobal.CurrentUser.IsSameAs(User))
            {
                clsFormsUtility.MsgBoxExclamation("Cannot move to trash a logged in user.\t", "Not Allowed");
                return;
            }

            if (User.IsDeleted())
            {
                clsFormsUtility.MsgBoxError("The Person is already in the trash list.", "Not Allowed");
                return;
            }

            User.PrepareObjectToDelete(clsUser.enDeletionType.SoftDelete);
            if (User.Delete())
            {
                clsFormsUtility.MsgBoxActionSucceeded("Moved to Trash", $"User");
            }
            else
            {
                clsFormsUtility.MsgBoxActionFailed("Moving to Trash", $"User");
            }                      
        }

        void Recover(clsUser User)
        {
            if (User == null) return;

            // Prevent activating logged-in user (WONT happen but safety check)
            if (clsGlobal.CurrentUser.IsSameAs(User))
            {
                clsFormsUtility.MsgBoxExclamation("Cannot recover a logged in user.\t", "Not Allowed");
                return;
            }

            if (!User.IsDeleted())
            {
                clsFormsUtility.MsgBoxError("The User is not in the trash list.", "Not Allowed");
                return;
            }

            if (User.Recover())      
                clsFormsUtility.MsgBoxActionSucceeded("Recovered", $"User");
            
            else     
                clsFormsUtility.MsgBoxActionFailed("Recovering", $"User");            
        }

        void ChangePasswordForm(clsUser User)
        {
            if (User == null) return; 

            if (User.IsDeleted())
            {
                clsFormsUtility.MsgBoxError("The User is in the trash list. \nPlease recover it first to change it's password", "Not Allowed");
                return;
            }

            // If changing logged-in user's password, use global object
            if (clsGlobal.CurrentUser.IsSameAs(User))
                User = clsGlobal.CurrentUser;

            frmChangePassword frm = new frmChangePassword(User);
            frm.ShowDialog();
        }

        // Placeholder for email feature in future
        void SendEmail()
        {
            clsFormsUtility.MsgBoxStub("Send Email");
        }

        // Placeholder for phone call feature in future
        void PhoneCall()
        {
            clsFormsUtility.MsgBoxStub("Phone Call");
        }


        // Handles button clicks
        void Btn_Click(object sender, EventArgs e)
        {
            enBtn enumTag = clsFormsUtility.GetEnumType<enBtn>(sender);

            switch (enumTag)
            {
                case enBtn.AddNewUser:
                    AddNewUserForm();
                    RefreshUsersList();
                    break;

                case enBtn.Close:
                    this.Close();
                    break;

                default:
                    break;
            }
        }


        // Shows context menu on right-click
        void DGVUsers_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                DGVUsers.ClearSelection();
                DGVUsers.Rows[e.RowIndex].Selected = true;

                DGVUsers.Tag = e.RowIndex;

                CMSUser.Show(Cursor.Position);
            }
        }
        // Gets UserID from selected row
        clsUser GetUserFromSelectedUser()
        {
            if (DGVUsers.SelectedCells.Count >= 1)
            {
                DataGridViewRow Row = DGVUsers.SelectedCells[0].OwningRow;
                int UserID = Convert.ToInt32(Row.Cells["colUserID"].Value);

                return clsUser.FindByUserID(UserID);
            }

            return null;
        }

        // Handles context menu item clicks
        void TSMIItem_Click(object sender, EventArgs e)
        {
            enTSMIItems enumTag = clsFormsUtility.GetEnumType_TSMI<enTSMIItems>(sender);
            clsUser User = GetUserFromSelectedUser();

            switch (enumTag)
            {
                case enTSMIItems.ShowDetails:
                    ShowDetailsForm(User);
                    break;

                case enTSMIItems.EditAll:
                    EditAllForm(User);
                    break;

                case enTSMIItems.Activate:
                    Activate(User);
                    break;

                case enTSMIItems.Deactivate:
                    Deactivate(User);
                    break;

                case enTSMIItems.MoveToTrash:
                    MoveToTrash(User);
                    break;

                case enTSMIItems.Recover:
                    Recover(User);
                    break;

                case enTSMIItems.ChangePassword:
                    ChangePasswordForm(User);
                    break;

                case enTSMIItems.SendEmail:
                    SendEmail();
                    break;

                case enTSMIItems.PhoneCall:
                    PhoneCall();
                    break;

                default:
                    break;
            }

            RefreshUsersList();
        }

        // Changes read mode and updates UI
        void CmbBoxReadMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ReadMode = (clsUser.enReadMode)CmbBoxReadMode.SelectedIndex;

            switch (_ReadMode)
            {
                case clsUser.enReadMode.All:
                    TSMIEdit.Enabled = true;
                    TSMIEdit_EditAll.Enabled = true;
                    TSMIEdit_Activate.Enabled = true;
                    TSMIEdit_Deactivate.Enabled = true;
                    TSMIRecover.Enabled = true;
                    TSMIMoveToTrash.Enabled = true;

                    lblSystemRecordstxt.Text = "         # All Records: ";
                    break;

                case clsUser.enReadMode.Active:
                    TSMIRecover.Enabled = false;
                    TSMIEdit_Activate.Enabled = false;
                    TSMIEdit.Enabled = true;
                    TSMIEdit_EditAll.Enabled = true;
                    TSMIEdit_Deactivate.Enabled = true;
                    TSMIMoveToTrash.Enabled = true;

                    lblSystemRecordstxt.Text = "   # Active Records: ";
                    break;

                case clsUser.enReadMode.Inactive:
                    TSMIRecover.Enabled = false;
                    TSMIEdit_Deactivate.Enabled = false;
                    TSMIEdit.Enabled = true;
                    TSMIEdit_EditAll.Enabled = true;
                    TSMIEdit_Activate.Enabled = true;
                    TSMIMoveToTrash.Enabled = true;

                    lblSystemRecordstxt.Text = "# Inactive Records: ";
                    break;

                case clsUser.enReadMode.Deleted:
                    TSMIEdit.Enabled = false;
                    TSMIEdit_EditAll.Enabled = false;
                    TSMIEdit_Activate.Enabled = false;
                    TSMIEdit_Deactivate.Enabled = false;
                    TSMIMoveToTrash.Enabled = false;
                    TSMIRecover.Enabled = true;

                    lblSystemRecordstxt.Text = "# Deleted Records: ";
                    break;

                default:
                    break;
            }

            RefreshUsersList();
        }
        // Changes filter column and sets input type
        void CmbBoxFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterColumn = (clsUser.enFilterColumn)CmbBoxFilterBy.SelectedIndex;

            txtBoxFilter.Clear();

            switch (_FilterColumn)
            {
                case clsUser.enFilterColumn.None:
                    txtBoxFilter.Enabled = false;
                    _InputType = clsFormsUtility.enInputType.None;
                    return;

                case clsUser.enFilterColumn.UserID:
                case clsUser.enFilterColumn.PersonID:
                case clsUser.enFilterColumn.CreatedByUserID:
                    _InputType = clsFormsUtility.enInputType.Numbers;
                    break;

                case clsUser.enFilterColumn.UserName:
                    _InputType = clsFormsUtility.enInputType.All;
                    break;

                default:
                    _InputType = clsFormsUtility.enInputType.None;
                    break;
            }

            txtBoxFilter.Enabled = true;
        }

        // Prevents invalid characters
        void TxtBox_KeyPress(object sender, KeyPressEventArgs e) => clsFormsUtility.txtBox_KeyPress(sender, e, _InputType);
        void txtBoxFilter_TextChanged(object sender, EventArgs e) => RefreshUsersList();
        void PicBoxRefresh_Click(object sender, EventArgs e) => RefreshUsersList();


        // Permissions checking !
        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions(clsUser.enPermissions.UsersManagement)) this.Close();
        }
    }
}