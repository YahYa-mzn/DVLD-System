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
using DVLD.People;
using DVLD_BLL;

namespace DVLD.Applications.Controls
{
    public partial class ctrlLocalDrivingLicenseApplicationCard : UserControl
    {
        private clsLocalDrivingLicenseApplication _LDLApp { get; set; } = null;

        public ctrlLocalDrivingLicenseApplicationCard()
        {
            InitializeComponent();
        }


        public bool LoadLocalDrivingLicenseApplicationInfo(clsLocalDrivingLicenseApplication LDLApp)
        {
            if (LDLApp == null)
            {
                clsFormsUtility.MsgBoxError("The Local driving license Application does not exist in the System. \t", "Not Found");
                LinkLblViewPersonInfo.Enabled = false;
                return false;
            }

            _LDLApp = LDLApp;

            // Basic Application Info
            lblApplicationID.Text = _LDLApp.ApplicationID.ToString();
            lblApplicantFullName.Text = _LDLApp.Person.FullName;
            lblStatus.Text = _LDLApp.ApplicationStatus.ToString();
            lblPaidFees.Text = _LDLApp.PaidFees.ToString();
            lblApplicationType.Text = _LDLApp.ApplicationType.ApplicationTypeTitle;
            lblApplicationDate.Text = _LDLApp.ApplicationDate.ToString();
            lblStatusModificationDate.Text = (_LDLApp.StatusModificationDate == default(DateTime)) 
                                              ? "[Not modified yet]"
                                              : _LDLApp.StatusModificationDate.ToString();
            lblCreatedBy.Text = (clsUser.FindByUserID(_LDLApp.CreatedByUserID)).UserName;

            // Local Driving License Application Info
            lblLDLAppID.Text = _LDLApp.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = _LDLApp.LicenseClass.LicenseClassName;
            lblPassedTests.Text = _LDLApp.PassedTests.ToString() + "/3";

            return true;
        }

        void LinkLblViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_LDLApp == null || _LDLApp.Person == null) return;
            
            frmPersonInfo frm = new frmPersonInfo(_LDLApp.Person);
            frm.ShowDialog();

            // Incase the FullName changed !
            // No need to recall the LoadLocalDrivingLicenseApplicationInfo method
            // bc the full name is the only info that is related to the person !
            lblApplicantFullName.Text = _LDLApp.Person.FullName;
        }
    }
}
