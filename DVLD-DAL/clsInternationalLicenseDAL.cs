using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DAL
{
    public static class clsInternationalLicenseDAL
    {
        public class clsInternationalLicenseDTO
        {
            public clsInternationalLicenseDTO() { }

            public int InternationalLicenseID { get; set; }
            public string InternationalSerialNumber { get; set; }
            public clsLicenseDAL.clsLicenseDTO LicenseDTO { get; set; }
            public int ApplicationID { get; set; }
            public DateTime IssueDate { get; set; }
            public DateTime ExpirationDate { get; set; }
            public bool IsActive { get; set; }
            public int CreatedByUserID { get; set; }
        }

        internal static clsInternationalLicenseDTO _FillInternationalLicenseDTO(SqlDataReader Reader)
        {
            clsInternationalLicenseDTO DTO = new clsInternationalLicenseDTO();

            DTO.InternationalLicenseID = Convert.ToInt32(Reader["InternationalLicenseID"]);
            DTO.InternationalSerialNumber = Reader["InternationalSerialNumber"].ToString();
            DTO.LicenseDTO = clsLicenseDAL._FillLicenseDTO(Reader);
            DTO.ApplicationID = Convert.ToInt32(Reader["ApplicationID"]);
            DTO.IssueDate = Convert.ToDateTime(Reader["IssueDate"]);
            DTO.ExpirationDate = Convert.ToDateTime(Reader["ExpirationDate"]);
            DTO.IsActive = Convert.ToBoolean(Reader["IsActive"]);
            DTO.CreatedByUserID = Convert.ToInt32(Reader["CreatedByUserID"]);

            return DTO;
        }

        // Reading: Getting international licenses lists with filters
        public static DataTable GetAllInternationalLicenses_InDB()
        {
            string Query = @"SELECT * FROM InternationalLicenseListInfo_View;";

            return clsDBManager1.GetAllRecords_InDB(Query);
        }
        public static DataTable GetAllInternationalLicensesFilteredByInternationalLicenseID_InDB(int InternationalLicenseID)
        {
            string Query = @"SELECT * 
                             FROM InternationalLicenseListInfo_View
                             WHERE InternationalLicenseID = @InternationalLicenseID;";

            Dictionary<string, object> Parameters = new Dictionary<string, object>()
            {
                ["InternationalLicenseID"] = InternationalLicenseID
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, Parameters);
        }
        public static DataTable GetAllInternationalLicensesFilteredBySerialNumber(string InternationalSerialNumber)
        {
            string Query = @"SELECT * 
                             FROM InternationalLicenseListInfo_View
                             WHERE InternationalSerialNumber LIKE '' + @InternationalSerialNumber + '%';";

            Dictionary<string, object> Parameters = new Dictionary<string, object>()
            {
                ["InternationalSerialNumber"] = InternationalSerialNumber
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, Parameters);
        }
        public static DataTable GetAllInternationalLicensesFilteredByDriverID_InDB(int DriverID)
        {
            string Query = @"SELECT * 
                             FROM InternationalLicenseListInfo_View
                             WHERE DriverID = @DriverID;";

            Dictionary<string, object> Parameters = new Dictionary<string, object>()
            {
                ["DriverID"] = DriverID
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, Parameters);
        }
        public static DataTable GetAllInternationalLicensesFilteredByLicenseID_InDB(int LicenseID)
        {
            string Query = @"SELECT * 
                             FROM InternationalLicenseListInfo_View
                             WHERE LicenseID = @LicenseID;";

            Dictionary<string, object> Parameters = new Dictionary<string, object>()
            {
                ["LicenseID"] = LicenseID
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, Parameters);
        }
        public static DataTable GetAllInternationalLicensesFilteredByNationalNo_InDB(string NationalNo)
        {
            string Query = @"SELECT * 
                             FROM InternationalLicenseListInfo_View
                             WHERE NationalNo LIKE '' + @NationalNo + '%';";

            Dictionary<string, object> Parameters = new Dictionary<string, object>()
            {
                ["NationalNo"] = NationalNo
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, Parameters);
        }

        public static DataTable GetInternationalLicensesByDriverID_InDB(int DriverID)
        {
            string Query = @"SELECT InternationalLicenseID,
                                    InternationalSerialNumber,
                                    ApplicationID,
                                    LicenseID,
                                    IssueDate,
                                    ExpirationDate,
                                    IsActive
                             FROM InternationalLicenses
                             WHERE DriverID = @DriverID
                             ORDER BY IsActive DESC;";

            Dictionary<string, object> Parameters = new Dictionary<string, object>()
            {
                ["DriverID"] = DriverID
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, Parameters);
        }


        // Reading: Getting the International licenses number in the system 
        public static int GetSystemRecordsNumber_InDB()
        {
            string Query = @"SELECT COUNT(*) FROM InternationalLicenses;";

            return clsDBManager1.CountRecords_InDB(Query);
        }


        // Reading: Getting a single international license 
        public static clsInternationalLicenseDTO GetInternationalLicense_InDB(int InternationalLicenseID)
        {
            string Query = @"SELECT TOP 1 *
                             FROM InternationalLicenses AS IL

                             INNER JOIN Licenses AS L
                                ON IL.LicenseID = L.LicenseID

                             INNER JOIN Drivers AS D
                                ON L.DriverID = D.DriverID

                             INNER JOIN People AS P
                                ON D.PersonID = P.PersonID

                             WHERE IL.InternationalLicenseID = @InternationalLicenseID;";

            Dictionary<string, object> Parameters = new Dictionary<string, object>()
            {
                ["InternationalLicenseID"] = InternationalLicenseID
            };

            return clsDBManager1.GetRecord_InDB(Query, Parameters, _FillInternationalLicenseDTO);
        }

        // Reading: Checking if active international exists for a drivers
        public static bool IsActiveInternationalLicenseExistsByDriverID_InDB(int DriverID)
        {
            string Query = @"SELECT TOP 1 Found = 1
                             FROM InternationalLicenses
                             WHERE DriverID = @DriverID
                             AND IsActive = 1;";

            Dictionary<string, object> Parameters = new Dictionary<string, object>()
            {
                ["DriverID"] = DriverID
            };

            return clsDBManager1.IsExist_InDB(Query, Parameters);
        }


        // Writing: Adding
        public static int AddNewInternationalLicense_InDB(clsInternationalLicenseDTO DTO)
        {
            string NonQuery = @"INSERT INTO InternationalLicenses
                                (
                                    InternationalSerialNumber,
                                    LicenseID,
                                    DriverID,
                                    ApplicationID,
                                    IssueDate,
                                    ExpirationDate,
                                    IsActive,
                                    CreatedByUserID
                                )
                                VALUES
                                (
                                    @InternationalSerialNumber,
                                    @LicenseID,
                                    @DriverID,
                                    @ApplicationID,
                                    @IssueDate,
                                    @ExpirationDate,
                                    @IsActive,
                                    @CreatedByUserID
                                );";

            Dictionary<string, object> Parameters = new Dictionary<string, object>()
            {
                ["InternationalSerialNumber"] = DTO.InternationalSerialNumber,
                ["LicenseID"] = DTO.LicenseDTO.LicenseID,
                ["DriverID"] = DTO.LicenseDTO.DriverDTO.DriverID,
                ["ApplicationID"] = DTO.ApplicationID,
                ["IssueDate"] = DTO.IssueDate,
                ["ExpirationDate"] = DTO.ExpirationDate,
                ["IsActive"] = DTO.IsActive,
                ["CreatedByUserID"] = DTO.CreatedByUserID
            };

            return clsDBManager1.AddNewRecord_InDB(NonQuery, Parameters);
        }

        public static bool DeactivateAllLicenses_InDB(int DriverID)
        {
            string NonQuery = @"UPDATE InternationalLicenses
                                   SET IsActive = 0
                                 WHERE DriverID = @DriverID; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["DriverID"] = DriverID
            };

            return clsDBManager1.UpdateRecord_InDB(NonQuery, DicParameters);
        }
    }
}