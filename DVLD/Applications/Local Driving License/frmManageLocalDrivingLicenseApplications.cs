using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Drivers;
using DVLD.Global_Classes;
using DVLD.Licenses.Local_Licenses;
using DVLD.Tests;
using DVLD_BLL;

namespace DVLD.Applications.Local_Driving_License
{
    public partial class frmManageLocalDrivingLicenseApplications : Form
    {
        enum enTSMIItems
        {
            ShowDetails = 1,
            ReactivateApplication = 2,
            CancelApplication = 3,
            DeleteApplication = 4,
            IssueDrivingLicense = 5,
            ShowLicense = 6,
            ShowPersonLicenseHistory = 7
        }
        enum enTSMIScheduleTakeTestItems
        {
            VisionTest = 1,
            WrittenTest = 2,
            PracticalTest = 3
        }

        private clsApplication.enReadMode _ReadMode { get; set; } = clsApplication.enReadMode.None;
        private clsLocalDrivingLicenseApplication.enFilterColumn _FilterColumn { get; set; } = clsLocalDrivingLicenseApplication.enFilterColumn.None;
        private clsFormsUtility.enInputType _InputType { get; set; } = clsFormsUtility.enInputType.None;

        string GetStatusImage(clsLocalDrivingLicenseApplication.enApplicationStatus ApplicationStatus)
        {
            switch (ApplicationStatus)
            {
                case clsApplication.enApplicationStatus.New:
                    return clsSettings.ImgPending;
                   
                case clsApplication.enApplicationStatus.Canceled:
                    return clsSettings.ImgFalse;

                case clsApplication.enApplicationStatus.Completed:
                    return clsSettings.ImgTrue;

                default:
                    return clsSettings.ImgFalse;
            }
        }
        void AddNewRow(DataRow Row)
        {
            clsLocalDrivingLicenseApplication.enApplicationStatus ApplicationStatus = (clsApplication.enApplicationStatus)Convert.ToInt32(Row["ApplicationStatus"]);

            DGVLocalDrivingLicenseApps.Rows.Add
                (
                    Row["LocalDrivingLicenseApplicationID"].ToString(),
                    Row["LicenseClassName"].ToString(),

                    string.Empty, //Separator

                    Row["NationalNo"].ToString(),

                    clsUtility.GetFullName(Row["FirstName"].ToString(), Row["SecondName"].ToString(),
                                           Row["ThirdName"].ToString(), Row["LastName"].ToString()),

                    string.Empty, //Separator

                    Row["ApplicationDate"].ToString(),
                    Row["PassedTests"].ToString(),
                    Image.FromFile(GetStatusImage(ApplicationStatus))
                );
        }
        async void RefreshLocalDrivingLicenseAppsList()
        {
            DGVLocalDrivingLicenseApps.Rows.Clear();
            DataTable DTLocalDrivingLicenseApps = new DataTable();

            DTLocalDrivingLicenseApps = (_FilterColumn == clsLocalDrivingLicenseApplication.enFilterColumn.LicenseClass)
                                        ? clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseAppsList(_ReadMode, _FilterColumn, CmbBoxLicenseClass.Text)
                                        : clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseAppsList(_ReadMode, _FilterColumn, txtBoxFilter.Text);

            await Task.Delay(30);

            foreach (DataRow Row in DTLocalDrivingLicenseApps.Rows)
                AddNewRow(Row);

            lblSystemRecords.Text = clsLocalDrivingLicenseApplication.GetSystemRecordsNumber(_ReadMode).ToString();
            lblRecords.Text = DTLocalDrivingLicenseApps.Rows.Count.ToString();
        }

