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

namespace DVLD.Applications.Renew_Driving_License
{
    public partial class frmRenewDrivingLicenseApplication : Form
    {
        void LoadRenewDrivingLicenseApplicationInfo()
        {
            clsLicense OldLicense = CtrlLicenseCardWithFilter.License;
            clsApplicationType ApplicationType = clsApplicationType.Find(clsApplicationType.enApplicationType.RenewDrivingLicenseService);

            lblRenewDrivingLicenseAppID.Text = "N/A";
            lblRenewedLicenseID.Text = "N/A";
            lblRenewedSerialNumber.Text = "N/A";

            lblOldLicenseID.Text = OldLicense.LicenseID.ToString();
            lblIssueDate.Text = DateTime.Today.ToString("d");
            lblExpirationDate.Text = OldLicense.LicenseClass.ExpirationDate.ToString("d");

            lblApplicationFees.Text = ApplicationType.ApplicationTypeFees.ToString();
            lblClassFees.Text = OldLicense.LicenseClass.ClassFees.ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName + $" [{clsGlobal.CurrentUser.Person.FullName}]";

            txtBoxNotes.Clear();

            lblTotalFees.Text = (ApplicationType.ApplicationTypeFees + OldLicense.LicenseClass.ClassFees).ToString();
        }
        void ResetRenewDrivingLicenseApplicationInfo()
        {
            lblRenewDrivingLicenseAppID.Text = "N/A";
            lblRenewedLicenseID.Text = "N/A";
            lblRenewedSerialNumber.Text = "N/A";

            lblOldLicenseID.Text = "[????]";
            lblIssueDate.Text = DateTime.Today.ToString("d");
            lblExpirationDate.Text = "0000/00/00";
            lblClassFees.Text = "[????]";

            txtBoxNotes.Clear();

            lblTotalFees.Text = "[????]";
        }

        public frmRenewDrivingLicenseApplication()
        {
            InitializeComponent();

            // Setting today s date:
            lblIssueDate.Text = DateTime.Today.ToString("d");

            CtrlLicenseCardWithFilter.LoadInfoInParent += LoadRenewDrivingLicenseApplicationInfo;
            CtrlLicenseCardWithFilter.ResetInfoInParent += ResetRenewDrivingLicenseApplicationInfo;
        }


        void btnClose_Click(object sender, EventArgs e) => this.Close();
        void btnIssue_Click(object sender, EventArgs e)
        {
            clsLicense OldLicense = CtrlLicenseCardWithFilter.License;

            if (OldLicense == null) return;
            if (OldLicense.IsDetained)
            {
                clsFormsUtility.MsgBoxError("Cannot Renew a detained license. \n" +
                                                  "Please release this license to renew it", "Not Allowed");
                return;
            }
            if (!OldLicense.IsExpired)
            {
                clsFormsUtility.MsgBoxError("This license is not expired yet.  \t", "Not Allowed");
                return;
            }    
            if (OldLicense.Driver.HasActiveLicense(Convert.ToInt32(OldLicense.LicenseClass.LicenseClassID)))
            {
                clsFormsUtility.MsgBoxExclamation("This driver already have an active license.  \t", "Not Allowed");
                return;
            }

            if (!clsFormsUtility.MsgBoxConfirm("Have you collected Renewing fees?")) return;


            clsLicense RenewedLicense = OldLicense.RenewDrivingLicense(out int RenewLicenseApplicationID, txtBoxNotes.Text.Trim(), clsGlobal.CurrentUser.UserID);

            if (RenewedLicense != null)
            {
                clsFormsUtility.MsgBoxActionSucceeded("Renewed", "Expired license");

                lblRenewDrivingLicenseAppID.Text = RenewLicenseApplicationID.ToString();
                lblRenewedLicenseID.Text = RenewedLicense.LicenseID.ToString();
                lblRenewedSerialNumber.Text = RenewedLicense.SerialNumber;

                CtrlLicenseCardWithFilter.CtrlLicenseCard.lblIsActive.Text = "Inactive";
                return;
            }

            clsFormsUtility.MsgBoxActionFailed("Renewing", "Selected license");
        }

        void frmRenewDrivingLicenseApplication_FormClosing(object sender, FormClosingEventArgs e)
        {
            CtrlLicenseCardWithFilter.LoadInfoInParent -= LoadRenewDrivingLicenseApplicationInfo;
            CtrlLicenseCardWithFilter.ResetInfoInParent -= ResetRenewDrivingLicenseApplicationInfo;
        }


        // Permissions checking !
        private void frmRenewDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions(clsUser.enPermissions.RenewDrivingLicenseApplication)) this.Close();
        }
    }
}
