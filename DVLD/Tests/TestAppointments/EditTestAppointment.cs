using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Global_Classes;
using DVLD_BLL;

namespace DVLD.Tests.TestAppointments
{
    public partial class frmEditTestAppointment : Form
    {
        clsLocalDrivingLicenseApplication _LDLApp { get; set; } = null;
        clsTestAppointment _TestAppointment { get; set; } = null;


        void SetDateTimePickerValues()
        {
            DateTimePkrAppointmentDate.MinDate = (_TestAppointment.TestAppointmentDate >= DateTime.Today)
                                                 ? DateTime.Today
                                                 : _TestAppointment.TestAppointmentDate;

            DateTimePkrAppointmentDate.MaxDate = clsTestAppointment.MaxAppointmentDate;
            DateTimePkrAppointmentDate.Value = _TestAppointment.TestAppointmentDate;
        }
        bool LoadTestAppointmentInfo()
        {
            if (_LDLApp == null) return false;
            if (_TestAppointment == null) return false;

            lblLDLAppID.Text = _LDLApp.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = _LDLApp.LicenseClass.LicenseClassName;
            lblName.Text = _LDLApp.Person.FullName;
            lblLicenseClass.Text = _LDLApp.LicenseClass.LicenseClassName;
            lblTrial.Text = _LDLApp.GetTrialsPerCurrentTest(_TestAppointment.TestType.TestTypeID).ToString();

            SetDateTimePickerValues();

            DateTimePkrAppointmentDate.Enabled = !_TestAppointment.IsLocked;

            lblPaidFees.Text = _TestAppointment.PaidFees.ToString();
            lblRetakeTestApplicationID.Text = (_TestAppointment.RetakeTestApplicationID != -1)
                                              ? _TestAppointment.RetakeTestApplicationID.ToString()
                                              : lblRetakeTestApplicationID.Text;

            btnSave.Enabled = !_TestAppointment.IsLocked;

            return true;
        }

        public frmEditTestAppointment(clsLocalDrivingLicenseApplication LDLApp, clsTestAppointment TestAppointment)
        {
            InitializeComponent();

            this._LDLApp = LDLApp;
            this._TestAppointment = TestAppointment;
            LoadTestAppointmentInfo();
        }


        void btnClose_Click(object sender, EventArgs e) => this.Close();
        void btnSave_Click(object sender, EventArgs e)
        {
            if (_LDLApp == null) return;
            if (_TestAppointment == null) return;

            DateTime NewDateToSet = DateTimePkrAppointmentDate.Value.Date;

            if (!clsValidation.IsDateBetween(NewDateToSet, DateTime.Today, clsTestAppointment.MaxAppointmentDate))
            {
                clsFormsUtility.MsgBoxError("You cannot schedule an appointment in the past.\n" +
                                            "Please select a date that is today or later.",
                                            "Invalid Appointment Date");
                return;
            }



            if (_TestAppointment.UpdateTestAppointmentDate(DateTimePkrAppointmentDate.Value.Date))
            {
                clsFormsUtility.MsgBoxActionSucceeded("Updated", "test appointment");
                return;
            }

            clsFormsUtility.MsgBoxActionFailed("Updating", "test appointment");
        }
    }
}
