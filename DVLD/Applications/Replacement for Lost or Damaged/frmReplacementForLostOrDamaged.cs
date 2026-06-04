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
using DVLD.Licenses.Controls;
using DVLD_BLL;

namespace DVLD.Applications.Replacement_for_Lost_or_Damaged
{
    public partial class frmReplacementForLostOrDamaged : Form
    {
        private clsLicense _OldLicense { get; set; } = null;

        void LoadReplaceDrivingLicenseApplicationInfo()
        {
            _OldLicense = CtrlLicenseCardWithFilter.License;

            if (_OldLicense == null)
                return;

            clsApplicationType.enApplicationType Type = (rdBtnDamaged.Checked) 
                                                        ? clsApplicationType.enApplicationType.ReplacementForDamagedDrivingLicense
                                                        : clsApplicationType.enApplicationType.ReplacementForLostDrivingLicense;

            clsApplicationType ApplicationType = clsApplicationType.Find(Type);

            lblReplacementDrivingLicenseAppID.Text = "N/A";
            lblReplacedLicenseID.Text = "N/A";
            lblReplacedSerialNumber.Text = "N/A";

            lblOldLicenseID.Text = _OldLicense.LicenseID.ToString();
            lblIssueDate.Text = DateTime.Today.ToString("d");
            lblExpirationDate.Text = _OldLicense.LicenseClass.ExpirationDate.ToString("d");

            lblApplicationFees.Text = ApplicationType.ApplicationTypeFees.ToString();
            lblClassFees.Text = _OldLicense.LicenseClass.ClassFees.ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName + $" [{clsGlobal.CurrentUser.Person.FullName}]";

            txtBoxNotes.Clear();

            lblTotalFees.Text = (ApplicationType.ApplicationTypeFees + _OldLicense.LicenseClass.ClassFees).ToString();     
        }
        void ResetReplaceDrivingLicenseApplicationInfo()
        {
            lblReplacementDrivingLicenseAppID.Text = "N/A";
            lblReplacedLicenseID.Text = "N/A";
            lblReplacedSerialNumber.Text = "N/A";

            lblOldLicenseID.Text = "[????]";
            lblIssueDate.Text = DateTime.Today.ToString("d");
            lblExpirationDate.Text = "0000/00/00";
            lblClassFees.Text = "[????]";

            txtBoxNotes.Clear();

            lblTotalFees.Text = "[????]";
        }

        void LoadDefaults()
        {
            rdBtnDamaged.Checked = true;   // this will call rdBtn_CheckedChanged method

            // Setting today s date:
            lblIssueDate.Text = DateTime.Today.ToString("d");

            CtrlLicenseCardWithFilter.LoadInfoInParent += LoadReplaceDrivingLicenseApplicationInfo;
            CtrlLicenseCardWithFilter.ResetInfoInParent += ResetReplaceDrivingLicenseApplicationInfo;
        }

        public frmReplacementForLostOrDamaged()
        {
            InitializeComponent();

            LoadDefaults();
        }


        void rdBtn_CheckedChanged(object sender, EventArgs e)
        {
            _OldLicense = CtrlLicenseCardWithFilter.License;

            clsApplicationType.enApplicationType Type = (rdBtnDamaged.Checked)
                                                        ? clsApplicationType.enApplicationType.ReplacementForDamagedDrivingLicense
                                                        : clsApplicationType.enApplicationType.ReplacementForLostDrivingLicense;

            clsApplicationType ApplicationType = clsApplicationType.Find(Type);
            lblApplicationFees.Text = ApplicationType.ApplicationTypeFees.ToString();

            lblTotalFees.Text = (_OldLicense != null) 
                                ? (ApplicationType.ApplicationTypeFees + _OldLicense.LicenseClass.ClassFees).ToString()
                                : "[????]";
        }

        void btnClose_Click(object sender, EventArgs e) => this.Close();
        void btnIssue_Click(object sender, EventArgs e)
        {
            _OldLicense = CtrlLicenseCardWithFilter.License;

            if (_OldLicense == null) return;
            if (_OldLicense.IsDetained)
            {
                clsFormsUtility.MsgBoxError("Cannot Replace a detained license. \n" +
                                                  "Please release this license to replace it.", "Not Allowed");
                return;
            }
            if (!_OldLicense.IsActive)
            {
                clsFormsUtility.MsgBoxError("Cannot Replace an inactive license.", "Inactive license");
                return;
            }

            clsLicense.enReplacementType ReplacementType = (rdBtnDamaged.Checked)
                                                           ? clsLicense.enReplacementType.Damaged
                                                           : clsLicense.enReplacementType.Lost;

            if (ReplacementType == clsLicense.enReplacementType.Damaged)
                if (!clsFormsUtility.MsgBoxConfirm("Have you collected the damaged license? \t"))
                    return;

            if (!clsFormsUtility.MsgBoxConfirm("Have you collected the Replacement fees?")) return;



            clsLicense ReplacedLicense = _OldLicense.ReplacementDrivingLicense(out int ReplaceLicenseApplicationID, ReplacementType, txtBoxNotes.Text.Trim(), clsGlobal.CurrentUser.UserID);
            if (ReplacedLicense == null)
            {
                clsFormsUtility.MsgBoxActionFailed("Replacing", "Selected license");
                return;
            }

            lblReplacementDrivingLicenseAppID.Text = ReplaceLicenseApplicationID.ToString();
            lblReplacedLicenseID.Text = ReplacedLicense.LicenseID.ToString();
            lblReplacedSerialNumber.Text = ReplacedLicense.SerialNumber;

            CtrlLicenseCardWithFilter.CtrlLicenseCard.lblIsActive.Text = "Inactive";

            clsFormsUtility.MsgBoxActionSucceeded("Replaced", "Lost/Damaged license");
        }

        void frmReplacementDrivingLicenseApplication_FormClosing(object sender, FormClosingEventArgs e)
        {
            CtrlLicenseCardWithFilter.LoadInfoInParent -= LoadReplaceDrivingLicenseApplicationInfo;
            CtrlLicenseCardWithFilter.ResetInfoInParent -= ResetReplaceDrivingLicenseApplicationInfo;
        }


        // Permissions checking !
        private void frmReplacementForLostOrDamaged_Load(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions(clsUser.enPermissions.ReplacementForLostOrDamagedLicenseApplication)) this.Close();
        }
    }
}
