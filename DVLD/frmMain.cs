// Form: Main Application Window
// Central hub after successful login
// Provides menu access to all system features:
//   - People management
//   - User management
//   - Account settings (current user info, change password, sign out)
//   - Applications (driving licenses, tests, detentions)
//   - Drivers
// Automatically signs out user when closing
// Maximized on startup

using System;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Applications.ApplicationTypes;
using DVLD.Applications.Detain_Driving_License;
using DVLD.Applications.International_Driving_License;
using DVLD.Applications.Local_Driving_License;
using DVLD.Applications.Renew_Driving_License;
using DVLD.Applications.Replacement_for_Lost_or_Damaged;
using DVLD.Drivers;
using DVLD.Global_Classes;
using DVLD.Licenses.Detained_Licenses;
using DVLD.Licenses.International_Licenses;
using DVLD.Tests.TestAppointments;
using DVLD.Tests.TestTypes;
using DVLD.Users;
using DVLD.Users.LoginRegister;
using DVLD.Users.Users;
using DVLD_BLL;


namespace DVLD
{
    public partial class frmMain : Form
    {
        frmLogin _LoginForm;

        async void ShowLabels()
        {
            lblActiveLicenses.Visible = false;
            lblExpiredLicenses.Visible = false;
            lblDetainedLicenses.Visible = false;
            lblPendingApplications.Visible = false;
            lblInternationalLicenses.Visible = false;
            lblTodaysTestAppointments.Visible = false;

            await Task.Delay(100);

            lblActiveLicenses.Visible = true;
            lblExpiredLicenses.Visible = true;
            lblDetainedLicenses.Visible = true;
            lblPendingApplications.Visible = true;
            lblInternationalLicenses.Visible = true;
            lblTodaysTestAppointments.Visible = true;
        }
        void RefreshDate()
        {
            lblDateNow.Text = DateTime.Now.ToString("yyyy MMMM, dd HH:mm tt");
        }
        void RefreshForm()
        {
            lblActiveLicenses.Text = clsLicense.GetActiveLicensesSystemRecordsNumber().ToString();
            lblExpiredLicenses.Text = clsLicense.GetExpiredLicensesRecordsNumber().ToString();
            lblDetainedLicenses.Text = clsDetainedLicense.GetSystemRecordsNumber(clsDetainedLicense.enReadMode.Detained).ToString();
            lblPendingApplications.Text = clsLocalDrivingLicenseApplication.GetSystemRecordsNumber(clsApplication.enReadMode.New).ToString();
            lblInternationalLicenses.Text = clsInternationalLicense.GetSystemRecordsNumber().ToString();
            lblTodaysTestAppointments.Text = clsTestAppointment.GetTodaysTestAppointmentsSystemRecordsNumber().ToString();

            ShowLabels();

            lblWelcoming.Text = clsGlobal.CurrentUser.Person.FullName;
            lblUserName.Text = clsGlobal.CurrentUser.UserName + $" [{clsGlobal.CurrentUser.StrRole}] ";

            RefreshDate();
        }

        public frmMain(frmLogin LoginForm)
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this._LoginForm = LoginForm;

            RefreshForm();
        }

        
        
        // Main menu items
        enum enTSMI
        {
            AccountSettings_CurrentUserInfo = 1,
            AccountSettings_ChangePassword = 2,
            AccountSettings_SignOut = 3,
            Users_View = 4,
            Users_LoginRegister = 5,
            People = 6,
            Drivers = 7,
        }
        enum enTSMIApplications
        {
            ManageLocalDrivingLicenseApplications = 1,
            ManageInternationalDrivingLicenseApplications = 2,
            TodaysTestAppointments = 3,
            ManageDetainedLicenses = 4,
            DetainLicense = 5,
            ReleaseDetainedLicense = 6,
            ManageApplicationTypes = 7,
            ManageTestTypes = 8
        }
        enum enTSMIApplications_DrivingLicenseServices
        {
            NewLocalDrivingLicense = 1,
            NewInternationalDrivingLicense = 2,
            RetakeTest = 3,
            RenewDrivingLicense = 4,
            ReplacementForLostOrDamagedLicense = 5,
            ReleaseDetainedDrivingLicense = 6
        }

