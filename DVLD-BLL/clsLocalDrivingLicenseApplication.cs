using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DVLD_DAL;
using static DVLD_BLL.clsApplication;
using static DVLD_BLL.clsTestType;

namespace DVLD_BLL
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {     
        public enum enFilterColumn
        {
            None = 0,
            LDLAppID = 1,
            NationalNo = 2,
            LicenseClass = 3
        }

        public int LocalDrivingLicenseApplicationID { get; private set; }
        public clsLicenseClass LicenseClass { get; private set; }
        public int PassedTests { get; private set; }

        public clsTestType.enTestType CurrentTestType
        {
            get { return (PassedTests == 0) 
                           ? clsTestType.enTestType.VisionTest 
                           : (PassedTests == 1)  
                               ? enTestType.WrittenTest 
                               : enTestType.PracticalTest; }
        }


        private static clsLocalDrivingLicenseApplication _Convert_LDLAppDTO_To_clsLDLApp(clsLocalDrivingLicenseApplicationDAL.clsLocalDrivingLicenseApplicationDTO LocalDrivingLicenseApplicationDTO)
        {
            if (LocalDrivingLicenseApplicationDTO == null) return null;

            return new clsLocalDrivingLicenseApplication(_Convert_clsApplicationDTO_To_clsApplication(LocalDrivingLicenseApplicationDTO.ApplicationDTO),
                                                         LocalDrivingLicenseApplicationDTO.LocalDrivingLicenseApplicationID,
                                                         clsLicenseClass.Find((clsLicenseClass.enLicenseClass) LocalDrivingLicenseApplicationDTO.LicenseClassID),
                                                         LocalDrivingLicenseApplicationDTO.PassedTests);                                                       
        }
        private static clsLocalDrivingLicenseApplicationDAL.clsLocalDrivingLicenseApplicationDTO _Convert_LDLApp_To_LDLAppDTO(clsLocalDrivingLicenseApplication LDLApp)
        {
            clsLocalDrivingLicenseApplicationDAL.clsLocalDrivingLicenseApplicationDTO LDLAppDTO = new clsLocalDrivingLicenseApplicationDAL.clsLocalDrivingLicenseApplicationDTO();

            LDLAppDTO.LocalDrivingLicenseApplicationID = LDLApp.LocalDrivingLicenseApplicationID;

            // Upcasting
            clsApplication Application = LDLApp;

            LDLAppDTO.ApplicationDTO = _Convert_clsApplication_To_clsApplicationDTO(Application);  // It can be upcasted automatically ! only added to show you the trick :0

            LDLAppDTO.LicenseClassID = Convert.ToInt32(LDLApp.LicenseClass.LicenseClassID);
            LDLAppDTO.PassedTests = LDLApp.PassedTests;

            return LDLAppDTO;
        }

        private bool _IsValidTestType(clsTestType.enTestType enumTestType)
        {
            if (this.PassedTests == 3) return false;

            switch (enumTestType)
            {
                case clsTestType.enTestType.VisionTest:
                    return (this.PassedTests == 0);

                case clsTestType.enTestType.WrittenTest:
                    return (this.PassedTests == 1);

                case clsTestType.enTestType.PracticalTest:
                    return (this.PassedTests == 2);

                default:
                    return false;
            }
        }
        private bool _CompleteLocalDrivingLicenseApplication()
        {
            if (this._Mode != enMode.Update) return false;
            if (this.PassedTests != 3) return false;

            this.ApplicationStatus = (this.PassedTests == 3)
                                     ? enApplicationStatus.Completed
                                     : enApplicationStatus.New;

            this.StatusModificationDate = (this.ApplicationStatus == enApplicationStatus.Completed)
                                          ? DateTime.Now
                                          : StatusModificationDate;

            return base.SaveBaseApplication();
        }

        private void _EmptyObject()
        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.LicenseClass._EmptyObject();
            this.PassedTests = 0;

            this._Mode = enMode.NullOrEmpty;
        }


        private bool _AddNew()
        {
            if (!base.SaveBaseApplication()) return false;

            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationDAL.AddNewLocalDrivingLicenseApp_InDB(_Convert_LDLApp_To_LDLAppDTO(this));
            return (this.LocalDrivingLicenseApplicationID != -1);
        }
        private bool _Update()
        {
            if (!base.SaveBaseApplication()) return false;

            return (clsLocalDrivingLicenseApplicationDAL.UpdateLocalDrivingLicenseApp_InDB(_Convert_LDLApp_To_LDLAppDTO(this)));
        }
        private bool _Delete()
        {
            // bc of the referential integrity
            // I should remove the Local Driving License Application then the Application
            if (!clsLocalDrivingLicenseApplicationDAL.DeleteLocalDrivingLicenseApp_InDB(this.LocalDrivingLicenseApplicationID)) return false;

            if (base.DeleteBaseApplication())
            {
                this._EmptyObject();
                return true;
            }

            return false;
        }


        clsLocalDrivingLicenseApplication (clsApplication Application, int LocalDrivingLicenseApplicationID, clsLicenseClass LicenseClass, int PassedTests, enMode Mode = enMode.Update)
                                          : base (Application.ApplicationID, Application.Person, Application.ApplicationType, Application.ApplicationDate, Application.ApplicationStatus, 
                                                 Application.StatusModificationDate, Application.PaidFees, Application.CreatedByUserID, Mode)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.LicenseClass = LicenseClass;
            this.PassedTests = PassedTests;
        }

        public static clsLocalDrivingLicenseApplication GetNewLDLAppObjectToAdd(clsPerson Person, int CreatedByUserID, clsLicenseClass LicenseClass)
        {
            clsApplication Application = GetAddNewApplicationObject(Person, clsApplicationType.Find(clsApplicationType.enApplicationType.NewLocalDrivingLicenseService), CreatedByUserID);

            if (Application == null) return null;
            if (LicenseClass == null) return null;
            if (Person.Age < LicenseClass.MinimumAgeAllowed) return null;
            if (IsApplicantAlreadyExists(Person.PersonID, Convert.ToInt32(LicenseClass.LicenseClassID))) return null;

            return (Application != null)
                    ? new clsLocalDrivingLicenseApplication(Application, -1, LicenseClass, 0, enMode.AddNew)
                    : null;
        }

        public static clsLocalDrivingLicenseApplication FindByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            return (LocalDrivingLicenseApplicationID != -1)
                    ? _Convert_LDLAppDTO_To_clsLDLApp(clsLocalDrivingLicenseApplicationDAL.GetLocalDrivingLicenseAppByLocalDrivingLicenseApplicationID_InDB(LocalDrivingLicenseApplicationID))
                    : null;
        }
        public static bool IsApplicantAlreadyExists(int ApplicantPersonID, int LicenseClassID)
        {
            // if the enum status of the app changed, the query script should change 
            // returns true if the parameters matches the application info and it is NOT canceled or completed !

            return (ApplicantPersonID != -1 && LicenseClassID != -1)
                    ? clsLocalDrivingLicenseApplicationDAL.IsActiveLocalDrivingLicenseApplicationExistsByPersonIDAndLicenseClassID_InDB(ApplicantPersonID, LicenseClassID)
                    : false;
        }
        public static bool IsPersonExistsAsApplicant(int PersonID)
        {
            return (PersonID != -1)
                   ? clsLocalDrivingLicenseApplicationDAL.IsLocalDrivingLicenseApplicationExistsBy_InDB(PersonID) 
                   : false;
        }

        public bool Save()
        {
            switch (this._Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        this._Mode = enMode.Update;
                        return true;
                    }

                    return false;

                case enMode.Update:
                    return _Update();

                default:
                    return false;
            }
        }
        public bool Delete()
        {
            if (this.PassedTests > 0) return false;
            if (clsTestAppointment.HasAppointments(this.LocalDrivingLicenseApplicationID)) return false;

            return (this._Mode == enMode.Delete && this.ApplicationStatus != enApplicationStatus.Completed)
                   ? _Delete() 
                   : false;
        }

        
        // Test Appointments & Scheduling
        public bool IsPassedAllTests()
        {
            return (this.PassedTests == 3);
        }

        public bool IsTestPassed(clsTestType.enTestType TestTypeID)
        {
            return clsTest.IsTestPassedByLocalDrivingLicenseApplicationID(this.LocalDrivingLicenseApplicationID,  TestTypeID);    
        }
        public bool HasActiveAppointmentForCurrentTest()
        {
            return clsTestAppointment.HasActiveAppointmentPerTestType(this.LocalDrivingLicenseApplicationID, this.CurrentTestType);
        }
        public bool HasAppointmentsPerTestType(clsTestType.enTestType TestTypeID)
        {
            return clsTestAppointment.HasAppointmentsPerTestType(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public bool ScheduleTest(clsTestType.enTestType enumTestType, DateTime AppointmentDate, int CreatedByUserID)
        {
            /// Summary    
                // To schedule test, the test type should match the passed tests.
                // The tests should not be completed, NOT (Passed Tests = 3).
                // The Status should be 'New'.
                // The appointments should not be created before.
            ///Summary

            if (!this._IsValidTestType(enumTestType)) return false;
            if (this.ApplicationStatus != enApplicationStatus.New) return false;
            if (clsTestAppointment.HasAppointmentsPerTestType(this.LocalDrivingLicenseApplicationID, enumTestType)) return false;
            if (!clsUser.IsUserExists(CreatedByUserID)) return false;

            Decimal TestTypeFees = clsTestType.Find(enumTestType).TestTypeFees;

            clsTestAppointment TestAppointment = clsTestAppointment.GetNewTestAppointmentObjectToAdd
                                                                    (enumTestType, this.LocalDrivingLicenseApplicationID, AppointmentDate, TestTypeFees, -1, CreatedByUserID);

            return (TestAppointment != null) ? (TestAppointment.Save()) : false;
        }
        public int ScheduleRetakeTest(clsTestType.enTestType enumTestType, DateTime AppointmentDate, int CreatedByUserID)
        {
            if (!this._IsValidTestType(enumTestType)) return -1;
            if (this.ApplicationStatus != enApplicationStatus.New) return -1;
            if (!clsTestAppointment.HasAppointmentsPerTestType(this.LocalDrivingLicenseApplicationID, enumTestType)) return -1;
            if (clsTestAppointment.HasActiveAppointmentPerTestType(this.LocalDrivingLicenseApplicationID, enumTestType)) return -1;
            if (this.IsTestPassed(enumTestType)) return -1;
            if (!clsUser.IsUserExists(CreatedByUserID)) return -1;

            clsApplication RetakeTestApplication = clsApplication.GetAddNewApplicationObject(this.Person, 
                                                                                             clsApplicationType.Find(clsApplicationType.enApplicationType.RetakeTest),
                                                                                             CreatedByUserID);
            if (!RetakeTestApplication.SaveBaseApplication()) return -1;

            Decimal TestTypeFees = clsTestType.Find(enumTestType).TestTypeFees;
            Decimal ApplicationTypeFees = clsApplicationType.Find(clsApplicationType.enApplicationType.RetakeTest).ApplicationTypeFees;

            clsTestAppointment TestAppointment = clsTestAppointment.GetNewTestAppointmentObjectToAdd
                                                                    (enumTestType, this.LocalDrivingLicenseApplicationID, AppointmentDate,
                                                                     TestTypeFees + ApplicationTypeFees, RetakeTestApplication.ApplicationID, CreatedByUserID);

            return (TestAppointment.Save()) ? RetakeTestApplication.ApplicationID : -1;
        }
        

        // Test Taking
        public int GetTrialsPerCurrentTest(clsTestType.enTestType enumTestType)
        {
            return clsTest.GetTestTrialsByLocalDrivingLicenseApplicationIDAndTestTypeID(this.LocalDrivingLicenseApplicationID, enumTestType);
        }  
        public int TakeTest(clsTestAppointment TestAppointment, bool TestResult, string Notes, int CreatedByUserID)
        {
            if (this.LocalDrivingLicenseApplicationID != TestAppointment.LocalDrivingLicenseApplicationID) return -1;
            if (this.PassedTests == 3) return -1;
            if (this.IsTestPassed(TestAppointment.TestType.TestTypeID)) return -1;

            int TestID = TestAppointment.TakeTest(TestResult, Notes, CreatedByUserID);

            if (TestID != -1 && TestResult)
            {
                PassedTests++;
                if (!this.Save()) return -1;
            }

            return TestID;
        }


        // Issuing driving license
        public clsLicense IssueDrivingLicense(string Notes, int CreatedByUserID)
        {
            if (this.ApplicationStatus != enApplicationStatus.New) return null;
            if (!IsPassedAllTests()) return null;

            clsLicense FirstTimeLicense = clsLicense.IssueNewDrivingLicense(this.Person, this.LicenseClass, this.ApplicationID, Notes, CreatedByUserID);
            if (FirstTimeLicense == null) return null;

            return (this._CompleteLocalDrivingLicenseApplication()) ? FirstTimeLicense : null;
        }


        public static int GetSystemRecordsNumber(enReadMode ReadMode)
        {
            if (ReadMode == enReadMode.None) return clsLocalDrivingLicenseApplicationDAL.GetSystemRecordsNumber_InDB();

            int IntApplicationStatus = _GetIntApplicationStatusByReadMode(ReadMode);
            return clsLocalDrivingLicenseApplicationDAL.GetSystemRecordsNumber_InDB(IntApplicationStatus);
        }

        private static DataTable GetAllLocalLicenseAppsList(enFilterColumn FilterColumn, string StrValue)
        {
            switch (FilterColumn)
            {
                case enFilterColumn.None:
                    return clsLocalDrivingLicenseApplicationDAL.GetAllLocalDrivingLicensesApps_InDB();

                case enFilterColumn.LDLAppID:
                    return (clsValidation.IsOnlyDigits(StrValue))
                           ? clsLocalDrivingLicenseApplicationDAL.GetAllLocalDrivingLicensesAppsFilteredByLocalDrivingLicenseApplicationID_InDB(Convert.ToInt32(StrValue))
                           : clsLocalDrivingLicenseApplicationDAL.GetAllLocalDrivingLicensesApps_InDB();

                case enFilterColumn.NationalNo:
                    return (clsValidation.IsOnlyLettersAndDigits(StrValue))
                           ? clsLocalDrivingLicenseApplicationDAL.GetAllLocalDrivingLicensesAppsFilteredByNationalNo_InDB(StrValue)
                           : clsLocalDrivingLicenseApplicationDAL.GetAllLocalDrivingLicensesApps_InDB();
                     
                case enFilterColumn.LicenseClass:
                    return (!string.IsNullOrEmpty(StrValue))
                           ? clsLocalDrivingLicenseApplicationDAL.GetAllLocalDrivingLicensesAppsFilteredByLicenseClass_InDB(StrValue)
                           : clsLocalDrivingLicenseApplicationDAL.GetAllLocalDrivingLicensesApps_InDB();

                default:
                    return clsLocalDrivingLicenseApplicationDAL.GetAllLocalDrivingLicensesApps_InDB();
            }
        }
        public static DataTable GetLocalDrivingLicenseAppsList(enReadMode ReadMode, enFilterColumn FilterColumn, string StrValue)
        {
            if (ReadMode == enReadMode.None) return GetAllLocalLicenseAppsList(FilterColumn, StrValue);

            int IntApplicationStatus = _GetIntApplicationStatusByReadMode(ReadMode);

            switch (FilterColumn)
            {
                case enFilterColumn.None:
                    return clsLocalDrivingLicenseApplicationDAL.GetAllLocalDrivingLicensesApps_InDB(IntApplicationStatus);

                case enFilterColumn.LDLAppID:
                    return (clsValidation.IsOnlyDigits(StrValue))
                      ? clsLocalDrivingLicenseApplicationDAL.GetAllLocalDrivingLicensesAppsFilteredByLocalDrivingLicenseApplicationID_InDB(Convert.ToInt32(StrValue), IntApplicationStatus)
                      : clsLocalDrivingLicenseApplicationDAL.GetAllLocalDrivingLicensesApps_InDB(IntApplicationStatus);

                case enFilterColumn.NationalNo:
                    return (clsValidation.IsOnlyLettersAndDigits(StrValue))
                      ? clsLocalDrivingLicenseApplicationDAL.GetAllLocalDrivingLicensesAppsFilteredByNationalNo_InDB(StrValue, IntApplicationStatus)
                      : clsLocalDrivingLicenseApplicationDAL.GetAllLocalDrivingLicensesApps_InDB(IntApplicationStatus);

                case enFilterColumn.LicenseClass:
                    return (!string.IsNullOrEmpty(StrValue))
                           ? clsLocalDrivingLicenseApplicationDAL.GetAllLocalDrivingLicensesAppsFilteredByLicenseClass_InDB(StrValue, IntApplicationStatus)
                           : clsLocalDrivingLicenseApplicationDAL.GetAllLocalDrivingLicensesApps_InDB(IntApplicationStatus);

                default:
                    return clsLocalDrivingLicenseApplicationDAL.GetAllLocalDrivingLicensesApps_InDB(IntApplicationStatus);
            }
        }
    }
}
