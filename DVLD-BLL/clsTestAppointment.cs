using System;
using System.Data;
using System.Runtime.CompilerServices;
using DVLD_DAL;

namespace DVLD_BLL
{
    public class clsTestAppointment
    {
        // Sql Agent job -> make the late appointments where the applicant have not come locked ! 

        public static DateTime MaxAppointmentDate { get; private set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddYears(1);

        enum enMode { NullOrEmpty = 0, AddNew = 1, Update = 2 }

        public int TestAppointmentID { get; private set; }
        public clsTestType TestType { get; private set; }
        public int LocalDrivingLicenseApplicationID { get; private set; }
        public DateTime TestAppointmentDate { get; private set; }
        public Decimal PaidFees { get; private set; }
        public bool IsLocked { get; private set; }
        public int RetakeTestApplicationID { get; private set; }
        public int CreatedByUserID { get; private set; }

        private enMode _Mode { get; set; } = enMode.NullOrEmpty;


        private static clsTestAppointment _Convert_clsTestAppointmentDTO_To_clsTestAppointment(clsTestAppointmentDAL.clsTestAppointmentDTO TestAppointmentDTO)
        {
            clsTestAppointment TestAppointment = new clsTestAppointment();

            TestAppointment.TestAppointmentID = TestAppointmentDTO.TestAppointmentID;
            TestAppointment.TestType = clsTestType.Find((clsTestType.enTestType)TestAppointmentDTO.TestTypeID);
            TestAppointment.LocalDrivingLicenseApplicationID = TestAppointmentDTO.LocalDrivingLicenseApplicationID;
            TestAppointment.TestAppointmentDate = TestAppointmentDTO.TestAppointmentDate;
            TestAppointment.PaidFees = TestAppointmentDTO.PaidFees;
            TestAppointment.IsLocked = TestAppointmentDTO.IsLocked;
            TestAppointment.RetakeTestApplicationID = TestAppointmentDTO.RetakeTestApplicationID;
            TestAppointment.CreatedByUserID = TestAppointmentDTO.CreatedByUserID;

            TestAppointment._Mode = enMode.Update;

            return TestAppointment;
        }
        private static clsTestAppointmentDAL.clsTestAppointmentDTO _Convert_clsTestAppointment_To_clsTestAppointmentDTO(clsTestAppointment TestAppointment)
        {
            clsTestAppointmentDAL.clsTestAppointmentDTO TestAppointmentDTO = new clsTestAppointmentDAL.clsTestAppointmentDTO();

            TestAppointmentDTO.TestAppointmentID = TestAppointment.TestAppointmentID;
            TestAppointmentDTO.TestTypeID = Convert.ToInt32(TestAppointment.TestType.TestTypeID);
            TestAppointmentDTO.LocalDrivingLicenseApplicationID = TestAppointment.LocalDrivingLicenseApplicationID;
            TestAppointmentDTO.TestAppointmentDate = TestAppointment.TestAppointmentDate;
            TestAppointmentDTO.PaidFees = TestAppointment.PaidFees;
            TestAppointmentDTO.IsLocked = TestAppointment.IsLocked;
            TestAppointmentDTO.RetakeTestApplicationID = TestAppointment.RetakeTestApplicationID;
            TestAppointmentDTO.CreatedByUserID = TestAppointment.CreatedByUserID;

            return TestAppointmentDTO;
        }

        private bool _AddNew()
        {
            this.TestAppointmentID = clsTestAppointmentDAL.AddNewTestAppointment_InDB(_Convert_clsTestAppointment_To_clsTestAppointmentDTO(this));

            return (this.TestAppointmentID != -1);
        }
        private bool _Update()
        {
            return clsTestAppointmentDAL.UpdateTestAppointment_InDB(_Convert_clsTestAppointment_To_clsTestAppointmentDTO(this));
        }

        clsTestAppointment() { }

        clsTestAppointment(int TestAppointmentID, clsTestType.enTestType TestTypeID, int LocalDrivingLicenseApplicationID, DateTime TestAppointmentDate,
                           Decimal PaidFees, bool IsLocked, int RetakeTestApplicationID, int CreatedByUserID, enMode Mode = enMode.Update)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestType = clsTestType.Find(TestTypeID);
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.TestAppointmentDate = TestAppointmentDate;
            this.PaidFees = PaidFees;
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID = RetakeTestApplicationID;
            this.CreatedByUserID = CreatedByUserID;

            this._Mode = Mode;
        }


