using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DAL
{
    public static class clsTestDAL
    {
        public class clsTestDTO
        {
            public clsTestDTO() { }
            public clsTestDTO(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
            {
                this.TestID = TestID;
                this.TestAppointmentID = TestAppointmentID;
                this.TestResult = TestResult;
                this.Notes = Notes;
                this.CreatedByUserID = CreatedByUserID;
            }

            public int TestID { get; set; }   
            public int TestAppointmentID { get; set; }
            public bool TestResult { get; set; }
            public string Notes { get; set; }
            public int CreatedByUserID { get; set; }
        }

        // Reading: Getting test trials and passed tests per TestTypeID for a local driving application
        public static int GetTestTrialsByLocalDrivingLicenseApplicationID_InDB(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            string Query = @"SELECT COUNT(*) AS Trials 
                             FROM Tests AS T
                             INNER JOIN TestAppointments AS TApp
                                ON T.TestAppointmentID = TApp.TestAppointmentID
                             INNER JOIN LocalDrivingLicensesApplications AS LDLApps
                                ON LDLApps.LocalDrivingLicenseApplicationID = TApp.LocalDrivingLicenseApplicationID
                             
                             WHERE LDLApps.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                               AND TApp.TestTypeID = @TestTypeID; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["LocalDrivingLicenseApplicationID"] = LocalDrivingLicenseApplicationID,
                ["TestTypeID"] = TestTypeID
            };

            return clsDBManager1.CountRecords_InDB(Query, DicParameters);
        }
        public static bool IsTestPassedByLocalDrivingLicenseApplicationID_InDB(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            string Query = @"SELECT TOP 1 Found = 1 
                             FROM Tests AS T

                             INNER JOIN TestAppointments AS TApp
                                ON T.TestAppointmentID = TApp.TestAppointmentID
                             INNER JOIN LocalDrivingLicensesApplications AS LDLApps
                                ON LDLApps.LocalDrivingLicenseApplicationID = TApp.LocalDrivingLicenseApplicationID
                             
                             WHERE LDLApps.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                               AND TApp.TestTypeID = @TestTypeID
                               AND T.TestResult = 1;";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["LocalDrivingLicenseApplicationID"] = LocalDrivingLicenseApplicationID,
                ["TestTypeID"] = TestTypeID
            };

            return clsDBManager1.IsExist_InDB(Query, DicParameters);
        }

        // Writing: Adding
        public static int AddNewTest_InDB(clsTestDTO TestDTO)
        {
            string NonQuery = @"INSERT INTO [dbo].[Tests]
                                       ([TestAppointmentID], [TestResult], [Notes], [CreatedByUserID])
                                VALUES
                                       (@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID); ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["TestAppointmentID"] = TestDTO.TestAppointmentID,
                ["TestResult"] = TestDTO.TestResult,
                ["Notes"] = TestDTO.Notes,
                ["CreatedByUserID"] = TestDTO.CreatedByUserID,
            };

            return clsDBManager1.AddNewRecord_InDB(NonQuery, DicParameters);
        }
    }
}
