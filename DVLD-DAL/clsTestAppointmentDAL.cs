
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace DVLD_DAL
{
    public static class clsTestAppointmentDAL
    {
        public class clsTestAppointmentDTO
        {
            public clsTestAppointmentDTO() { }

            public int TestAppointmentID { get; set; } 
            public int TestTypeID { get; set; }
            public int LocalDrivingLicenseApplicationID { get; set; }
            public DateTime TestAppointmentDate { get; set; }
            public Decimal PaidFees { get; set; }
            public bool IsLocked { get; set; }
            public int RetakeTestApplicationID { get; set; }
            public int CreatedByUserID { get; set; }
        }

        private static clsTestAppointmentDTO _FillTestAppointmentDTO(SqlDataReader Reader)
        {
            clsTestAppointmentDTO TestAppointmentDTO = new clsTestAppointmentDTO();

            TestAppointmentDTO.TestAppointmentID = Convert.ToInt32(Reader["TestAppointmentID"]);
            TestAppointmentDTO.TestTypeID = Convert.ToInt32(Reader["TestTypeID"]);
            TestAppointmentDTO.LocalDrivingLicenseApplicationID = Convert.ToInt32(Reader["LocalDrivingLicenseApplicationID"]);
            TestAppointmentDTO.TestAppointmentDate = Convert.ToDateTime(Reader["TestAppointmentDate"]);
            TestAppointmentDTO.PaidFees = Convert.ToDecimal(Reader["PaidFees"]);
            TestAppointmentDTO.IsLocked = Convert.ToBoolean(Reader["IsLocked"]);

            TestAppointmentDTO.RetakeTestApplicationID = (Reader["RetakeTestApplicationID"] != DBNull.Value)
                                                     ? Convert.ToInt32(Reader["RetakeTestApplicationID"])
                                                     : -1;

            TestAppointmentDTO.CreatedByUserID = Convert.ToInt32(Reader["CreatedByUserID"]);

            return TestAppointmentDTO;
        }


        // Reading: getting the test appointments per test type for a local driving license 
        public static DataTable GetAllTestAppointmentsByLocalLicenseApplicationID_InDB(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            string Query = @"SELECT TA.TestAppointmentID,
                                      TestAppointmentDate AS Date,
                                      PaidFees,
                                      IsLocked,
                                      UserName AS Examiner,
                                      TestResult AS Result
                                       
                               FROM TestAppointments AS TA
                               
                               LEFT JOIN Tests AS T
                                  ON TA.TestAppointmentID = T.TestAppointmentID
                               
                               LEFT JOIN Users AS U
                                  ON T.CreatedByUserID = U.UserID
                               
                               WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                                 AND TestTypeID = @TestTypeID
                               
                               ORDER BY IsLocked ASC, Date DESC; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["LocalDrivingLicenseApplicationID"] = LocalDrivingLicenseApplicationID,
                ["TestTypeID"] = TestTypeID
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }

        // Reading: Getting today's test appointments
        public static DataTable GetTodaysTestAppointments_InDB()
        {
            string Query = @"SELECT TstA.TestAppointmentID,
                                	     NationalNo,
                                	     FirstName,
                                	     SecondName,
                                	     ThirdName,
                                	     LastName,
                                	     TstA.PaidFees,
                                	     IsLocked,
                                         UserName AS Examiner,
                                         TestResult                
                                
                               FROM TestAppointments TstA
                                
                         INNER JOIN LocalDrivingLicensesApplications LDLApps
                                 ON TstA.LocalDrivingLicenseApplicationID = LDLApps.LocalDrivingLicenseApplicationID
                                
                         INNER JOIN Applications Apps
                                 ON LDLApps.ApplicationID = Apps.ApplicationID
                                
                         INNER JOIN People AS P
                                 ON Apps.ApplicantPersonID = P.PersonID
                              
                          LEFT JOIN Tests AS Tst
                                 ON TstA.TestAppointmentID = Tst.TestAppointmentID
                              
                          LEFT JOIN Users AS U
                                 ON Tst.CreatedByUserID = U.UserID
                                
                              WHERE TestAppointmentDate = CAST(GETDATE() AS DATE);";

            return clsDBManager1.GetAllRecords_InDB(Query);
        }
        public static DataTable GetTodaysTestAppointmentsFilteredByIsLocked_InDB(bool IsLocked)
        {
            string Query = @"SELECT TstA.TestAppointmentID,
                                	     NationalNo,
                                	     FirstName,
                                	     SecondName,
                                	     ThirdName,
                                	     LastName,
                                	     TstA.PaidFees,
                                	     IsLocked,
                                         UserName AS Examiner,
                                         TestResult                
                                
                               FROM TestAppointments TstA
                                
                         INNER JOIN LocalDrivingLicensesApplications LDLApps
                                 ON TstA.LocalDrivingLicenseApplicationID = LDLApps.LocalDrivingLicenseApplicationID
                                
                         INNER JOIN Applications Apps
                                 ON LDLApps.ApplicationID = Apps.ApplicationID
                                
                         INNER JOIN People AS P
                                 ON Apps.ApplicantPersonID = P.PersonID
                              
                          LEFT JOIN Tests AS Tst
                                 ON TstA.TestAppointmentID = Tst.TestAppointmentID
                              
                          LEFT JOIN Users AS U
                                 ON Tst.CreatedByUserID = U.UserID
                                
                              WHERE TestAppointmentDate = CAST(GETDATE() AS DATE)

                                AND IsLocked = @IsLocked;";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["IsLocked"] = IsLocked
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }


        // Reading: getting the test appointment
        public static clsTestAppointmentDTO GetTestAppointmentByTestAppointmentID_InDB(int TestAppointmentID)
        {
            string Query = @"SELECT TOP 1 * 
                             FROM TestAppointments
                             WHERE TestAppointmentID = @TestAppointmentID; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["TestAppointmentID"] = TestAppointmentID
            };

            return clsDBManager1.GetRecord_InDB(Query, DicParameters, _FillTestAppointmentDTO);
        }


        // Reading: Is there an appointment for a local driving license and per test type
        // this is for deletion and referential integrity
        // when user wants to delete an application, this will show you if he can or not
        // and if not you can cascade delete all the info about the appointments that are related to the application
        public static bool IsLocalDrivingLicenseApplicationHasAppointment_InDB(int LocalDrivingLicenseApplicationID)
        {
            string Query = @"SELECT TOP 1 Result = 1
                             FROM TestAppointments
                             WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["LocalDrivingLicenseApplicationID"] = LocalDrivingLicenseApplicationID
            };

            return clsDBManager1.IsExist_InDB(Query, DicParameters);
        }
        public static bool IsLocalDrivingLicenseApplicationHasAppointment_InDB(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            string Query = @"SELECT TOP 1 Result = 1
                             FROM TestAppointments
                             WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                               AND TestTypeID = @TestTypeID; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["LocalDrivingLicenseApplicationID"] = LocalDrivingLicenseApplicationID,
                ["TestTypeID"] = TestTypeID
            };

            return clsDBManager1.IsExist_InDB(Query, DicParameters);
        }


        // Reading: Checks if is there an active appointment for a local driving license
        // this is to check if the user can add another appointment
        // if the application has no active appointment that means you can create it...
        public static bool IsLocalDrivingLicenseApplicationHasActiveAppointmentByTestType_InDB(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            string Query = @"SELECT TOP 1 Result = 1
                             FROM TestAppointments
                             WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                               AND TestTypeID = @TestTypeID
                               AND IsLocked = 0; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["LocalDrivingLicenseApplicationID"] = LocalDrivingLicenseApplicationID,
                ["TestTypeID"] = TestTypeID
            };

            return clsDBManager1.IsExist_InDB(Query, DicParameters);
        }


        // Reading: Getting Today's test appointments for the dashboard
        public static int GetTodaysTestAppointmentsSystemRecordsNumber_InDB()
        {
            string Query = @"SELECT COUNT(*) AS TestAppointmentsNumber
                               FROM TestAppointments
                              WHERE TestAppointmentDate = CAST(GETDATE() AS DATE)
                                AND IsLocked = 0;";

            return clsDBManager1.CountRecords_InDB(Query);
        }


        // Writing: Adding - Updating
        // No deleting this data is a bit sensitive so it must not be deleted
        // Instead the local driving application of this appointment(s) can be canceled
        public static int AddNewTestAppointment_InDB(clsTestAppointmentDTO TestAppointmentDTO)
        {
            string NonQuery = @"INSERT INTO TestAppointments
                                (TestTypeID,
                                 LocalDrivingLicenseApplicationID,
                                 TestAppointmentDate,
                                 PaidFees,
                                 IsLocked,
                                 RetakeTestApplicationID,
                                 CreatedByUserID)

                                 VALUES

                                (@TestTypeID,
                                 @LocalDrivingLicenseApplicationID,
                                 @TestAppointmentDate,
                                 @PaidFees,
                                 @IsLocked,
                                 @RetakeTestApplicationID,
                                 @CreatedByUserID)";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["TestTypeID"] = TestAppointmentDTO.TestTypeID,
                ["LocalDrivingLicenseApplicationID"] = TestAppointmentDTO.LocalDrivingLicenseApplicationID,
                ["TestAppointmentDate"] = TestAppointmentDTO.TestAppointmentDate,
                ["PaidFees"] = TestAppointmentDTO.PaidFees,
                ["IsLocked"] = TestAppointmentDTO.IsLocked,

                ["RetakeTestApplicationID"] = (TestAppointmentDTO.RetakeTestApplicationID == -1)
                                              ? (object) DBNull.Value
                                              : (object)TestAppointmentDTO.RetakeTestApplicationID,

                ["CreatedByUserID"] = TestAppointmentDTO.CreatedByUserID,
            };

            return clsDBManager1.AddNewRecord_InDB(NonQuery, DicParameters);
        }
        public static bool UpdateTestAppointment_InDB(clsTestAppointmentDTO TestAppointmentDTO)
        {
            string NonQuery = @"UPDATE TestAppointments

                                SET TestTypeID = @TestTypeID,
                                    LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID,
                                    TestAppointmentDate = @TestAppointmentDate,
                                    PaidFees = @PaidFees,
                                    IsLocked = @IsLocked,
                                    RetakeTestApplicationID = @RetakeTestApplicationID,
                                    CreatedByUserID = @CreatedByUserID

                                WHERE TestAppointmentID = @TestAppointmentID";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["TestTypeID"] = TestAppointmentDTO.TestTypeID,
                ["LocalDrivingLicenseApplicationID"] = TestAppointmentDTO.LocalDrivingLicenseApplicationID,
                ["TestAppointmentDate"] = TestAppointmentDTO.TestAppointmentDate,
                ["PaidFees"] = TestAppointmentDTO.PaidFees,
                ["IsLocked"] = TestAppointmentDTO.IsLocked,

                ["RetakeTestApplicationID"] = (TestAppointmentDTO.RetakeTestApplicationID == -1)
                                              ? (object)DBNull.Value
                                              : (object)TestAppointmentDTO.RetakeTestApplicationID,

                ["CreatedByUserID"] = TestAppointmentDTO.CreatedByUserID,

                ["TestAppointmentID"] = TestAppointmentDTO.TestAppointmentID
            };

            return clsDBManager1.UpdateRecord_InDB(NonQuery, DicParameters);
        }
    }
}
