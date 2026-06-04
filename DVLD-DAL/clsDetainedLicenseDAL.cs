using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DAL
{
    public static class clsDetainedLicenseDAL
    {
        public class clsDetainedLicenseDTO
        {
            public clsDetainedLicenseDTO() { }

            public int DetainedLicenseID { get; set; }
            public int LicenseID { get; set; }
            public DateTime DetainDate { get; set; }
            public Decimal FineFees { get; set; }
            public int CreatedByUserID { get; set; }

            public bool IsReleased { get; set; }
            public string Notes { get; set; }
            public DateTime ReleaseDate { get; set; }
            public int ReleaseApplicationID { get; set; }
            public int ReleasedByUserID { get; set; }
        }

        internal static clsDetainedLicenseDTO _FillDetainedLicenseDTO(SqlDataReader Reader)
        {
            clsDetainedLicenseDTO DTO = new clsDetainedLicenseDTO();

            DTO.DetainedLicenseID = Convert.ToInt32(Reader["DetainedLicenseID"]);
            DTO.LicenseID = Convert.ToInt32(Reader["LicenseID"]);
            DTO.DetainDate = Convert.ToDateTime(Reader["DetainDate"]);
            DTO.FineFees = Convert.ToDecimal(Reader["FineFees"]);
            DTO.IsReleased = Convert.ToBoolean(Reader["IsReleased"]);
            DTO.CreatedByUserID = Convert.ToInt32(Reader["CreatedByUserID"]);

            DTO.Notes = (Reader["Notes"] == DBNull.Value)
                        ? string.Empty
                        : Reader["Notes"].ToString();

            DTO.ReleaseDate = (Reader["ReleaseDate"] == DBNull.Value)
                              ? default(DateTime)
                              : Convert.ToDateTime(Reader["ReleaseDate"]);

            DTO.ReleaseApplicationID = (Reader["ReleaseApplicationID"] == DBNull.Value)
                                       ? -1
                                       : Convert.ToInt32(Reader["ReleaseApplicationID"]);

            DTO.ReleasedByUserID = (Reader["ReleasedByUserID"] == DBNull.Value)
                                   ? -1
                                   : Convert.ToInt32(Reader["ReleasedByUserID"]);

            return DTO;
        }


        // Reading: Getting all detained licenses with filters
        public static DataTable GetAllDetainedLicenses_InDB()
        {
            string Query = @"SELECT * FROM DetainedLicenses_View;";

            return clsDBManager1.GetAllRecords_InDB(Query);
        }
        public static DataTable GetAllDetainedLicensesFilteredByIsReleased_InDB(bool IsReleased)
        {
            string Query = @"SELECT * FROM DetainedLicenses_View
                             WHERE IsReleased = @IsReleased;";

            Dictionary<string, object> Parameters = new Dictionary<string, object>()
            {
                ["IsReleased"] = IsReleased
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, Parameters);
        }
        public static DataTable GetAllDetainedLicensesFilteredByDetainedLicenseID_InDB(int DetainedLicenseID)
        {
            string Query = @"SELECT * FROM DetainedLicenses_View
                             WHERE DetainedLicenseID = @DetainedLicenseID;";

            Dictionary<string, object> Parameters = new Dictionary<string, object>()
            {
                ["DetainedLicenseID"] = DetainedLicenseID
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, Parameters);
        }
        public static DataTable GetAllDetainedLicensesFilteredByDetainedLicenseIDAndIsReleased_InDB(int DetainedLicenseID, bool IsReleased)
        {
            string Query = @"SELECT * FROM DetainedLicenses_View
                             WHERE IsReleased = @IsReleased
                               AND DetainedLicenseID = @DetainedLicenseID;";

            Dictionary<string, object> Parameters = new Dictionary<string, object>()
            {
                ["IsReleased"] = IsReleased,
                ["DetainedLicenseID"] = DetainedLicenseID
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, Parameters);
        }
        public static DataTable GetAllDetainedLicensesFilteredByLicenseID_InDB(int LicenseID)
        {
            string Query = @"SELECT * FROM DetainedLicenses_View
                             WHERE LicenseID = @LicenseID;";

            Dictionary<string, object> Parameters = new Dictionary<string, object>()
            {
                ["LicenseID"] = LicenseID
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, Parameters);
        }
        public static DataTable GetAllDetainedLicensesFilteredByLicenseIDAndIsReleased_InDB(int LicenseID, bool IsReleased)
        {
            string Query = @"SELECT * FROM DetainedLicenses_View
                             WHERE IsReleased = @IsReleased
                               AND LicenseID = @LicenseID;";

            Dictionary<string, object> Parameters = new Dictionary<string, object>()
            {
                ["IsReleased"] = IsReleased,
                ["LicenseID"] = LicenseID
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, Parameters);
        }
        public static DataTable GetAllDetainedLicensesFilteredBySerialNumber_InDB(string SerialNumber)
        {
            string Query = @"SELECT * FROM DetainedLicenses_View
                             WHERE SerialNumber LIKE '' + @SerialNumber + '%';";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["SerialNumber"] = SerialNumber
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }
        public static DataTable GetAllDetainedLicensesFilteredBySerialNumberAndIsReleased_InDB(string SerialNumber, bool IsReleased)
        {
            string Query = @"SELECT * FROM DetainedLicenses_View
                             WHERE IsReleased = @IsReleased
                               AND SerialNumber LIKE '' + @SerialNumber + '%';";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["IsReleased"] = IsReleased,
                ["SerialNumber"] = SerialNumber
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }
        public static DataTable GetAllDetainedLicensesFilteredByNationalNo_InDB(string NationalNo)
        {
            string Query = @"SELECT * FROM DetainedLicenses_View
                             WHERE NationalNo LIKE '' + @NationalNo + '%';";

            Dictionary<string, object> Parameters = new Dictionary<string, object>()
            {
                ["NationalNo"] = NationalNo
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, Parameters);
        }
        public static DataTable GetAllDetainedLicensesFilteredByNationalNoAndIsReleased_InDB(string NationalNo, bool IsReleased)
        {
            string Query = @"SELECT * FROM DetainedLicenses_View
                             WHERE IsReleased = @IsReleased
                               AND NationalNo LIKE '' + @NationalNo + '%';";

            Dictionary<string, object> Parameters = new Dictionary<string, object>()
            {
                ["IsReleased"] = IsReleased,
                ["NationalNo"] = NationalNo
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, Parameters);
        }


        // Reading: Getting detained licenses number with filter
        public static int GetSystemRecordsNumber_InDB()
        {
            string Query = @"SELECT COUNT(*) FROM DetainedLicenses;";

            return clsDBManager1.CountRecords_InDB(Query);
        }
        public static int GetSystemRecordsNumberByIsReleased_InDB(bool IsReleased)
        {
            string Query = @"SELECT COUNT(*) FROM DetainedLicenses
                             WHERE IsReleased = @IsReleased;";

            Dictionary<string, object> Parameters = new Dictionary<string, object>()
            {
                ["IsReleased"] = IsReleased
            };

            return clsDBManager1.CountRecords_InDB(Query, Parameters);
        }


        // Reading: Getting a single detained license
        public static clsDetainedLicenseDTO GetDetainedLicense_InDB(int DetainedLicenseID)
        {
            string Query = @"SELECT TOP 1 *
                             FROM DetainedLicenses
                             WHERE DetainedLicenseID = @DetainedLicenseID;";

            Dictionary<string, object> Parameters = new Dictionary<string, object>()
            {
                ["DetainedLicenseID"] = DetainedLicenseID
            };

            return clsDBManager1.GetRecord_InDB(Query, Parameters, _FillDetainedLicenseDTO);
        }
        public static clsDetainedLicenseDTO GetLatestDetainedLicenseByLicenseID_InDB(int LicenseID)
        {
            string Query = @"SELECT TOP 1 *
                             FROM DetainedLicenses
                             WHERE LicenseID = @LicenseID
                               AND IsReleased = 0;";

            Dictionary<string, object> Parameters = new Dictionary<string, object>()
            {
                ["LicenseID"] = LicenseID
            };

            return clsDBManager1.GetRecord_InDB(Query, Parameters, _FillDetainedLicenseDTO);
        }


        // Reading: Checking if license is detained
        public static bool IsLicenseDetained_InDB(int LicenseID)
        {
            string Query = @"SELECT TOP 1 Found = 1
                             FROM DetainedLicenses
                             WHERE LicenseID = @LicenseID
                               AND IsReleased = 0;";

            Dictionary<string, object> Parameters = new Dictionary<string, object>()
            {
                ["LicenseID"] = LicenseID
            };

            return clsDBManager1.IsExist_InDB(Query, Parameters);
        }


        // Writing: Adding - Updating
        public static int AddNewDetainedLicense_InDB(clsDetainedLicenseDTO DTO)
        {
            string NonQuery = @"INSERT INTO DetainedLicenses
                                (
                                    LicenseID,
                                    DetainDate,
                                    FineFees,
                                    CreatedByUserID,
                                    IsReleased,
                                    ReleaseDate,
                                    ReleaseApplicationID,
                                    ReleasedByUserID,
                                    Notes
                                )
                                VALUES
                                (
                                    @LicenseID,
                                    @DetainDate,
                                    @FineFees,
                                    @CreatedByUserID,
                                    @IsReleased,
                                    @ReleaseDate,
                                    @ReleaseApplicationID,
                                    @ReleasedByUserID,
                                    @Notes
                                );";

            Dictionary<string, object> Parameters = new Dictionary<string, object>()
            {
                ["LicenseID"] = DTO.LicenseID,
                ["DetainDate"] = DTO.DetainDate,
                ["FineFees"] = DTO.FineFees,
                ["CreatedByUserID"] = DTO.CreatedByUserID,
                ["IsReleased"] = DTO.IsReleased,

                ["ReleaseDate"] = DTO.ReleaseDate == default
                                  ? (object)DBNull.Value
                                  : (object)DTO.ReleaseDate,

                ["ReleaseApplicationID"] = DTO.ReleaseApplicationID == -1
                                  ? (object)DBNull.Value
                                  : (object)DTO.ReleaseApplicationID,

                ["ReleasedByUserID"] = DTO.ReleasedByUserID == -1
                                  ? (object)DBNull.Value
                                  : (object)DTO.ReleasedByUserID,

                ["Notes"] = string.IsNullOrEmpty(DTO.Notes)
                                  ? (object)DBNull.Value
                                  : (object)DTO.Notes
            };

            return clsDBManager1.AddNewRecord_InDB(NonQuery, Parameters);
        }
        public static bool UpdateDetainedLicense_InDB(clsDetainedLicenseDTO DTO)
        {
            string NonQuery = @"UPDATE DetainedLicenses
                                SET LicenseID = @LicenseID,
                                    DetainDate = @DetainDate,
                                    FineFees = @FineFees,
                                    CreatedByUserID = @CreatedByUserID,
                                    IsReleased = @IsReleased,
                                    ReleaseDate = @ReleaseDate,
                                    ReleaseApplicationID = @ReleaseApplicationID,
                                    ReleasedByUserID = @ReleasedByUserID,
                                    Notes = @Notes
                                WHERE DetainedLicenseID = @DetainedLicenseID;";

            Dictionary<string, object> Parameters = new Dictionary<string, object>()
            {
                ["DetainedLicenseID"] = DTO.DetainedLicenseID,
                ["LicenseID"] = DTO.LicenseID,
                ["DetainDate"] = DTO.DetainDate,
                ["FineFees"] = DTO.FineFees,
                ["CreatedByUserID"] = DTO.CreatedByUserID,
                ["IsReleased"] = DTO.IsReleased,

                ["ReleaseDate"] = DTO.ReleaseDate == default 
                                  ? (object) DBNull.Value 
                                  : (object)DTO.ReleaseDate,

                ["ReleaseApplicationID"] = DTO.ReleaseApplicationID == -1 
                                  ? (object) DBNull.Value 
                                  : (object) DTO.ReleaseApplicationID,

                ["ReleasedByUserID"] = DTO.ReleasedByUserID == -1 
                                  ? (object) DBNull.Value 
                                  : (object) DTO.ReleasedByUserID,

                ["Notes"] = string.IsNullOrEmpty(DTO.Notes) 
                                  ? (object) DBNull.Value 
                                  : (object) DTO.Notes
            };

            return clsDBManager1.UpdateRecord_InDB(NonQuery, Parameters);
        }
    }
}