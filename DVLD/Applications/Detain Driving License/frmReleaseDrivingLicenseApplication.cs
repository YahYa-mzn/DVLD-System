using System;
using DVLD_BLL;
using System.Windows.Forms;
using DVLD.Global_Classes;

namespace DVLD.Applications.Detain_Driving_License
{
    public partial class frmReleaseDrivingLicenseApplication : Form
    {
        private clsLicense _License { get; set; } = null;
        private clsDetainedLicense _DetainedLicense { get; set; } = null;


        void LoadReleaseLicenseInfo()
        {
            _License = CtrlLicenseCardWithFilter.License;

            if (_License == null) return;

            if (!_License.IsDetained)
            {
                clsFormsUtility.MsgBoxError("This license is not detained.", "Not Allowed");
                CtrlLicenseCardWithFilter.Reset();
                return;
            }

            clsApplicationType ApplicationType = clsApplicationType.Find(clsApplicationType.enApplicationType.ReleaseDetainedDrivingLicense);

            _DetainedLicense = _License.FindDetainedLicense();

            lblDetainedLicenseID.Text = _DetainedLicense.DetainedLicenseID.ToString();
            lblLicenseID.Text = _DetainedLicense.LicenseID.ToString();
            lblDetainDate.Text = _DetainedLicense.DetainDate.ToString("g");
            lblFineFees.Text = _DetainedLicense.FineFees.ToString();
            lblReleaseApplicationID.Text = "N/A";
            txtBoxNotes.Text = _DetainedLicense.Notes;
            lblTotalFees.Text = (_DetainedLicense.FineFees + ApplicationType.ApplicationTypeFees).ToString();
        }
        void ResetReleaseLicenseInfo()
        {
            _License = null;
            _DetainedLicense = null;

            lblDetainedLicenseID.Text = "[????]";
            lblLicenseID.Text = "[????]";
            lblDetainDate.Text = "0000/00/00";
            lblReleaseApplicationID.Text = "N/A";
            lblFineFees.Text = "[????]";
            txtBoxNotes.Text = string.Empty;
            lblTotalFees.Text = "[????]";
        }

        void LoadDefaults()
        {
            clsApplicationType ApplicationType = clsApplicationType.Find(clsApplicationType.enApplicationType.ReleaseDetainedDrivingLicense);
            lblApplicationFees.Text = ApplicationType.ApplicationTypeFees.ToString();

            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName + $" [{clsGlobal.CurrentUser.Person.FullName}]";


            if (_License == null || _DetainedLicense == null)
            {
                lblDetainedLicenseID.Text = "[????]";
                lblLicenseID.Text = "[????]";
                lblDetainDate.Text = "0000/00/00";
                lblReleaseApplicationID.Text = "N/A";
                lblFineFees.Text = "[????]";
                txtBoxNotes.Text = string.Empty;
                lblTotalFees.Text = "[????]";

                CtrlLicenseCardWithFilter.LoadInfoInParent += LoadReleaseLicenseInfo;
                CtrlLicenseCardWithFilter.ResetInfoInParent += ResetReleaseLicenseInfo;
            }

            else
            {
                CtrlLicenseCardWithFilter.DisableSearching();
                CtrlLicenseCardWithFilter.LoadLicenseInfo(_License);

                lblDetainedLicenseID.Text = _DetainedLicense.DetainedLicenseID.ToString();
                lblLicenseID.Text = _DetainedLicense.LicenseID.ToString();
                lblDetainDate.Text = _DetainedLicense.DetainDate.ToString("g");
                lblFineFees.Text = _DetainedLicense.FineFees.ToString();
                txtBoxNotes.Text = _DetainedLicense.Notes;
                lblTotalFees.Text = (_DetainedLicense.FineFees + ApplicationType.ApplicationTypeFees).ToString();
            }
        }

        public frmReleaseDrivingLicenseApplication()
        {
            InitializeComponent();

            LoadDefaults();
        }
        public frmReleaseDrivingLicenseApplication(clsLicense License)
        {
            InitializeComponent();

            this._License = (License.IsDetained) 
                            ? License 
                            : null;

            this._DetainedLicense = (_License != null) 
                            ? _License.FindDetainedLicense() 
                            : null;

            LoadDefaults();
        }


        void btnClose_Click(object sender, EventArgs e) => this.Close();
        void btnRelease_Click(object sender, EventArgs e)
        {
            if (_License == null) return;

            if (!_License.IsDetained)
            {
                clsFormsUtility.MsgBoxExclamation("This license is not detained.", "Not Allowed");
                return;
            }

            if (!clsFormsUtility.MsgBoxConfirm("Have you collected the fees?")) return;

            if (!_License.Release(out int ReleaseApplicationID, clsGlobal.CurrentUser.UserID))
            {
                clsFormsUtility.MsgBoxActionFailed("releasing", "License");
                return;
            }

            clsFormsUtility.MsgBoxActionSucceeded("released", "License");
            lblReleaseApplicationID.Text = ReleaseApplicationID.ToString();
            CtrlLicenseCardWithFilter.CtrlLicenseCard.lblIsDetained.Text = "Not Detained";
        }

        void frmReleaseDrivingLicenseApplication_FormClosing(object sender, FormClosingEventArgs e)
        {
            CtrlLicenseCardWithFilter.LoadInfoInParent -= LoadReleaseLicenseInfo;
            CtrlLicenseCardWithFilter.ResetInfoInParent -= ResetReleaseLicenseInfo;
        }


        // Permissions checking !
        private void frmReleaseDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions(clsUser.enPermissions.ReleaseDrivingLicenseApplication)) this.Close();
        }
    }
}
