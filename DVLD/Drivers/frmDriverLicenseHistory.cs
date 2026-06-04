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

namespace DVLD.Drivers
{
    public partial class frmDriverLicenseHistory : Form
    {
        void LoadDriverLicenseHistoryInfo(clsDriver Driver)
        {
            if (Driver == null)
            {
                clsFormsUtility.MsgBoxError("Failed to load driver license history", "Failed");
                return;
            }

            CtrlPersonCard.LoadPersonInfo(Driver.Person);
            CtrlDriverLicenses.LoadDriverLicensesInLists(Driver);
        }

        public frmDriverLicenseHistory(clsDriver Driver)
        {
            InitializeComponent();

            LoadDriverLicenseHistoryInfo(Driver);
        }

        void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