        void LoadDefaults()
        {
            if (CmbBoxLicenseClass.Items.Count == 0)
            {
                DataTable DTLicenseClasses = clsLicenseClass.GetLicenseClassesList();

                foreach (DataRow Row in DTLicenseClasses.Rows)
                {
                    CmbBoxLicenseClass.Items.Add(Row["LicenseClassName"]);
                }

                CmbBoxLicenseClass.SelectedIndex = (CmbBoxLicenseClass.FindString(clsSettings.clsLicenseClasses.DefaultLicenseClassName) != -1)
                                                   ? CmbBoxLicenseClass.FindString(clsSettings.clsLicenseClasses.DefaultLicenseClassName)
                                                   : 0;
            }

            CmbBoxReadMode.SelectedIndex = CmbBoxReadMode.FindString("None");
            CmbBoxFilterBy.SelectedIndex = CmbBoxFilterBy.FindString("None");
        }

        public frmManageLocalDrivingLicenseApplications()
        {
            InitializeComponent();

            clsFormsUtility.SetDGVHeaderColor(DGVLocalDrivingLicenseApps, System.Drawing.Color.FromArgb(26, 45, 80));

            LoadDefaults();
        }


        void CmbBoxReadMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ReadMode = (clsApplication.enReadMode)CmbBoxReadMode.SelectedIndex;

            RefreshLocalDrivingLicenseAppsList();
        }
        void CmbBoxFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterColumn = (clsLocalDrivingLicenseApplication.enFilterColumn)CmbBoxFilterBy.SelectedIndex;

            txtBoxFilter.TextChanged -= txtBoxFilter_TextChanged;
            txtBoxFilter.Clear();
            txtBoxFilter.TextChanged += txtBoxFilter_TextChanged;

            CmbBoxLicenseClass.Hide();

            switch (_FilterColumn)
            {
                case clsLocalDrivingLicenseApplication.enFilterColumn.None:
                    _InputType = clsFormsUtility.enInputType.None;
                    txtBoxFilter.Show();
                    txtBoxFilter.Enabled = false;
                    break;

                case clsLocalDrivingLicenseApplication.enFilterColumn.LDLAppID:
                    _InputType = clsFormsUtility.enInputType.Numbers;
                    txtBoxFilter.Show();
                    txtBoxFilter.Enabled = true;
                    break;

                case clsLocalDrivingLicenseApplication.enFilterColumn.NationalNo:
                    _InputType = clsFormsUtility.enInputType.LettersAndNumbers;
                    txtBoxFilter.Show();
                    txtBoxFilter.Enabled = true;
                    break;

                case clsLocalDrivingLicenseApplication.enFilterColumn.LicenseClass:
                    txtBoxFilter.Hide();
                    CmbBoxLicenseClass.Show();
                    CmbBoxLicenseClass.SelectedIndex = CmbBoxLicenseClass.SelectedIndex = (CmbBoxLicenseClass.FindString(clsSettings.clsLicenseClasses.DefaultLicenseClassName) != -1)
                                                       ? CmbBoxLicenseClass.FindString(clsSettings.clsLicenseClasses.DefaultLicenseClassName)
                                                       : 0;
                    break;

                default:
                    break;
            }

