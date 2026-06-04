using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BLL;

namespace DVLD.Licenses.Local_Licenses
{
    public partial class frmLicenseInfo : Form
    {
        public frmLicenseInfo(clsLicense License)
        {
            InitializeComponent();

            CtrlLicenseCard.LoadLicenseInfo(License);
        }

        void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
