using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DAL;

namespace DVLD_BLL
{
    public class clsTest
    {
        enum enMode { NullOrEmpty = 0, AddNew = 1, Read = 2 };

        public int TestID { get; private set; }
        public int TestAppointmentID { get; private set; }
        public bool TestResult { get; private set; }
        public string Notes { get; private set; }
        public int CreatedByUserID { get; private set; }

        private enMode _Mode {  get; set; } = enMode.NullOrEmpty;

        private static clsTestDAL.clsTestDTO _Convert_clsTest_To_clsTestDTO(clsTest Test)
        {
            return (Test == null)
                   ? null
                   : new clsTestDAL.clsTestDTO(Test.TestID, Test.TestAppointmentID, Test.TestResult, Test.Notes, Test.CreatedByUserID);
        }


        private bool _AddNew()
        {
            this.TestID = clsTestDAL.AddNewTest_InDB(_Convert_clsTest_To_clsTestDTO(this));

            return (this.TestID != -1);
        }

        clsTest() { }
        clsTest(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID, enMode Mode = enMode.Read)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;

            this._Mode = Mode;
        }

        internal static clsTest GetNewTestObjectToAdd(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            return new clsTest(-1, TestAppointmentID, TestResult, Notes, CreatedByUserID, enMode.AddNew);
        }
        internal bool Save()
        {
            if (this._Mode != enMode.AddNew) return false;

            if (_AddNew())
            {
                this._Mode = enMode.Read;
                return true;
            }

            return false;
        }

        internal static int GetTestTrialsByLocalDrivingLicenseApplicationIDAndTestTypeID(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsTestDAL.GetTestTrialsByLocalDrivingLicenseApplicationID_InDB(LocalDrivingLicenseApplicationID, Convert.ToInt32(TestTypeID));
        }
        internal static bool IsTestPassedByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsTestDAL.IsTestPassedByLocalDrivingLicenseApplicationID_InDB(LocalDrivingLicenseApplicationID, Convert.ToInt32(TestTypeID));
        }
    }
}
