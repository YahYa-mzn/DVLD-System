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

namespace DVLD.Licenses.Detained_Licenses
{
    public partial class frmDetainLicense : Form
    {
        void LoadDetainLicenseInfo()
        {
            if (CtrlLicenseCardWithFilter.License == null)
            {
                lblDetainedLicenseID.Text = "N/A";
                return;
            }

            lblDetainedLicenseID.Text = "N/A";
            lblLicenseID.Text = CtrlLicenseCardWithFilter.License.LicenseID.ToString();
            lblDetainDate.Text = DateTime.Now.ToString("g");
            txtBoxNotes.Clear();
            txtBoxDetainFees.Text = "000.0000";
        }
        void ResetDetainLicenseInfo()
        {
            lblDetainedLicenseID.Text = "N/A";
            lblLicenseID.Text = "[????]";
            lblDetainDate.Text = DateTime.Now.ToString("g");
            txtBoxNotes.Clear();
            txtBoxDetainFees.Text = "000.0000";
        }

        void LoadDefaults()
        {
            lblDetainDate.Text = DateTime.Now.ToString("g");
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName + $" [{clsGlobal.CurrentUser.Person.FullName}]";
            txtBoxDetainFees.Text = "000.0000";

            CtrlLicenseCardWithFilter.LoadInfoInParent += LoadDetainLicenseInfo;
            CtrlLicenseCardWithFilter.ResetInfoInParent += ResetDetainLicenseInfo;
        }

        public frmDetainLicense()
        {
            InitializeComponent();

            LoadDefaults();
        }


        decimal GetFees() => (Decimal.TryParse(txtBoxDetainFees.Text.Trim(), out decimal Fees)) ? Fees : 0;
        
        void btnClose_Click(object sender, EventArgs e) => this.Close();
        void btnDetain_Click(object sender, EventArgs e)
        {
            clsLicense License = CtrlLicenseCardWithFilter.License;

            if (License == null) return;
            if (!License.IsActive)
            {
                clsFormsUtility.MsgBoxError("Cannot detain an Inactive license.", "Not Allowed");
                return;
            }
            if (License.IsDetained)
            {
                clsFormsUtility.MsgBoxExclamation("This license is already detained.", "Not Allowed");
                return;
            }


            if (!License.Detain(out int DetainedLicenseID, GetFees(), txtBoxNotes.Text.Trim(), clsGlobal.CurrentUser.UserID))
            {
                clsFormsUtility.MsgBoxActionFailed("detaining", "License");
                return;
            }

            clsFormsUtility.MsgBoxActionSucceeded("detained", "License");
            lblDetainedLicenseID.Text = DetainedLicenseID.ToString();
            CtrlLicenseCardWithFilter.CtrlLicenseCard.lblIsDetained.Text = "Detained";
        }

        void frmDetainLicense_FormClosing(object sender, FormClosingEventArgs e)
        {
            CtrlLicenseCardWithFilter.LoadInfoInParent -= LoadDetainLicenseInfo;
            CtrlLicenseCardWithFilter.ResetInfoInParent -= ResetDetainLicenseInfo;
        }


        // Permissions checking !
        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions(clsUser.enPermissions.DetainLicense)) this.Close();
        }
    }
}
