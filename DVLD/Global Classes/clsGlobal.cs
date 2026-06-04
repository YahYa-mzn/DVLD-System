// Class: Global Application State
// Manages application-wide state:
//   - Current logged-in user
//   - Current login session
//   - Login/logout operations
//   - Remember me functionality
// Used by all forms to access current user info

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BLL;

namespace DVLD.Global_Classes
{
    internal static class clsGlobal
    {
        public static bool RememberCurrentUser = false;

        public static clsUser CurrentUser { get; private set; } = null;
        public static clsLoginRegister UserLoginRegister { get; private set; } = null;


        // Attempts to log in with provided credentials
        public static bool Login(string UserName, string Password)
        {
            clsUser User = clsUser.FindByUserNameAndPassword(UserName, Password);

            if (User != null)
            {
                // Check if account is deleted
                if (User.IsDeleted())
                {
                    clsFormsUtility.MsgBoxError("Your account is not available. Please contact support. ", "Unavailable Account");
                    return false;
                }

                // Check if account is inactive
                if (!User.IsActive() && !User.IsDeleted())
                {
                    clsFormsUtility.MsgBoxError("Your account is inactive. Please contact the system administrator to activate it.", "Inactive Account");
                    return false;
                }

                CurrentUser = User;

                // Create login register record
                UserLoginRegister = clsLoginRegister.GetAddNewLoginRegisterObject(CurrentUser.UserID);

                if (!UserLoginRegister.Save())
                {
                    clsFormsUtility.MsgBoxActionFailed("Login", "User");
                    CurrentUser = null;
                    return false;
                }

                RememberUser();
                clsFormsUtility.MsgBoxActionSucceeded("Logged in", "User");
                return true;
            }

            clsFormsUtility.MsgBoxError("Invalid UserName/Password \t", "Wrong credentials");
            return false;
        }

        // Signs out current user and updates login register
        public static bool SignOut()
        {
            if (CurrentUser != null && UserLoginRegister != null)
            {
                // Set logout time
                UserLoginRegister.SetLogoutTime(DateTime.Now);

                if (UserLoginRegister.Save())
                {
                    clsFormsUtility.MsgBoxActionSucceeded("Signed out", "User");
                    RememberUser();

                    UserLoginRegister = null;
                    CurrentUser = null;
                    return true;
                }

                clsFormsUtility.MsgBoxActionFailed("Signing out", "Login Register info");
                return false;
            }

            clsFormsUtility.MsgBoxActionFailed("Signing out", "Current User");
            return false;
        }

        // Checks if the user has permissions per screen
        public static bool HasPermissions(clsUser.enPermissions Permissions)
        {
            if (!CurrentUser.HasPermission(Permissions))
            {
                clsFormsUtility.MsgBoxError(
                                "Access denied. \n" +
                                "You do not have permission to access this screen.\nPlease contact the admin.",
                                "Permission Denied"
                                );

                return false;
            }

            return true;
        }

        // Saves or clears Remember Me credentials
        public static void RememberUser()
        {
            if (RememberCurrentUser && CurrentUser != null)
            {
                List<string> UserLoginInfo = new List<string>()
                {
                    clsGlobal.CurrentUser.UserName,
                    clsGlobal.CurrentUser.Password,
                };

                clsFile.WriteOnFile(clsSettings.clsUsers.RememberMeFile, UserLoginInfo);
            }
            else
            {
                clsFile.ClearFile(clsSettings.clsUsers.RememberMeFile);
            }
        }
    }
}