using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DAL
{
    public static class clsLocalDrivingLicenseApplicationDAL
    {
        public class clsLocalDrivingLicenseApplicationDTO
        {
            public clsLocalDrivingLicenseApplicationDTO() { }

            public int LocalDrivingLicenseApplicationID { get; set; }
            public clsApplicationDAL.clsApplicationDTO ApplicationDTO { get; set; }
            public int LicenseClassID { get; set; }
            public int PassedTests { get; set; }      
        }

        private static clsLocalDrivingLicenseApplicationDTO _FillLocalDrivingLicenseAppDTO(SqlDataReader Reader)
        {
            clsLocalDrivingLicenseApplicationDTO LocalDrivingLicenseAppDTO = new clsLocalDrivingLicenseApplicationDTO();

            LocalDrivingLicenseAppDTO.LocalDrivingLicenseApplicationID = Convert.ToInt32(Reader["LocalDrivingLicenseApplicationID"]);
            LocalDrivingLicenseAppDTO.ApplicationDTO = clsApplicationDAL._FillApplicationDTO(Reader);
            LocalDrivingLicenseAppDTO.LicenseClassID = Convert.ToInt32(Reader["LicenseClassID"]);
            LocalDrivingLicenseAppDTO.PassedTests = Convert.ToInt32(Reader["PassedTests"]);

            return LocalDrivingLicenseAppDTO;
        }

        // Reading: Getting local driving licenses applications (No status filter), with filters
        public static DataTable GetAllLocalDrivingLicensesApps_InDB()
        {
            // this is a view !
            // it contain the general query with full info !

            string Query = @"SELECT * FROM vLDLAppFullInfo; ";

            return clsDBManager1.GetAllRecords_InDB(Query);
        }
        public static DataTable GetAllLocalDrivingLicensesAppsFilteredByLocalDrivingLicenseApplicationID_InDB(int LocalDrivingLicenseApplicationID)
        {
            string Query = @"SELECT * FROM vLDLAppFullInfo 
                             WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["LocalDrivingLicenseApplicationID"] = LocalDrivingLicenseApplicationID
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }
        public static DataTable GetAllLocalDrivingLicensesAppsFilteredByNationalNo_InDB(string NationalNo)
        {
            string Query = @"SELECT * FROM vLDLAppFullInfo 
                             WHERE NationalNo LIKE '' + @NationalNo + '%' ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["NationalNo"] = NationalNo
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }
        public static DataTable GetAllLocalDrivingLicensesAppsFilteredByLicenseClass_InDB(string LicenseClassName)
        {
            string Query = @"SELECT * FROM vLDLAppFullInfo 
                             WHERE LicenseClassName LIKE '' + @LicenseClassName + '%' ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["LicenseClassName"] = LicenseClassName
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }

        // Reading: Getting local driving licenses applications (with status filter), with filters
        public static DataTable GetAllLocalDrivingLicensesApps_InDB(int ApplicationStatus)
        {
            // this is a view !
            // it contain the general query with full info !

            string Query = @"SELECT * FROM vLDLAppFullInfo 
                             WHERE ApplicationStatus = @ApplicationStatus; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["ApplicationStatus"] = ApplicationStatus
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }   
        public static DataTable GetAllLocalDrivingLicensesAppsFilteredByLocalDrivingLicenseApplicationID_InDB(int LocalDrivingLicenseApplicationID, int ApplicationStatus)
        {
            string Query = @"SELECT * FROM vLDLAppFullInfo 
                             WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                               AND ApplicationStatus = @ApplicationStatus;";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["LocalDrivingLicenseApplicationID"] = LocalDrivingLicenseApplicationID,
                ["ApplicationStatus"] = ApplicationStatus
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }
        public static DataTable GetAllLocalDrivingLicensesAppsFilteredByNationalNo_InDB(string NationalNo, int ApplicationStatus)
        {
            string Query = @"SELECT * FROM vLDLAppFullInfo 
                             WHERE NationalNo LIKE '' + @NationalNo + '%'
                               AND ApplicationStatus = @ApplicationStatus; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["NationalNo"] = NationalNo,
                ["ApplicationStatus"] = ApplicationStatus
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }
        public static DataTable GetAllLocalDrivingLicensesAppsFilteredByLicenseClass_InDB(string LicenseClassName, int ApplicationStatus)
        {
            string Query = @"SELECT * FROM vLDLAppFullInfo 
                             WHERE LicenseClassName LIKE '' + @LicenseClassName + '%'
                               AND ApplicationStatus = @ApplicationStatus;";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["LicenseClassName"] = LicenseClassName,
                ["ApplicationStatus"] = ApplicationStatus
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }


        // Reading: Getting local driving licenses applications number with filters
        public static int GetSystemRecordsNumber_InDB()
        {
            string Query = @"SELECT COUNT(*) AS Records
                             FROM LocalDrivingLicensesApplications AS LDLApps ";

            return clsDBManager1.CountRecords_InDB(Query);
        }
        public static int GetSystemRecordsNumber_InDB(int ApplicationStatus)
        {
            string Query = @"SELECT COUNT(*) AS Records
                               FROM LocalDrivingLicensesApplications AS LDLApps

                             INNER JOIN Applications AS Apps
                               ON LDLApps.ApplicationID = Apps.ApplicationID

                              WHERE ApplicationStatus = @ApplicationStatus;";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["ApplicationStatus"] = ApplicationStatus
            };

            return clsDBManager1.CountRecords_InDB(Query, DicParameters);
        }


        // Reading: Getting local driving license application 
        public static clsLocalDrivingLicenseApplicationDTO GetLocalDrivingLicenseAppByLocalDrivingLicenseApplicationID_InDB(int LocalDrivingLicenseApplicationID)
        {
            string Query = @"SELECT Apps.*, LDLApps.*, P.*
                             FROM LocalDrivingLicensesApplications AS LDLApps
                             
                             INNER JOIN Applications AS Apps
                             	ON LDLApps.ApplicationID = Apps.ApplicationID

                             INNER JOIN People AS P
                                ON P.PersonID = Apps.ApplicantPersonID
                             
                             WHERE LDLApps.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["LocalDrivingLicenseApplicationID"] = LocalDrivingLicenseApplicationID
            };

            return clsDBManager1.GetRecord_InDB(Query, DicParameters, _FillLocalDrivingLicenseAppDTO);
        }
       
        // Reading: Checking if person is an applicant 
        public static bool IsActiveLocalDrivingLicenseApplicationExistsByPersonIDAndLicenseClassID_InDB(int ApplicantPersonID, int LicenseClassID)
        {
            string Query = @"SELECT TOP 1 Result = 1
                              FROM LocalDrivingLicensesApplications AS LDLApps
                                
                              INNER JOIN Applications AS Apps
                              	ON LDLApps.ApplicationID = Apps.ApplicationID
                              
                              WHERE Apps.ApplicantPersonID = @ApplicantPersonID 
                                AND LDLApps.LicenseClassID = @LicenseClassID 
                                AND Apps.ApplicationStatus != 2;";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["ApplicantPersonID"] = ApplicantPersonID,
                ["LicenseClassID"] = LicenseClassID
            };

            return clsDBManager1.IsExist_InDB(Query, DicParameters);
        }
        public static bool IsLocalDrivingLicenseApplicationExistsBy_InDB(int PersonID)
        {
            string Query = @"SELECT TOP 1 Result = 1
                              FROM LocalDrivingLicensesApplications AS LDLApps
                                
                              INNER JOIN Applications AS Apps
                              	ON LDLApps.ApplicationID = Apps.ApplicationID
                              
                              WHERE Apps.ApplicantPersonID = @ApplicantPersonID;";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["ApplicantPersonID"] = PersonID,
            };

            return clsDBManager1.IsExist_InDB(Query, DicParameters);
        }


        // Writing: Adding - Updating - Deleting 
        public static int AddNewLocalDrivingLicenseApp_InDB(clsLocalDrivingLicenseApplicationDTO LocalDrivingLicenseApplicationDTO)
        {
            string NonQuery = @"INSERT INTO [dbo].[LocalDrivingLicensesApplications]
                                   (ApplicationID,
                                   LicenseClassID,
                                   PassedTests)
                                VALUES
                                   (@ApplicationID,
                                   @LicenseClassID,
                                   @PassedTests); ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["ApplicationID"] = LocalDrivingLicenseApplicationDTO.ApplicationDTO.ApplicationID,
                ["LicenseClassID"] = LocalDrivingLicenseApplicationDTO.LicenseClassID,
                ["PassedTests"] = LocalDrivingLicenseApplicationDTO.PassedTests
            };

            return clsDBManager1.AddNewRecord_InDB(NonQuery, DicParameters);
        }
        public static bool UpdateLocalDrivingLicenseApp_InDB(clsLocalDrivingLicenseApplicationDTO LocalDrivingLicenseApplicationDTO)
        {
            string NonQuery = @"UPDATE [dbo].[LocalDrivingLicensesApplications]
                                   SET PassedTests = @PassedTests
                                 WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["PassedTests"] = LocalDrivingLicenseApplicationDTO.PassedTests,
                ["LocalDrivingLicenseApplicationID"] = LocalDrivingLicenseApplicationDTO.LocalDrivingLicenseApplicationID
            };

            return clsDBManager1.UpdateRecord_InDB(NonQuery, DicParameters);
        }
        public static bool DeleteLocalDrivingLicenseApp_InDB(int LocalDrivingLicenseApplicationID)
        {
            string NonQuery = @"DELETE FROM LocalDrivingLicensesApplications
                                WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID; ";

            return clsDBManager1.DeleteRecord_InDB(NonQuery, "LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
        }

    }
}
