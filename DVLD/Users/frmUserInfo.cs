// Form: User Information Display
// Simple read-only view of user details
// Uses CtrlUserCard to display user and person information

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

namespace DVLD.Users.Users
{
    public partial class frmUserInfo : Form
    {
        private clsUser _User = null;

        public frmUserInfo(clsUser User)
        {
            InitializeComponent();

            _User = User;
            ctrlUserCard.LoadUserInfo(_User);
        }

        void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}