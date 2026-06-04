// Form: Add New User
// Two-tab interface: Person selection and User info
// Tab 1: Select person using CtrlPersonCardWithFilter
// Tab 2: Enter username, password, and status
// Validates that person doesn't already have a user account
// Shows/hides password with toggle button

using System;
using System.ComponentModel;
using System.Windows.Forms;
using DVLD.Global_Classes;
using DVLD_BLL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD.Users.Users
{
    public partial class frmAddNewUser : Form
    {
        enum enBtn
        {
            Save = 1,
            Cancel = 2,
            Next = 3,
            Back = 4,
        }
        enum enPicBox
        {
            ShowPassword = 1,
            ShowConfirmPassword = 2
        }
        enum enTxtBox
        {
            UserName = 1,
            Password = 2,
            ConfirmPassword = 3
        }

        // Loads person info into user info tab
        void ResetUserInfoPage()
        {
            if (ctrlPersonCardWithFilter.ctrlPersonCard.Person == null) return;

            txtBoxUserName.Clear();
            txtBoxPassword.Clear();
            txtBoxConfirmPassword.Clear();
            CmbBoxStatus.SelectedIndex = CmbBoxStatus.FindString("Active");
        }
        clsUser.enRole GetRole()
        {
            foreach (Control Ctrl in pnlRole.Controls)
            {
                if (Ctrl is RadioButton)
                {
                    RadioButton RdBtn = (RadioButton)Ctrl;

                    if (RdBtn.Checked && Convert.ToInt32(RdBtn.Tag) != 2)  // if the radio button is checked and not the clerk radio button
                        return (clsUser.enRole) (Convert.ToInt32(RdBtn.Tag));
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

        public frmAddNewUser()
        {
            InitializeComponent();

            CmbBoxStatus.SelectedIndex = CmbBoxStatus.FindString("Active");
        }


        // Checks if person is valid and doesn't have existing user account
        bool IsValidPerson()
        {
            if (ctrlPersonCardWithFilter.ctrlPersonCard.Person == null)
            {
                clsFormsUtility.MsgBoxExclamation("Person should be selected first to be added as a user.", "Not Allowed");
                return false;
            }

            string StrPersonID = ctrlPersonCardWithFilter.ctrlPersonCard.Person.PersonID.ToString();
            
            if (ctrlPersonCardWithFilter.IsFound)
            {
                if (clsUser.IsUniqueFieldExists(clsUser.enUniqueField.PersonID, StrPersonID))
                {
                    clsFormsUtility.MsgBoxExclamation("This person already exists as a User.", "Duplicate User");
                    return false;
                }

                return true;
            }

            clsFormsUtility.MsgBoxExclamation("Please select a person to add new user", "Not Allowed");
            return false;
        }
        

        // Prevents navigating to user tab without valid person
        void tabCtrlInfoContainer_Selecting(object sender, TabControlCancelEventArgs e)
        {
            ResetUserInfoPage(); 

            if (e.TabPage == TabPageUser && !clsValidation.IsOnlyDigits(lblUserID.Text))
            {
                if (!IsValidPerson())
                    e.Cancel = true; // Block navigation       
            }

            if (e.TabPage == TabPageClerkPermissions)
            {
                if (!IsValidPerson())
                {
                    e.Cancel = true;
                    return;
                }

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
        // Handles password visibility toggle clicks
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
            ctrlPersonCardWithFilter.DisableFilterControls();

            txtBoxUserName.Enabled = false;
            txtBoxPassword.Enabled = false;
            txtBoxConfirmPassword.Enabled = false;
            CmbBoxStatus.Enabled = false;

            btnSave.Enabled = false;
        }
      
        void Save()
        {
            if (!CanSave())
            {
                clsFormsUtility.MsgBoxExclamation("One or more Fields are Missing or Not Valid. \n" +
                                                  "Please fill them in with correct Data.",
                                                  "Required/Missed");
                return;
            }

            clsPerson Person = ctrlPersonCardWithFilter.ctrlPersonCard.Person;
            clsUser User = null;

            if (rdBtnClerk.Checked)
            {
                User = clsUser.GetAddNewUserObject(Person,
                                                   txtBoxUserName.Text.Trim(),
                                                   txtBoxPassword.Text.Trim(),
                                                   clsGlobal.CurrentUser.UserID,
                                                   GetPermissions(),
                                                   (clsUser.enStatus)(CmbBoxStatus.SelectedIndex + 1)); // Status: Active = 1, Inactive = 2
            }

            else
            {
                User = clsUser.GetAddNewUserObject(Person,
                                                   txtBoxUserName.Text.Trim(),
                                                   txtBoxPassword.Text.Trim(),
                                                   clsGlobal.CurrentUser.UserID,
                                                   GetRole(),
                                                   (clsUser.enStatus)(CmbBoxStatus.SelectedIndex + 1)); // Status: Active = 1, Inactive = 2
            }
            

            if (User == null)
            {
                // if it returned null that means the person is not exists or the permissions have not been set yet
                // the fields are checked and validated at the CanSave() method !

                clsFormsUtility.MsgBoxError("The person does not exist in the system, or the permissions have not been set yet. ", "Not Found");
                return;
            }


            if (User.Save())
            {
                lblUserID.Text = User.UserID.ToString();
                clsFormsUtility.MsgBoxActionSucceeded("Added", $"User");
            }
            else
            {
                clsFormsUtility.MsgBoxActionFailed("Adding", $"User");
            }

            DisableAllControls();
        }

        // Handles button clicks
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

        // Validates user fields without blocking navigation
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
                        if (clsUser.IsUniqueFieldExists(clsUser.enUniqueField.UserName, txtBoxUserName.Text.Trim()))
                        {
                            errorProviderValidation.SetError(txtBoxUserName, "This UserName already Exists. Please choose another UserName");
                            break;
                        }

                        errorProviderValidation.SetError(txtBoxUserName, "");
                        break;
                    }

                case enTxtBox.Password:
                    {
                        if (clsValidation.IsValidPassword(txtBoxPassword.Text.Trim()))
                        {
                            errorProviderValidation.SetError(txtBoxPassword, "");
                            break;
                        }

                        errorProviderValidation.SetError(txtBoxPassword, "Password must be 8–64 characters and include uppercase, lowercase, a number, and a symbol.");
                        break;
                    }

                case enTxtBox.ConfirmPassword:
                    {
                        if (clsValidation.IsValidPasswordConfirmation(txtBoxPassword.Text.Trim(), txtBoxConfirmPassword.Text.Trim()))
                        {
                            errorProviderValidation.SetError(txtBoxConfirmPassword, "");
                            break;
                        }

                        errorProviderValidation.SetError(txtBoxConfirmPassword, "Password confirmation is empty or does not match Password.");
                        break;
                    }

                default:
                    break;
            }
        }
    }
}