            RefreshLocalDrivingLicenseAppsList();
        }

        void txtBoxFilter_KeyPress(object sender, KeyPressEventArgs e) => clsFormsUtility.txtBox_KeyPress(sender, e, _InputType);
        void txtBoxFilter_TextChanged(object sender, EventArgs e) => RefreshLocalDrivingLicenseAppsList();
        void PicBoxRefresh_Click(object sender, EventArgs e) => RefreshLocalDrivingLicenseAppsList();
        void CmbBoxLicenseClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbBoxLicenseClass.Visible)
                RefreshLocalDrivingLicenseAppsList();
        }

        void btnClose_Click(object sender, EventArgs e) => this.Close();


        void btnAddNewLocalDrivingLicenseApp_Click(object sender, EventArgs e)
        {
            frmAddNewLocalDrivingLicenseApplication frm = new frmAddNewLocalDrivingLicenseApplication();
            frm.ShowDialog();

            RefreshLocalDrivingLicenseAppsList();
        }

        void ShowDetailsForm(clsLocalDrivingLicenseApplication LDLApp)
        {
            if (LDLApp == null) return;

            frmLocalDrivingLicenseApplicationInfo frm = new frmLocalDrivingLicenseApplicationInfo(LDLApp);
            frm.ShowDialog();
        }

        void Reactivate(clsLocalDrivingLicenseApplication LDLApp)
        {
            if (LDLApp == null)
            {
                clsFormsUtility.MsgBoxError("The Selected local driving Application does not exist in the System. \t", "Not Found");
                return;
            }


            clsApplicationType ApplicationType = clsApplicationType.Find(clsApplicationType.enApplicationType.ReactivateLocalDrivingLicenseApplication);

            bool WantToReactivateApplication = clsFormsUtility.MsgBoxConfirm($"Reactivating Fees are: {ApplicationType.ApplicationTypeFees} \t\n" +
                                                                              "Have you collected reactivating fees? ");

            if (!WantToReactivateApplication) return;


            if (!LDLApp.ReactivateApplication(clsGlobal.CurrentUser.UserID))
            {
                clsFormsUtility.MsgBoxActionFailed("Reactivating", $"Local driving license application");
                return;
            }

            clsFormsUtility.MsgBoxActionSucceeded("Reactivated", $"Local driving license application");
        }
        void Cancel(clsLocalDrivingLicenseApplication LDLApp)
        {
            if (LDLApp == null)
            {
                clsFormsUtility.MsgBoxError("The Selected local driving Application does not exist in the System. \t", "Not Found");
                return;
            }

            if (!LDLApp.CancelApplication())
            {
                clsFormsUtility.MsgBoxActionFailed("Canceling", $"Local driving license application");
                return;
            }

            clsFormsUtility.MsgBoxActionSucceeded("Canceled", $"Local driving license application");
        }
        void Delete(clsLocalDrivingLicenseApplication LDLApp)
        {
            if (LDLApp == null)
            {
                clsFormsUtility.MsgBoxError("The Selected local driving Application does not exist in the System. \t", "Not Found");
                return;
            }

            int LDLAppID = LDLApp.ApplicationID;

            LDLApp.PrepareObjectToDelete();

            if (!LDLApp.Delete())
            {
                clsFormsUtility.MsgBoxActionFailed("Deleting", $"Local driving license Application");
                return;
            }

            clsFormsUtility.MsgBoxActionSucceeded("Deleted", $"Local driving license Application");
        }

        void IssueDrivingLicense(clsLocalDrivingLicenseApplication LDLApp)
        {
            if (LDLApp == null) return;
            if (LDLApp.ApplicationStatus != clsApplication.enApplicationStatus.New) return;
            if (!LDLApp.IsPassedAllTests()) return;

            frmIssueDrivingLicense frm = new frmIssueDrivingLicense(LDLApp);
            frm.ShowDialog();
        }
        void ShowLicense(clsLocalDrivingLicenseApplication LDLApp)
        {
            if (LDLApp == null) return;
            if (!LDLApp.IsPassedAllTests() || LDLApp.ApplicationStatus != clsApplication.enApplicationStatus.Completed) return;

            clsLicense License = clsLicense.FindByApplicationID(LDLApp.ApplicationID);
            if (License == null) return;

            frmLicenseInfo frm = new frmLicenseInfo(License);
            frm.ShowDialog();
        }
        void ShowPersonLicenseHistory(clsLocalDrivingLicenseApplication LDLApp)
        {
            if (LDLApp == null) return;
            clsDriver Driver = clsDriver.FindByPersonID(LDLApp.Person.PersonID);

            if (Driver == null)
            {
                clsFormsUtility.MsgBoxError("This applicant is not a driver yet. \t", "Not Allowed");
                return;
            }

            frmDriverLicenseHistory frm = new frmDriverLicenseHistory(Driver);
            frm.ShowDialog();
        }


        clsLocalDrivingLicenseApplication GetLDLAppFromSelectedLDLApp()
        {
            if (DGVLocalDrivingLicenseApps.SelectedCells.Count >= 1)
            {
                DataGridViewRow row = DGVLocalDrivingLicenseApps.SelectedCells[0].OwningRow;
                return clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(Convert.ToInt32(row.Cells["colLDAppID"].Value));
            }

            return null;
        }
        void SetScheduleTestsItemsForSelectedLDLApp(clsLocalDrivingLicenseApplication LDLApp)
        {
            if (LDLApp.PassedTests == 3) //if passed all tests
            {
                TSMISchedualeTests.Enabled = false;
                return;
            }

            TSMISchedualeTests.Enabled = true;

            switch (LDLApp.CurrentTestType)
            {
                case clsTestType.enTestType.VisionTest:
                    TSMIScheduleTests_VisionTest.Enabled = true;
                    TSMIScheduleTests_WrittenTest.Enabled = false;
                    TSMIScheduleTests_PracticalTest.Enabled = false;
                    break;

                case clsTestType.enTestType.WrittenTest:
                    TSMIScheduleTests_VisionTest.Enabled = false;
                    TSMIScheduleTests_WrittenTest.Enabled = true;
                    TSMIScheduleTests_PracticalTest.Enabled = false;
                    break;

                case clsTestType.enTestType.PracticalTest:
                    TSMIScheduleTests_VisionTest.Enabled = false;
                    TSMIScheduleTests_WrittenTest.Enabled = false;
                    TSMIScheduleTests_PracticalTest.Enabled = true;
                    break;

                default:
                    TSMISchedualeTests.Enabled = false;
                    break;
            }

            //TSMIIssueDrivingLicense.Enabled = true; // check if the license issued or not...
        }
        void SetAvailableItemsForPassedTestsLDLApp()
        {
            TSMICancelApplication.Enabled = false;
            TSMIDeleteApplication.Enabled = false;
            TSMISchedualeTests.Enabled = false;
            TSMIIssueDrivingLicense.Enabled = true;
            return;
        }
        void SetAvailableItemsForSelectedLDLApp(clsLocalDrivingLicenseApplication LDLApp)
        {
            if (LDLApp == null) return;

            switch (LDLApp.ApplicationStatus)
            {
                case clsLocalDrivingLicenseApplication.enApplicationStatus.New:
                    if (LDLApp.IsPassedAllTests())
                    {
                        SetAvailableItemsForPassedTestsLDLApp();
                        TSMIShowLicense.Enabled = false;
                        return;
                    }

                    TSMIReactivateApplication.Enabled = false;
                    TSMICancelApplication.Enabled = true;
                    TSMIDeleteApplication.Enabled = true;
                    TSMISchedualeTests.Enabled = true;
                    SetScheduleTestsItemsForSelectedLDLApp(LDLApp); // sets the current and available test for the applicant
                    TSMIIssueDrivingLicense.Enabled = false;
                    TSMIShowLicense.Enabled = false;
                    break;

                case clsLocalDrivingLicenseApplication.enApplicationStatus.Canceled:
                    TSMIReactivateApplication.Enabled = true;
                    TSMICancelApplication.Enabled = false;
                    TSMIDeleteApplication.Enabled = true;
                    TSMISchedualeTests.Enabled = false;
                    TSMIIssueDrivingLicense.Enabled = false;
                    TSMIShowLicense.Enabled = false;
                    break;

                case clsLocalDrivingLicenseApplication.enApplicationStatus.Completed:
                    TSMIReactivateApplication.Enabled = false;
                    TSMICancelApplication.Enabled = false;
                    TSMIDeleteApplication.Enabled = false;
                    TSMISchedualeTests.Enabled = false;
                    TSMIIssueDrivingLicense.Enabled = false;
                    TSMIShowLicense.Enabled = true;
                    break;

                default:
                    break;
            }
        }

        // Shows context menu when right-clicking a row
        void DGVLocalDrivingLicenseApps_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                DGVLocalDrivingLicenseApps.ClearSelection();
                DGVLocalDrivingLicenseApps.Rows[e.RowIndex].Selected = true;

                DGVLocalDrivingLicenseApps.Tag = e.RowIndex;

                CMSLocalDrivingLicenseApp.Show(Cursor.Position);
            }


        }

        // Shows context menu on double-click
        void DGVLocalDrivingLicenseApps_CellDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DGVLocalDrivingLicenseApps.ClearSelection();
                DGVLocalDrivingLicenseApps.Rows[e.RowIndex].Selected = true;

                DGVLocalDrivingLicenseApps.Tag = e.RowIndex;

                CMSLocalDrivingLicenseApp.Show(Cursor.Position);
            }
        }

        // Sets the available items in the context menu strip 
        void CMSLocalDrivingLicenseApp_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            clsLocalDrivingLicenseApplication LDLApp = GetLDLAppFromSelectedLDLApp();

            SetAvailableItemsForSelectedLDLApp(LDLApp);
        }

        void TSMI_Click(object sender, EventArgs e)
        {
            enTSMIItems enumTag = clsFormsUtility.GetEnumType_TSMI<enTSMIItems>(sender);
            clsLocalDrivingLicenseApplication LDLApp = GetLDLAppFromSelectedLDLApp();

            switch (enumTag)
            {
                case enTSMIItems.ShowDetails:
                    ShowDetailsForm(LDLApp);
                    break;

                case enTSMIItems.ReactivateApplication:
                    Reactivate(LDLApp);
                    break;

                case enTSMIItems.CancelApplication:
                    Cancel(LDLApp);
                    break;

                case enTSMIItems.DeleteApplication:
                    Delete(LDLApp);
                    break;

                case enTSMIItems.IssueDrivingLicense:
                    IssueDrivingLicense(LDLApp);
                    break;

                case enTSMIItems.ShowLicense:
                    ShowLicense(LDLApp);
                    break;

                case enTSMIItems.ShowPersonLicenseHistory:
                    ShowPersonLicenseHistory(LDLApp);
                    break;
            }

            RefreshLocalDrivingLicenseAppsList();
        }
        void TSMISchedule_TakeTest_Click(object sender, EventArgs e)
        {
            enTSMIScheduleTakeTestItems enumTag = clsFormsUtility.GetEnumType_TSMI<enTSMIScheduleTakeTestItems>(sender);

            clsLocalDrivingLicenseApplication LDLApp = GetLDLAppFromSelectedLDLApp();

            switch (enumTag)
            {
                case enTSMIScheduleTakeTestItems.VisionTest:
                    if (LDLApp.CurrentTestType == clsTestType.enTestType.VisionTest)
                    {
                        frmScheduleTest frm1 = new frmScheduleTest(LDLApp, LDLApp.CurrentTestType);
                        frm1.ShowDialog();
                    }
                    break;

                case enTSMIScheduleTakeTestItems.WrittenTest:
                    if (LDLApp.CurrentTestType == clsTestType.enTestType.WrittenTest)
                    {
                        frmScheduleTest frm2 = new frmScheduleTest(LDLApp, LDLApp.CurrentTestType);
                        frm2.ShowDialog();
                    }
                    break;

                case enTSMIScheduleTakeTestItems.PracticalTest:
                    if (LDLApp.CurrentTestType == clsTestType.enTestType.PracticalTest)
                    {
                        frmScheduleTest frm3 = new frmScheduleTest(LDLApp, LDLApp.CurrentTestType);
                        frm3.ShowDialog();
                    }
                    break;
            }

            RefreshLocalDrivingLicenseAppsList();
        }


        // Permissions checking !
        private void frmManageLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions(clsUser.enPermissions.LocalDrivingLicenseApplicationsManagement)) this.Close();
        }
    }
}