        // Handles main menu clicks
        void TSMI_Click(object sender, EventArgs e)
        {
            enTSMI enumTag = clsFormsUtility.GetEnumType_TSMI<enTSMI>(sender);

            switch (enumTag)
            {
                case enTSMI.AccountSettings_CurrentUserInfo:
                    frmUserInfo frm1 = new frmUserInfo(clsGlobal.CurrentUser);
                    frm1.ShowDialog();
                    break;

                case enTSMI.AccountSettings_ChangePassword:
                    frmChangePassword frm2 = new frmChangePassword(clsGlobal.CurrentUser);
                    frm2.ShowDialog();
                    break;

                case enTSMI.AccountSettings_SignOut:
                    if (clsGlobal.SignOut())
                    {
                        _LoginForm.Show();
                        this.Close();
                        break;
                    }
                    _LoginForm.Close();
                    this.Close();
                    break;

                case enTSMI.Users_View:
                    frmManageUsers frm3 = new frmManageUsers();
                    frm3.ShowDialog();
                    break;

                case enTSMI.Users_LoginRegister:
                    frmLoginRegister frm4 = new frmLoginRegister();
                    frm4.ShowDialog();
                    break;

                case enTSMI.People:
                    frmManagePeople frm5 = new frmManagePeople();
                    frm5.ShowDialog();
                    break;

                case enTSMI.Drivers:
                    frmManageDrivers frm6 = new frmManageDrivers();
                    frm6.ShowDialog();
                    break;

                default:
                    break;
            }

            // No need to refresh here, no operation will affect the dashboard...
            RefreshDate();
        }

        void TSMIApplications_Click(object sender, EventArgs e)
        {
            enTSMIApplications enumTag = clsFormsUtility.GetEnumType_TSMI<enTSMIApplications>(sender);

            switch (enumTag)
            {
                case enTSMIApplications.ManageLocalDrivingLicenseApplications:
                    frmManageLocalDrivingLicenseApplications frm1 = new frmManageLocalDrivingLicenseApplications();
                    frm1.ShowDialog();
                    break;

                case enTSMIApplications.ManageInternationalDrivingLicenseApplications:
                    frmManageInternationalDrivingLicenseApplication frm2 = new frmManageInternationalDrivingLicenseApplication();
                    frm2.ShowDialog();
                    break;

                case enTSMIApplications.TodaysTestAppointments:
                    frmTodaysTestAppointments frm3 = new frmTodaysTestAppointments();
                    frm3.ShowDialog();
                    break;

                case enTSMIApplications.ManageDetainedLicenses:
                    frmManageDetainedDrivingLicenseApplication frm4 = new frmManageDetainedDrivingLicenseApplication();
                    frm4.ShowDialog();
                    break;

                case enTSMIApplications.DetainLicense:
                    frmDetainLicense frm5 = new frmDetainLicense();
                    frm5.ShowDialog();
                    break;

                case enTSMIApplications.ReleaseDetainedLicense:
                    frmReleaseDrivingLicenseApplication frm6 = new frmReleaseDrivingLicenseApplication();
                    frm6.ShowDialog();
                    break;

                case enTSMIApplications.ManageApplicationTypes:
                    frmManageApplicationTypes frm7 = new frmManageApplicationTypes();
                    frm7.ShowDialog();
                    break;

                case enTSMIApplications.ManageTestTypes:
                    frmManageTestTypes frm8 = new frmManageTestTypes();
                    frm8.ShowDialog();
                    break;

                default:
                    break;
            }

            RefreshForm();
            this.Refresh();
        }
        void TSMIApplications_DrivingLicensesServices_Click(object sender, EventArgs e)
        {
            enTSMIApplications_DrivingLicenseServices enumTag = clsFormsUtility.GetEnumType_TSMI<enTSMIApplications_DrivingLicenseServices>(sender);

            switch (enumTag)
            {
                case enTSMIApplications_DrivingLicenseServices.NewLocalDrivingLicense:
                    frmAddNewLocalDrivingLicenseApplication frm1 = new frmAddNewLocalDrivingLicenseApplication();
                    frm1.ShowDialog();
                    break;

                case enTSMIApplications_DrivingLicenseServices.NewInternationalDrivingLicense:
                    frmIssueInternationalDrivingLicense frm2 = new frmIssueInternationalDrivingLicense();
                    frm2.ShowDialog();
                    break;

                case enTSMIApplications_DrivingLicenseServices.RetakeTest:
                    MessageBox.Show("RetakeTest form");
                    break;

                case enTSMIApplications_DrivingLicenseServices.RenewDrivingLicense:
                    frmRenewDrivingLicenseApplication frm4 = new frmRenewDrivingLicenseApplication();
                    frm4.ShowDialog();
                    break;

                case enTSMIApplications_DrivingLicenseServices.ReplacementForLostOrDamagedLicense:
                    frmReplacementForLostOrDamaged frm5 = new frmReplacementForLostOrDamaged();
                    frm5.ShowDialog();
                    break;

                case enTSMIApplications_DrivingLicenseServices.ReleaseDetainedDrivingLicense:
                    frmReleaseDrivingLicenseApplication frm6 = new frmReleaseDrivingLicenseApplication();
                    frm6.ShowDialog();
                    break;

                default:
                    break;
            }

            this.Refresh();
            RefreshForm();
        }


        // Signs out user when form is closing
        void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (clsGlobal.CurrentUser == null)
                return;

            clsGlobal.SignOut();
            _LoginForm.Close();
        }
        void btnRefresh_Click(object sender, EventArgs e) => RefreshForm();


    }
}