        internal static clsTestAppointment GetNewTestAppointmentObjectToAdd(clsTestType.enTestType TestTypeID, int LocalDrivingLicenseApplicationID, DateTime TestAppointmentDate, 
                                                                            Decimal PaidFees, int RetakeTestApplicationID, int CreatedByUserID)
        {
            if (!clsValidation.IsDateBetween(TestAppointmentDate, DateTime.Today, MaxAppointmentDate)) return null;
            if (!clsValidation.IsPositiveOrNull(PaidFees)) return null;

            return new clsTestAppointment(-1, TestTypeID, LocalDrivingLicenseApplicationID, TestAppointmentDate, PaidFees, false, RetakeTestApplicationID, CreatedByUserID, enMode.AddNew);
        }
        public bool UpdateTestAppointmentDate(DateTime NewTestAppointmentDate)
        {
            if (this.IsLocked) return false;
            if (!clsValidation.IsDateBetween(TestAppointmentDate, DateTime.Today, MaxAppointmentDate)) return false;

            this.TestAppointmentDate = NewTestAppointmentDate;
            return this.Save();
        }
        public bool CancelAppointment()
        {
            if (this.IsLocked) return false;

            this.IsLocked = true;
            return this.Save();
        }

        public static clsTestAppointment Find(int TestAppointmentID)
        {
            return (TestAppointmentID != -1)
                   ? _Convert_clsTestAppointmentDTO_To_clsTestAppointment
                      (
                        clsTestAppointmentDAL.GetTestAppointmentByTestAppointmentID_InDB(TestAppointmentID)
                      )

                   : null;
        }
        public clsLocalDrivingLicenseApplication GetLocalDrivingLicenseApplication()
        {
            return clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(this.LocalDrivingLicenseApplicationID);
        }

        internal static bool HasAppointments(int LocalDrivingLicenseApplicationID)
        {
            return (LocalDrivingLicenseApplicationID != -1)
                  ? clsTestAppointmentDAL.IsLocalDrivingLicenseApplicationHasAppointment_InDB(LocalDrivingLicenseApplicationID)
                  : false;
        }
        internal static bool HasAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return (LocalDrivingLicenseApplicationID != -1)
                   ? clsTestAppointmentDAL.IsLocalDrivingLicenseApplicationHasAppointment_InDB(LocalDrivingLicenseApplicationID, Convert.ToInt32(TestTypeID))
                   : false;
        }
        internal static bool HasActiveAppointmentPerTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return (LocalDrivingLicenseApplicationID != -1)
                   ? clsTestAppointmentDAL.IsLocalDrivingLicenseApplicationHasActiveAppointmentByTestType_InDB(LocalDrivingLicenseApplicationID, Convert.ToInt32(TestTypeID))
                   : false;
        }

        internal bool Save()
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

        internal int TakeTest(bool TestResult, string Notes, int CreatedByUserID)
        {
            if (!clsUser.IsUserExists(CreatedByUserID)) return -1;
            if (this.TestAppointmentDate.Date != DateTime.Today) return -1;
            if (this.IsLocked) return -1;

            clsTest Test = clsTest.GetNewTestObjectToAdd(this.TestAppointmentID, TestResult, Notes, CreatedByUserID);
            if (!Test.Save()) return -1;
            
            this.IsLocked = true;

            if (this.RetakeTestApplicationID != -1)
            {
                clsApplication Application = clsApplication.Find(this.RetakeTestApplicationID);
                if (!Application.CompleteApplication()) return -1;
            }

            return (this.Save()) ? Test.TestID : -1;
        }


        public static int GetTodaysTestAppointmentsSystemRecordsNumber() => clsTestAppointmentDAL.GetTodaysTestAppointmentsSystemRecordsNumber_InDB();

        public static DataTable GetTestAppointmentsList(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return (LocalDrivingLicenseApplicationID != -1)
                   ? clsTestAppointmentDAL.GetAllTestAppointmentsByLocalLicenseApplicationID_InDB(LocalDrivingLicenseApplicationID, Convert.ToInt32(TestTypeID))
                   : new DataTable(); // to avoid error when binding !
        }
        public static DataTable GetTodaysTestAppointmentsList() => clsTestAppointmentDAL.GetTodaysTestAppointments_InDB();
        public static DataTable GetTodaysTestAppointmentsList(bool IsLocked) => clsTestAppointmentDAL.GetTodaysTestAppointmentsFilteredByIsLocked_InDB(IsLocked);
    }
}

