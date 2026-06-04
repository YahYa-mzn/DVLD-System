// Form: Change Password
// Allows users to change their password
// Validates current password before allowing change
// Ensures new password is different from current password
// Shows user information using CtrlUserCard

using System;
using System.ComponentModel;
using System.Windows.Forms;
using DVLD.Global_Classes;
using DVLD_BLL;

namespace DVLD.Users.Users
{
    public partial class frmChangePassword : Form
    {
        clsUser _User { get; set; } = null;

        enum enPicBox
        {
            ShowCurrentPassword = 1,
            ShowNewPassword = 2,
            ShowConfirmPassword = 3
        }
        enum enBtn
        {
            Save = 1,
            Cancel = 2,
        }
        enum enTxtBox
        {
            CurrentPassword = 1,
            NewPassword = 2,
            ConfirmPassword = 3
        }

        public frmChangePassword(clsUser User)
        {
            InitializeComponent();

            _User = User;
            ctrlUserCard.LoadUserInfo(_User);
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
        // Handles password visibility toggles
        void PicBox_Click(object sender, EventArgs e)
        {
            PictureBox PicBox = (PictureBox)sender;
            enPicBox enumTag = (enPicBox)Convert.ToInt32(PicBox.Tag);

            switch (enumTag)
            {
                case enPicBox.ShowCurrentPassword:
                    ShowPassword(txtBoxCurrentPassword, PicBox);
                    break;

                case enPicBox.ShowNewPassword:
                    ShowPassword(txtBoxNewPassword, PicBox);
                    break;

                case enPicBox.ShowConfirmPassword:
                    ShowPassword(txtBoxConfirmPassword, PicBox);
                    break;

                default:
                    break;
            }
        }

        // Validates password fields
        void TxtBox_Validating(object sender, CancelEventArgs e)
        {
            if (_User == null) return;

            enTxtBox enumTag = clsFormsUtility.GetEnumType<enTxtBox>(sender);

            switch (enumTag)
            {
                case enTxtBox.CurrentPassword:
                    {
                        if (!_User.IsPasswordMatchUserPassword(txtBoxCurrentPassword.Text.Trim()))
                        {
                            errorProviderValidation.SetError(txtBoxCurrentPassword, "The current password you entered is incorrect.");
                            break;
                        }

                        errorProviderValidation.SetError(txtBoxCurrentPassword, "");
                        break;
                    }

                case enTxtBox.NewPassword:
                    {
                        if (!clsValidation.IsValidPassword(txtBoxNewPassword.Text.Trim()))
                        {
                            errorProviderValidation.SetError(txtBoxNewPassword, "Password must be 8–64 characters and include uppercase, lowercase, a number, and a symbol.");
                            break;
                        }

                        // Ensure new password is different from current
                        if (_User.IsPasswordMatchUserPassword(txtBoxNewPassword.Text.Trim()))
                        {
                            errorProviderValidation.SetError(txtBoxNewPassword, "Please choose a new password that's different from your current password.");
                            break;
                        }

                        errorProviderValidation.SetError(txtBoxNewPassword, "");
                        break;
                    }

                case enTxtBox.ConfirmPassword:
                    {
                        if (!clsValidation.IsValidPasswordConfirmation(txtBoxNewPassword.Text.Trim(), txtBoxConfirmPassword.Text.Trim()))
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
            if (!ctrlUserCard.IsFound)
                return false;

            foreach (Control Ctrl in pnlChangePassword.Controls)
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
            txtBoxCurrentPassword.Enabled = false;
            txtBoxNewPassword.Enabled = false;
            txtBoxConfirmPassword.Enabled = false;

            btnSave.Enabled = false;
        }
        void Save()
        {
            if (_User == null)
            {
                clsFormsUtility.MsgBoxError("User does not exists in the system.", "Failed");
                return;
            }

            if (!CanSave())
            {
                clsFormsUtility.MsgBoxExclamation("One or more Fields are Missing or Not Valid. \n" + "Please fill them in with correct Data.", "Required/Missed");
                return;
            }


            if (_User.SetUpdatedUserInfo(_User.UserName, txtBoxNewPassword.Text.Trim(), _User.Status))
                clsFormsUtility.MsgBoxActionSucceeded("Changed", $"User's Password");
            
            else
                clsFormsUtility.MsgBoxActionFailed("Password Changing", $"User");
            

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

                default:
                    break;
            }
        }
    }
}