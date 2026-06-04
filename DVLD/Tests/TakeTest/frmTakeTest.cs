using System;
using System.Windows.Forms;
using DVLD.Global_Classes;
using DVLD_BLL;

namespace DVLD.Tests
{
    public partial class frmTakeTest : Form
    {
        clsLocalDrivingLicenseApplication _LDLApp { get; set; } = null;
        clsTestAppointment _TestAppointment { get; set; } = null;

        void ChangeTitleImage()
        {
            if (_LDLApp == null) return;
            if (_TestAppointment == null) return;
            if (_LDLApp.LocalDrivingLicenseApplicationID != _TestAppointment.LocalDrivingLicenseApplicationID) return;

            switch (_TestAppointment.TestType.TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    PicBoxTitleImage.ImageLocation = clsSettings.clsTests.VisionTestImagePath;
                    break;

                case clsTestType.enTestType.WrittenTest:
                    PicBoxTitleImage.ImageLocation = clsSettings.clsTests.WrittenTestImagePath;
                    break;

                case clsTestType.enTestType.PracticalTest:
                    PicBoxTitleImage.ImageLocation = clsSettings.clsTests.PracticalTestImagePath;
                    break;

                default:
                    break;
            }
        }
        bool LoadTestInfo()
        {
            if (_LDLApp == null) return false;
            if (_TestAppointment == null) return false;
            if (_LDLApp.LocalDrivingLicenseApplicationID != _TestAppointment.LocalDrivingLicenseApplicationID) return false;
            if (_LDLApp.IsTestPassed(_TestAppointment.TestType.TestTypeID)) return false;

            lblLDLAppID.Text = _LDLApp.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = _LDLApp.LicenseClass.LicenseClassName;
            lblName.Text = _LDLApp.Person.FullName;         
            lblTrial.Text = _LDLApp.GetTrialsPerCurrentTest(_TestAppointment.TestType.TestTypeID).ToString();
            lblAppointmentDate.Text = _TestAppointment.TestAppointmentDate.ToString("d");
            lblPaidFees.Text  = _TestAppointment.PaidFees.ToString();

            lblApplicationID.Text = (_TestAppointment.RetakeTestApplicationID != -1)
                                    ? _TestAppointment.RetakeTestApplicationID.ToString()
                                    : lblApplicationID.Text;

            btnSave.Enabled = !(_TestAppointment.IsLocked);

            return true;
        }

        public frmTakeTest(clsLocalDrivingLicenseApplication LDLApp, clsTestAppointment TestAppointment)
        {
            InitializeComponent();

            _LDLApp = LDLApp;
            _TestAppointment = TestAppointment;

            ChangeTitleImage();
            LoadTestInfo();
        }


        void btnClose_Click(object sender, EventArgs e) => this.Close();

        bool Save(out int TestID)
        {
            TestID = -1;
            bool TestResult = (RdBtnPass.Checked) ? true : false;

            TestID = _LDLApp.TakeTest(_TestAppointment, TestResult, txtBoxNotes.Text, clsGlobal.CurrentUser.UserID);
            return (TestID != -1);
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (_LDLApp == null) return;
            if (_TestAppointment == null) return;
            if (_LDLApp.LocalDrivingLicenseApplicationID != _TestAppointment.LocalDrivingLicenseApplicationID) return;
            if (_LDLApp.IsTestPassed(_TestAppointment.TestType.TestTypeID)) return;
            if (!clsFormsUtility.MsgBoxConfirm("Are you sure you want to save? \n After that you cannot change Pass/Fail.")) return;

            string TestName = (this._TestAppointment.TestType.TestTypeID == clsTestType.enTestType.VisionTest)
                              ? "Vision Test"
                              : (this._TestAppointment.TestType.TestTypeID == clsTestType.enTestType.WrittenTest)
                                        ? "Written Test"
                                        : "Practical Test";

            if (!Save(out int TestID))
            {
                clsFormsUtility.MsgBoxActionFailed("Test taking", $"{TestName} for this appointment");
                return;
            }

            clsFormsUtility.MsgBoxActionSucceeded("Taken", $"{TestName} for this appointment");
            lblTestID.Text = TestID.ToString();

            btnSave.Enabled = false;
            txtBoxNotes.ReadOnly = true;
        }
    }
}
