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


namespace DVLD.Licenses.International_Licenses
{
    public partial class frmIssueInternationalDrivingLicense : Form
    {
        void LoadInternationalDrivingLicenseApplicationInfo()
        {
            clsLicense License = CtrlLicenseCardWithFilter.License;
            if (License == null) return;

            DateTime ExpirationDate = License.LicenseClass.ExpirationDate;
            clsApplicationType ApplicationType = clsApplicationType.Find(clsApplicationType.enApplicationType.NewInternationalLicense);

            lblInternationalLicenseAppID.Text = "N/A";
            lblInternationalLicenseID.Text = "N/A";
            lblSerialNumber.Text = "N/A";

            lblLicenseID.Text = License.LicenseID.ToString();
            lblExpirationDate.Text = ExpirationDate.ToString("d");
            lblFees.Text = ApplicationType.ApplicationTypeFees.ToString();
        }
        void ResetInternationalDrivingLicenseApplicationInfo()
        {
            lblInternationalLicenseAppID.Text = "N/A";
            lblInternationalLicenseID.Text = "N/A";
            lblSerialNumber.Text = "N/A";

            lblLicenseID.Text = "[????]";
            lblExpirationDate.Text = "0000/00/00";
            lblFees.Text = "[????]";
        }

        void LoadDefaults()
        {
            CtrlLicenseCardWithFilter.LoadInfoInParent += LoadInternationalDrivingLicenseApplicationInfo;
            CtrlLicenseCardWithFilter.ResetInfoInParent += ResetInternationalDrivingLicenseApplicationInfo;

            lblIssueDate.Text = DateTime.Today.ToString("d");
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName + $" [{clsGlobal.CurrentUser.Person.FullName}]";
        }

        public frmIssueInternationalDrivingLicense()
        {
            InitializeComponent();

            LoadDefaults();
        }


        void btnClose_Click(object sender, EventArgs e) => this.Close();

        bool CanSave()
        {
            clsLicense License = CtrlLicenseCardWithFilter.License;

            if (License == null) return false;

            if (!License.IsActive)
            {
                clsFormsUtility.MsgBoxError("License is inactive. \t", "Not Allowed");
                return false;
            }
            if (License.IsDetained)
            {
                clsFormsUtility.MsgBoxError("This license is detained. \n" +
                                            "Please release this license to issue an international license.", "Not Allowed");
                return false;
            }
            if (License.LicenseClass.LicenseClassID != clsLicenseClass.enLicenseClass.Class3_OrdinaryDriving)
            {
                clsFormsUtility.MsgBoxExclamation("Cannot issue an international license for this class. \n" +
                                                  "Only Class 3 - Ordinary driving license is allowed.", "Not Allowed");
                return false;
            }
            if (clsInternationalLicense.IsActiveInternationalLicenseExistsByDriverID(License.Driver.DriverID))
            {
                bool DeactivateCurrentLicense = clsFormsUtility.MsgBoxConfirm("This driver already holds an international driving license. \n" +
                                                  "Would you like to issue a new one and deactivate the current license?");
                
                return (DeactivateCurrentLicense)
                       ? clsInternationalLicense.DeactivatePreviousInternationalLicenses(License.Driver.DriverID) 
                       : false;
            }

            if (!clsFormsUtility.MsgBoxConfirm("Have you collected Issuing fees?  ")) return false;

            return true;
        }
        void btnIssue_Click(object sender, EventArgs e)
        {
            if (!CanSave()) return;

            clsLicense License = CtrlLicenseCardWithFilter.License;

            clsInternationalLicense InternationalLicense = clsInternationalLicense.IssueInternationalDrivingLicense(License, clsGlobal.CurrentUser.UserID);
            if (InternationalLicense == null)
            {
                clsFormsUtility.MsgBoxActionFailed("Issued", "International license");
                return;
            }

            clsFormsUtility.MsgBoxActionSucceeded("Issued", "International license");

            lblInternationalLicenseAppID.Text = InternationalLicense.ApplicationID.ToString();
            lblInternationalLicenseID.Text = InternationalLicense.InternationalLicenseID.ToString();
            lblSerialNumber.Text = InternationalLicense.InternationalSerialNumber;
        }

        void frmIssueInternationalDrivingLicense_FormClosing(object sender, FormClosingEventArgs e)
        {
            CtrlLicenseCardWithFilter.LoadInfoInParent -= LoadInternationalDrivingLicenseApplicationInfo;
            CtrlLicenseCardWithFilter.ResetInfoInParent -= ResetInternationalDrivingLicenseApplicationInfo;
        }


        // Permissions checking !
        private void frmIssueInternationalDrivingLicense_Load(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions(clsUser.enPermissions.NewInternationalDrivingLicenseApplication)) this.Close();
        }
    }
}
