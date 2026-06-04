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

namespace DVLD.Tests.TestAppointments
{
    public partial class frmAddNewTestAppointment : Form
    {
        clsLocalDrivingLicenseApplication _LDLApp { get; set; } = null;
        clsTestType.enTestType _TestTypeID { get; set; }
        bool _IsRetakeTest = false;

        void ChangeTitleImage()
        {
            if (_LDLApp == null) return;
            if (_LDLApp.CurrentTestType != _TestTypeID) return;

            switch (_TestTypeID)
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
        bool IsRetakeTest(int Trials) // only to avoid DB call for trials
        {
            // if the test trials greater than 0, so the applicant will retake this test
            // if the test trials equal 0, and the test has appointments,
            // that means the test have not taken  (the sql job agent made the appointment locked bc the applicant have not came)

            if (Trials > 0) return true;
            if (_LDLApp.HasAppointmentsPerTestType(_TestTypeID)) return true;

            return false;
        }
        bool LoadTestAppointmentInfo()
        {
            if (_LDLApp == null) return false;

            lblLDLAppID.Text = _LDLApp.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = _LDLApp.LicenseClass.LicenseClassName;
            lblName.Text = _LDLApp.Person.FullName;

            int Trials = _LDLApp.GetTrialsPerCurrentTest(_TestTypeID);

            this._IsRetakeTest = IsRetakeTest(Trials);
            lblTrial.Text = Trials.ToString();

            DateTimePkrAppointmentDate.MinDate = DateTime.Today;
            DateTimePkrAppointmentDate.MaxDate = clsTestAppointment.MaxAppointmentDate;
            DateTimePkrAppointmentDate.Value = DateTimePkrAppointmentDate.MinDate;

            Decimal TestFees = clsTestType.Find(_TestTypeID).TestTypeFees;
            lblTestFees.Text = TestFees.ToString();

            Decimal RetakeTestFees = clsApplicationType.Find(clsApplicationType.enApplicationType.RetakeTest).ApplicationTypeFees;
            if (Trials == 0)
            {
                grpBoxRetakeTestInfo.Enabled = false;
                RetakeTestFees = 0;
            }

            lblRetakeTestFees.Text = RetakeTestFees.ToString();

            lblTotalFees.Text = (TestFees + RetakeTestFees).ToString();

            return true;
        }

        public frmAddNewTestAppointment(clsLocalDrivingLicenseApplication LDlApp, clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();

            this._LDLApp = LDlApp;
            this._TestTypeID = TestTypeID;

            ChangeTitleImage();
            LoadTestAppointmentInfo();
        }


        void btnClose_Click(object sender, EventArgs e) => this.Close();

        bool Save(out int RetakeTestApplicationID)
        {
            RetakeTestApplicationID = -1;

            if (_IsRetakeTest)
            {
                RetakeTestApplicationID = _LDLApp.ScheduleRetakeTest(this._TestTypeID, DateTimePkrAppointmentDate.Value, clsGlobal.CurrentUser.UserID);
                return (RetakeTestApplicationID != -1);
            }

            return (_LDLApp.ScheduleTest(this._TestTypeID, DateTimePkrAppointmentDate.Value, clsGlobal.CurrentUser.UserID));
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (_LDLApp == null) return;
            if (!clsFormsUtility.MsgBoxConfirm("Have you collected the Replacement fees?")) return;

            string TestName = (_TestTypeID == clsTestType.enTestType.VisionTest)
                              ? "Vision Test"
                              : (_TestTypeID == clsTestType.enTestType.WrittenTest)
                                        ? "Written Test"
                                        : "Practical Test";

            if (!Save(out int RetakeTestApplicationID))
            {
                clsFormsUtility.MsgBoxActionFailed("Adding", $"{TestName} Appointment");
                return;
            }   

            clsFormsUtility.MsgBoxActionSucceeded("Added", $"{TestName} Appointment");

            lblApplicationID.Text = (RetakeTestApplicationID != -1) 
                                    ? RetakeTestApplicationID.ToString() 
                                    : lblApplicationID.Text;

            btnSave.Enabled = false;
        }


        // Permissions checking !
        private void frmAddNewTestAppointment_Load(object sender, EventArgs e)
        {
            if (_IsRetakeTest)
            {
                if (!clsGlobal.HasPermissions(clsUser.enPermissions.RetakeTestApplication)) this.Close();
            }
        }
    }
}
