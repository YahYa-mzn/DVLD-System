// Form: Edit User Information
// Two-tab interface showing person details and editable user info
// Allows editing username, password, and status
// Validates username uniqueness (excluding current user's username)
// Disables status change for logged-in user (safety feature)
// Password visibility toggle

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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD.Users.Users
{
    public partial class frmEditUserInfo : Form
    {
        clsUser _User = null;

        enum enPicBox
        {
            ShowPassword = 1,
            ShowConfirmPassword = 2
        }
        enum enBtn
        {
            Save = 1,
            Cancel = 2,
            Next = 3,
            Back = 4
        }
        enum enTxtBox
        {
            UserName = 1,
            Password = 2,
            ConfirmPassword = 3
        }

        void LoadClerkPermissions()
        {
            if (_User == null)
                return;

            rdBtnClerk.Checked = true;

            // User & Access Management
            chkBoxUsersManagement.Checked = _User.HasPermission(clsUser.enPermissions.UsersManagement);
            chkBoxLoginRegister.Checked = _User.HasPermission(clsUser.enPermissions.LoginRegister);

            // People & Drivers
            chkBoxPeopleManagement.Checked = _User.HasPermission(clsUser.enPermissions.PeopleManagement);
            chkBoxDriversManagement.Checked = _User.HasPermission(clsUser.enPermissions.DriversManagement);

            // Applications & Services
            chkBoxNewLocalDrivingLicenseApplication.Checked =
                _User.HasPermission(clsUser.enPermissions.NewLocalDrivingLicenseApplication);

            chkBoxRetakeTestApplication.Checked =
                _User.HasPermission(clsUser.enPermissions.RetakeTestApplication);

            chkBoxRenewDrivingLicenseApplication.Checked =
                _User.HasPermission(clsUser.enPermissions.RenewDrivingLicenseApplication);

            chkBoxReplacementForLostOrDamagedLicenseApplication.Checked =
                _User.HasPermission(clsUser.enPermissions.ReplacementForLostOrDamagedLicenseApplication);

            chkBoxNewInternationalDrivingLicenseApplication.Checked =
                _User.HasPermission(clsUser.enPermissions.NewInternationalDrivingLicenseApplication);

            chkBoxReleaseDrivingLicenseApplication.Checked =
                _User.HasPermission(clsUser.enPermissions.ReleaseDrivingLicenseApplication);

            // Application Management
            chkBoxLocalDrivingLicenseApplicationManagement.Checked =
                _User.HasPermission(clsUser.enPermissions.LocalDrivingLicenseApplicationsManagement);

            chkBoxInternationalDrivingLicenseApplicationManagement.Checked =
                _User.HasPermission(clsUser.enPermissions.InternationalDrivingLicenseApplicationsManagement);

            // Others
            chkBoxDetainedDrivingLicenseManagement.Checked =
                _User.HasPermission(clsUser.enPermissions.DetainedDrivingLicenseManagement);

            chkBoxDetainLicense.Checked =
                _User.HasPermission(clsUser.enPermissions.DetainLicense);

            chkBoxTodaysTestAppointments.Checked =
                _User.HasPermission(clsUser.enPermissions.TodaysTestAppointments);

            // Administration
            chkBoxManageApplicationTypes.Checked =
                _User.HasPermission(clsUser.enPermissions.ManageApplicationTypes);

            chkBoxManageTestTypes.Checked =
                _User.HasPermission(clsUser.enPermissions.ManageTestTypes);
        }
        void LoadRole()
        {
            if (_User.Role == clsUser.enRole.Admin) rdBtnAdmin.Checked = true;
            if (_User.Role == clsUser.enRole.Tester) rdBtnTester.Checked = true;    
            if (_User.Role == clsUser.enRole.ApplicationsOfficer) rdApplicationOfficer.Checked = true;
            if (_User.Role == clsUser.enRole.Clerk) rdBtnClerk.Checked = true;
        }
        void LoadUserInfo()
        {
            ctrlPersonCardWithFilter.DisableFilterControls();
            ctrlPersonCardWithFilter.LoadPersonInfo(_User.Person);

            lblUserID.Text = _User.UserID.ToString();
            txtBoxUserName.Text = _User.UserName;
            txtBoxPassword.Text = _User.Password;
            txtBoxConfirmPassword.Text = _User.Password;
            CmbBoxStatus.SelectedIndex = CmbBoxStatus.FindString(_User.Status.ToString());

            if (_User.Role == clsUser.enRole.Clerk) LoadClerkPermissions();
            else LoadRole();

            // Prevent logged-in user from changing their own status
            if (clsGlobal.CurrentUser == _User)
                CmbBoxStatus.Enabled = false;
        }

        clsUser.enRole GetRole()
        {
            foreach (Control Ctrl in pnlRole.Controls)
            {
                if (Ctrl is RadioButton)
                {
                    RadioButton RdBtn = (RadioButton)Ctrl;

                    if (RdBtn.Checked && Convert.ToInt32(RdBtn.Tag) != 2)  // if the radio button is checked and not the clerk radio button
                        return (clsUser.enRole)(Convert.ToInt32(RdBtn.Tag));
                }
            }

            return clsUser.enRole.None;
        }
        clsUser.enPermissions GetPermissions()
        {
            clsUser.enPermissions Permissions = clsUser.enPermissions.None;

            // User & Access Management
            if (chkBoxUsersManagement.Checked) Permissions |= clsUser.enPermissions.UsersManagement;

            if (chkBoxLoginRegister.Checked) Permissions |= clsUser.enPermissions.LoginRegister;


            // People & Drivers
            if (chkBoxPeopleManagement.Checked) Permissions |= clsUser.enPermissions.PeopleManagement;

            if (chkBoxDriversManagement.Checked) Permissions |= clsUser.enPermissions.DriversManagement;


            // Applications & Services
            if (chkBoxNewLocalDrivingLicenseApplication.Checked) Permissions |= clsUser.enPermissions.NewLocalDrivingLicenseApplication;

            if (chkBoxRetakeTestApplication.Checked) Permissions |= clsUser.enPermissions.RetakeTestApplication;

            if (chkBoxRenewDrivingLicenseApplication.Checked) Permissions |= clsUser.enPermissions.RenewDrivingLicenseApplication;

            if (chkBoxReplacementForLostOrDamagedLicenseApplication.Checked) Permissions |= clsUser.enPermissions.ReplacementForLostOrDamagedLicenseApplication;

            if (chkBoxNewInternationalDrivingLicenseApplication.Checked) Permissions |= clsUser.enPermissions.NewInternationalDrivingLicenseApplication;

            if (chkBoxReleaseDrivingLicenseApplication.Checked) Permissions |= clsUser.enPermissions.ReleaseDrivingLicenseApplication;


            // Application Management
            if (chkBoxLocalDrivingLicenseApplicationManagement.Checked) Permissions |= clsUser.enPermissions.LocalDrivingLicenseApplicationsManagement;

            if (chkBoxInternationalDrivingLicenseApplicationManagement.Checked) Permissions |= clsUser.enPermissions.InternationalDrivingLicenseApplicationsManagement;


            // Others
            if (chkBoxDetainedDrivingLicenseManagement.Checked) Permissions |= clsUser.enPermissions.DetainedDrivingLicenseManagement;

            if (chkBoxDetainLicense.Checked) Permissions |= clsUser.enPermissions.DetainLicense;

            if (chkBoxTodaysTestAppointments.Checked) Permissions |= clsUser.enPermissions.TodaysTestAppointments;


            // Administration
            if (chkBoxManageApplicationTypes.Checked) Permissions |= clsUser.enPermissions.ManageApplicationTypes;

            if (chkBoxManageTestTypes.Checked) Permissions |= clsUser.enPermissions.ManageTestTypes;


            return Permissions;
        }

        public frmEditUserInfo(clsUser User)
        {
            InitializeComponent();
            _User = User;

            LoadUserInfo();
        }


        void tabCtrlInfoContainer_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == TabPageClerkPermissions)
            {
                if (!rdBtnClerk.Checked)
                {
                    e.Cancel = true;
                    clsFormsUtility.MsgBoxExclamation("You cannot set permissions for a non-clerk user.", "Not Allowed");
                }
            }
        }

        // Toggles password visibility
        void ShowPassword(System.Windows.Forms.TextBox TxtBox, PictureBox PicBox)
        {
            if (TxtBox.UseSystemPasswordChar)
            {
                PicBox.ImageLocation = clsSettings.clsUsers.HidePasswordPicPath;
                TxtBox.UseSystemPasswordChar = false;
            }
            else
            {
                PicBox.ImageLocation = clsSettings.clsUsers.ShowPasswordPicPath;
                TxtBox.UseSystemPasswordChar = true;
            }
        }
        // Handles password visibility toggle
        void PicBox_Click(object sender, EventArgs e)
        {
            PictureBox PicBox = (PictureBox)sender;
            enPicBox enumTag = (enPicBox)Convert.ToInt32(PicBox.Tag);

            switch (enumTag)
            {
                case enPicBox.ShowPassword:
                    ShowPassword(txtBoxPassword, PicBox);
                    break;

                case enPicBox.ShowConfirmPassword:
                    ShowPassword(txtBoxConfirmPassword, PicBox);
                    break;

                default:
                    break;
            }
        }

        // Validates user fields
        void TxtBox_Validating(object sender, CancelEventArgs e)
        {
            enTxtBox enumTag = clsFormsUtility.GetEnumType<enTxtBox>(sender);

            switch (enumTag)
            {
                case enTxtBox.UserName:
                    {
                        if (!clsValidation.IsValidUserName(txtBoxUserName.Text.Trim()))
                        {
                            errorProviderValidation.SetError(txtBoxUserName, "UserName is Invalid or Empty. Only letters, numbers, '_' and '.' are allowed.");
                            break;
                        }

                        // Skip uniqueness check if username unchanged
                        if (_User.UserName != txtBoxUserName.Text.Trim())
                        {
                            if (clsUser.IsUniqueFieldExists(clsUser.enUniqueField.UserName, txtBoxUserName.Text.Trim()))
                            {
                                errorProviderValidation.SetError(txtBoxUserName, "This UserName already Exists. Please choose another UserName");
                                break;
                            }
                        }
                        errorProviderValidation.SetError(txtBoxUserName, "");
                        break;
                    }

                case enTxtBox.Password:
                    {
                        if (!clsValidation.IsValidPassword(txtBoxPassword.Text.Trim()))
                        {
                            errorProviderValidation.SetError(txtBoxPassword, "Password must be 8–64 characters and include uppercase, lowercase, a number, and a symbol.");
                            break;
                        }
                        errorProviderValidation.SetError(txtBoxPassword, "");
                        break;
                    }

                case enTxtBox.ConfirmPassword:
                    {
                        if (!clsValidation.IsValidPasswordConfirmation(txtBoxPassword.Text.Trim(), txtBoxConfirmPassword.Text.Trim()))
                        {
                            errorProviderValidation.SetError(txtBoxConfirmPassword, "Password confirmation is empty or does not match Password.");
                            break;
                        }
                        errorProviderValidation.SetError(txtBoxConfirmPassword, "");
                        break;
                    }

                default:
                    break;
            }
        }


        // Checks if all fields are valid
        bool CanSave()
        {
            if (!ctrlPersonCardWithFilter.IsFound) return false;
            if (rdBtnClerk.Checked && GetPermissions() == clsUser.enPermissions.None) return false;

            foreach (Control Ctrl in grpBoxUserInfo.Controls)
            {
                if (Ctrl is System.Windows.Forms.TextBox)
                {
                    if (string.IsNullOrEmpty(Ctrl.Text))
                        return false;
                    if (!string.IsNullOrEmpty(errorProviderValidation.GetError(Ctrl)))
                        return false;
                }
            }

            return true;
        }
        void DisableAllControls()
        {
            txtBoxUserName.Enabled = false;
            txtBoxPassword.Enabled = false;
            txtBoxConfirmPassword.Enabled = false;
            CmbBoxStatus.Enabled = false;

            btnSave.Enabled = false;
        }
        void Save()
        {
            if (_User == null) return;

            if (!CanSave())
            {
                clsFormsUtility.MsgBoxExclamation("One or more Fields are Missing or Not Valid. \n" + "Please fill them in with correct Data.", "Required/Missed");
                return;
            }
             
            bool Result = false;

            if (rdBtnClerk.Checked)         
                Result = _User.SetUpdatedUserInfo(txtBoxUserName.Text.Trim(),
                                                  txtBoxPassword.Text.Trim(),
                                                  (clsUser.enStatus)CmbBoxStatus.SelectedIndex + 1,  // Status enum: Active = 1, Inactive = 2
                                                  GetPermissions());
            
            else
                Result = _User.SetUpdatedUserInfo(txtBoxUserName.Text.Trim(),
                                                  txtBoxPassword.Text.Trim(),
                                                  (clsUser.enStatus)CmbBoxStatus.SelectedIndex + 1,  // Status enum: Active = 1, Inactive = 2
                                                  GetRole());
            
                           

            if (Result)
                clsFormsUtility.MsgBoxActionSucceeded("Edited", $"User");

            else
                clsFormsUtility.MsgBoxActionFailed("Editing", $"User");

            DisableAllControls();
        }

        void Btn_Click(object sender, EventArgs e)
        {
            enBtn enumTag = clsFormsUtility.GetEnumType<enBtn>(sender);

            switch (enumTag)
            {
                case enBtn.Save:
                    Save();
                    break;

                case enBtn.Cancel:
                    this.Close();
                    break;

                case enBtn.Next:
                    tabCtrlInfoContainer.SelectedIndex++;
                    break;

                case enBtn.Back:
                    tabCtrlInfoContainer.SelectedIndex--;
                    break;

                default:
                    break;
            }
        }
    }
}