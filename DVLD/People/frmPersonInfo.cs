// Form: Person Information Display
// Simple read-only view of person details
// Uses CtrlPersonCard to display information

using System;
using System.Windows.Forms;
using DVLD_BLL;

namespace DVLD.People
{
    public partial class frmPersonInfo : Form
    {
        public frmPersonInfo(clsPerson Person)
        {
            InitializeComponent();

            ctrlPersonCard.LoadPersonInfo(Person);
        }

        void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}