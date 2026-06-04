// Form: Login Screen
// Main entry point for user authentication
// Validates username and password
// Supports "Remember Me" feature (saves credentials to file)
// Creates login register record on successful login
// Password visibility toggle

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DVLD.Global_Classes;
using DVLD_BLL;

namespace DVLD.Users
{
    public partial class frmLogin : Form
    {
        enum enBtn
        {
            Login = 1,
            ShowPassword = 2, // PictureBox acting as button
            Close = 3
        }
        enum enTxtBox
        {
            Username = 1,
            Password = 2
        }

        // Loads saved username/password from file if "Remember Me" was checked
        void LoadUserLoginInfo()
        {
            List<string> UserLoginInfo = clsFile.ReadFromFile(clsSettings.clsUsers.RememberMeFile);

            if (UserLoginInfo.Count == 2)
            {
                txtBoxUserName.Text = UserLoginInfo[0];
                txtBoxPassword.Text = UserLoginInfo[1];
            }
        }

        public frmLogin()
        {
            InitializeComponent();
        }

        // Loads credentials when form becomes visible
        void frmLogin_VisibleChanged(object sender, EventArgs e)
        {
            LoadUserLoginInfo();
        }


        // Validates username and password format
        void txtBox_Validating(object sender, CancelEventArgs e)
        {
            enTxtBox enumTag = clsFormsUtility.GetEnumType<enTxtBox>(sender);

            switch (enumTag)
            {
                case enTxtBox.Username:
                    if (!clsValidation.IsValidUserName(txtBoxUserName.Text.Trim()))
                    {
                        errorProviderValidation.SetError(txtBoxUserName, "UserName is Invalid or Empty. Only letters, numbers, '_' and '.' are allowed.");
                        break;
                    }
                    errorProviderValidation.SetError(txtBoxUserName, "");
                    break;

                case enTxtBox.Password:
                    if (!clsValidation.IsValidPassword(txtBoxPassword.Text.Trim()))
                    {
                        errorProviderValidation.SetError(txtBoxPassword, "Password must be 8–64 characters and include uppercase, lowercase, a number, and a symbol.");
                        break;
                    }

                    errorProviderValidation.SetError(txtBoxPassword, "");
                    break;

                default:
                    break;
            }
        }

        // Checks if login credentials are valid
        bool CanLogin()
        {
            foreach (Control Ctrl in pnlLogin.Controls)
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

        // Attempts login with provided credentials
        bool Login()
        {
            if (!CanLogin())
            {
                clsFormsUtility.MsgBoxExclamation("One or more Fields are Missing or Not Valid. \n" +
                                                  "Please fill them in with correct Data.",
                                                  "Required/Missed");
                return false;
            }

            clsGlobal.RememberCurrentUser = ChkBoxRememberMe.Checked;

            if (clsGlobal.Login(txtBoxUserName.Text.Trim(), txtBoxPassword.Text.Trim()))
            {
                txtBoxUserName.Clear();
                txtBoxPassword.Clear();
                return true;
            }

            return false;
        }

        // Toggles password visibility
        void ShowPassword()
        {
            if (txtBoxPassword.UseSystemPasswordChar)
            {
                PicBoxShowPassword.ImageLocation = clsSettings.clsUsers.HidePasswordPicPath;
                txtBoxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                PicBoxShowPassword.ImageLocation = clsSettings.clsUsers.ShowPasswordPicPath;
                txtBoxPassword.UseSystemPasswordChar = true;
            }
        }

        // Handles button clicks
        void Btn_Click(object sender, EventArgs e)
        {
            enBtn enumTag = clsFormsUtility.GetEnumType<enBtn>(sender);

            switch (enumTag)
            {
                case enBtn.Login:
                    if (Login())
                    {
                        this.Hide();
                        frmMain frm = new frmMain(this);
                        frm.ShowDialog();
                    }
                    break;

                case enBtn.ShowPassword:
                    ShowPassword();
                    break;

                case enBtn.Close:
                    this.Close();
                    break;

                default:
                    break;
            }
        }
    }
}