// User Control: Displays user information
// Shows UserID, UserName, Status, and person details
// Uses CtrlPersonCard for person information display

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

namespace DVLD.Users.Users.Controls
{
    public partial class CtrlUserCard : UserControl
    {
        clsUser _User { get; set; } = null;
        public bool IsFound { get; private set; } = false;

        // Resets all fields to default
        void Reset()
        {
            lblUserID.Text = "N/A";
            lblUsername.Text = "[????]";
            lblStatus.Text = "[????]";
        }

        // Loads user information
        public bool LoadUserInfo(clsUser User)
        {
            if (User == null)
            {
                clsFormsUtility.MsgBoxError("The User does not exist in the System. \t", "Not Found");
                ctrlPersonCard.Reset();
                Reset();

                IsFound = false;
                return false;
            }

            this._User = User;

            // Load person info using embedded person card
            ctrlPersonCard.LoadPersonInfo(_User.Person);

            lblUserID.Text = _User.UserID.ToString();
            lblUsername.Text = _User.UserName + $" [{_User.StrRole}]";
            lblStatus.Text = _User.Status.ToString();

            IsFound = true;
            return true;
        }

        public CtrlUserCard()
        {
            InitializeComponent();
        }
    }
}