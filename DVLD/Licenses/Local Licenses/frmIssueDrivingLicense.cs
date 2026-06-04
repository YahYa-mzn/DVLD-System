using System;
using System.Windows.Forms;
using DVLD.Global_Classes;
using DVLD_BLL;

namespace DVLD.Licenses.Local_Licenses
{
    public partial class frmIssueDrivingLicense : Form
    {
        clsLocalDrivingLicenseApplication _LDLApp { get; set; } = null;


        void LoadDefaults()
        {
            if (_LDLApp == null) return;
            if (_LDLApp.ApplicationStatus != clsApplication.enApplicationStatus.New) return;
            if (!_LDLApp.IsPassedAllTests()) return;

            lblFees.Text = _LDLApp.LicenseClass.ClassFees.ToString();
        }

        public frmIssueDrivingLicense(clsLocalDrivingLicenseApplication LDLApp)
        {
            InitializeComponent();

            this._LDLApp = LDLApp;
            CtrlLocalDrivingLicenseApplicationCard1.LoadLocalDrivingLicenseApplicationInfo(_LDLApp);
            LoadDefaults();
        }

        void btnClose_Click(object sender, EventArgs e) => this.Close();
        void btnIssue_Click(object sender, EventArgs e)
        {
            if (_LDLApp == null) return;
            if (_LDLApp.ApplicationStatus != clsApplication.enApplicationStatus.New) return;
            if (!_LDLApp.IsPassedAllTests()) return;

            if (!clsFormsUtility.MsgBoxConfirm("Have you collected Issuing fees?")) return;

            clsLicense License = _LDLApp.IssueDrivingLicense(txtBoxNotes.Text, clsGlobal.CurrentUser.UserID);

            if (License != null)
            {
                clsFormsUtility.MsgBoxActionSucceeded("Issued", "Local driving license");
                lblLicenseID.Text = License.LicenseID.ToString();
                lblSerialNumber.Text = License.SerialNumber;

                btnIssue.Enabled = false;
                return;
            }

            clsFormsUtility.MsgBoxActionFailed("Issuing", "for this local driving license application");
        }
    }
}
