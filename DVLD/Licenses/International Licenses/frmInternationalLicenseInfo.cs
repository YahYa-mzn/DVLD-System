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

namespace DVLD.Licenses.International_Licenses
{
    public partial class frmInternationalLicenseInfo : Form
    {
        public frmInternationalLicenseInfo(clsInternationalLicense InternationalLicense)
        {
            InitializeComponent();

            CtrlInternationalLicenseCard.LoadLicenseInfo(InternationalLicense);
        }

        void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
