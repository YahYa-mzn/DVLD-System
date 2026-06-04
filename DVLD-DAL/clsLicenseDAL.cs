using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DAL
{
    public static class clsLicenseDAL
    {
        public class clsLicenseDTO
        {
            public clsLicenseDTO() { }

            public int LicenseID {  get; set; }
            public string SerialNumber { get; set; }
            public int LicenseClassID { get; set; } // Lazy loading (table contains 7 columns)

                // this field will be used only to get the full license info
                // if you want any info about this application do lazy loading...
            public int ApplicationID { get; set; }
            public clsDriverDAL.clsDriverDTO DriverDTO { get; set; }
            public DateTime IssueDate { get; set; }
            public DateTime ExpirationDate { get; set; }
            public Decimal PaidFees { get; set; }
            public int IssueReason { get; set; }
            public string Notes { get; set; }
            public bool IsActive { get; set; }
            public int CreatedByUserID { get; set; }
        }
        internal static clsLicenseDTO _FillLicenseDTO(SqlDataReader Reader)
        {
            clsLicenseDTO LicenseDTO = new clsLicenseDTO();

            LicenseDTO.LicenseID = Convert.ToInt32(Reader["LicenseID"]);
            LicenseDTO.SerialNumber = Reader["SerialNumber"].ToString();
            LicenseDTO.LicenseClassID = Convert.ToInt32(Reader["LicenseClassID"]);
            LicenseDTO.ApplicationID = Convert.ToInt32(Reader["ApplicationID"]);
            LicenseDTO.DriverDTO = clsDriverDAL._FillDriverDTO(Reader);
            LicenseDTO.IssueDate = Convert.ToDateTime(Reader["IssueDate"]);
            LicenseDTO.ExpirationDate = Convert.ToDateTime(Reader["ExpirationDate"]);
            LicenseDTO.PaidFees = Convert.ToDecimal(Reader["PaidFees"]);
            LicenseDTO.IssueReason = Convert.ToInt32(Reader["IssueReason"]);

            LicenseDTO.Notes = (Reader["Notes"] != DBNull.Value && !string.IsNullOrEmpty(Reader["Notes"].ToString()))
                               ? Reader["Notes"].ToString()
                               : string.Empty;

            LicenseDTO.IsActive = Convert.ToBoolean(Reader["IsActive"]);
            LicenseDTO.CreatedByUserID = Convert.ToInt32(Reader["CreatedByUserID"]);

            return LicenseDTO;  
        }

        // Reading: Getting all the Local Licenses for a driver 
        public static DataTable GetLicensesByDriverID_InDB(int DriverID)
        {
            string Query = @"SELECT LicenseID, 
                                    SerialNumber,
                             	    ApplicationID, 
                             	    LC.LicenseClassName AS LicenseClass, 
                             	    IssueDate, 
                             	    ExpirationDate, 
                             	    IsActive 
                   
                             FROM Licenses AS L

                             INNER JOIN LicenseClasses AS LC
                             	ON L.LicenseClassID = LC.LicenseClassID
                             
                             WHERE DriverID = @DriverID
                             ORDER BY IsActive DESC; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["DriverID"] = DriverID
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }


        // Reading: Getting license By LicenseID - DriverID and LicenseClassID - ApplicationID
        public static clsLicenseDTO GetLicenseByLicenseID_InDB(int LicenseID)
        {
            string Query = @"SELECT TOP 1 * 
                             FROM Licenses AS L
                             
                             INNER JOIN Drivers AS D
                             	ON D.DriverID = L.DriverID
                             
                             INNER JOIN People AS P
                             	ON P.PersonID = D.PersonID
                             
                             WHERE L.LicenseID = @LicenseID; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["LicenseID"] = LicenseID
            };

            return clsDBManager1.GetRecord_InDB(Query, DicParameters, _FillLicenseDTO);
        }
        public static clsLicenseDTO GetLicenseBySerialNumber_InDB(string SerialNumber)
        {
            string Query = @"SELECT TOP 1 * 
                             FROM Licenses AS L
                             
                             INNER JOIN Drivers AS D
                             	ON D.DriverID = L.DriverID
                             
                             INNER JOIN People AS P
                             	ON P.PersonID = D.PersonID
                             
                             WHERE L.SerialNumber = @SerialNumber; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["SerialNumber"] = SerialNumber
            };

            return clsDBManager1.GetRecord_InDB(Query, DicParameters, _FillLicenseDTO);
        }
        public static clsLicenseDTO GetLatestActiveLicense_InDB(int DriverID, int LicenseClassID)
        {
            string Query = @"SELECT TOP 1 * 
                             FROM Licenses AS L
                             
                             INNER JOIN Drivers AS D
                             	ON D.DriverID = L.DriverID
                             
                             INNER JOIN People AS P
                             	ON P.PersonID = D.PersonID
                             
                             WHERE L.DriverID = @DriverID
                               AND L.LicenseClassID = @LicenseClassID; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["DriverID"] = DriverID,
                ["LicenseClassID"] = LicenseClassID
            };

            return clsDBManager1.GetRecord_InDB(Query, DicParameters, _FillLicenseDTO);
        }
        public static clsLicenseDTO GetLicenseByApplicationID_InDB(int ApplicationID)
        {
            string Query = @"SELECT TOP 1 * 
                             FROM Licenses AS L
                             
                             INNER JOIN Drivers AS D
                             	ON D.DriverID = L.DriverID
                             
                             INNER JOIN People AS P
                             	ON P.PersonID = D.PersonID
                             
                             WHERE L.ApplicationID = @ApplicationID; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["ApplicationID"] = ApplicationID
            };

            return clsDBManager1.GetRecord_InDB(Query, DicParameters, _FillLicenseDTO);
        }


        // Reading: Checking if driver has a license per a license class
        public static bool IsLicenseExistsByDriverIDAndLicenseClassID_InDB(int DriverID, int LicenseClassID)
        {
            string Query = @"SELECT TOP 1 FOUND = 1 
                             FROM Licenses
                             WHERE DriverID = @DriverID
                               AND LicenseClassID = @LicenseClassID; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["DriverID"] = DriverID,
                ["LicenseClassID"] = LicenseClassID
            };

            return clsDBManager1.IsExist_InDB(Query, DicParameters);
        }
        
        // Reading: Checking if driver has an active license per a license class 
        public static bool IsActiveLicenseExistsByDriverIDAndLicenseClassID_InDB(int DriverID, int LicenseClassID)
        {
            string Query = @"SELECT TOP 1 FOUND = 1 
                             FROM Licenses
                             WHERE DriverID = @DriverID
                               AND LicenseClassID = @LicenseClassID
                               AND IsActive = 1; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["DriverID"] = DriverID,
                ["LicenseClassID"] = LicenseClassID
            };

            return clsDBManager1.IsExist_InDB(Query, DicParameters);
        }


        // Reading: Getting active licenses number for the dashboard
        public static int GetActiveLicensesSystemRecordsNumber_InDB()
        {
            string Query = @"SELECT COUNT(*) AS ActiveLicenses 
                             FROM Licenses WHERE IsActive = 1; ";

            return clsDBManager1.CountRecords_InDB(Query);
        }

        // Reading: Getting Expired licenses number for the dashboard
        public static int GetExpiredLicensesSystemRecordsNumber_InDB()
        {
            string Query = @"SELECT COUNT(*) AS ActiveLicenses 
                             FROM Licenses WHERE IsActive = 0
                              AND ExpirationDate <= GETDATE(); ";

            return clsDBManager1.CountRecords_InDB(Query);
        }



        // Writing: Adding - Updating
        public static int AddNewLicense_InDB(clsLicenseDTO LicenseDTO)
        {
            string NonQuery = @"INSERT INTO [dbo].[Licenses]
                                (
                                    [SerialNumber],
                                    [LicenseClassID],
                                    [ApplicationID],
                                    [DriverID],
                                    [IssueDate],
                                    [ExpirationDate],
                                    [PaidFees],
                                    [IssueReason],
                                    [Notes],
                                    [IsActive],
                                    [CreatedByUserID]
                                )
                                VALUES
                                (
                                    @SerialNumber,
                                    @LicenseClassID,
                                    @ApplicationID,
                                    @DriverID,
                                    @IssueDate,
                                    @ExpirationDate,
                                    @PaidFees,
                                    @IssueReason,
                                    @Notes,
                                    @IsActive,
                                    @CreatedByUserID
                                );";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["SerialNumber"] = LicenseDTO.SerialNumber,
                ["LicenseClassID"] = LicenseDTO.LicenseClassID,
                ["ApplicationID"] = LicenseDTO.ApplicationID,
                ["DriverID"] = LicenseDTO.DriverDTO.DriverID,
                ["IssueDate"] = LicenseDTO.IssueDate,
                ["ExpirationDate"] = LicenseDTO.ExpirationDate,
                ["PaidFees"] = LicenseDTO.PaidFees,
                ["IssueReason"] = LicenseDTO.IssueReason,

                ["Notes"] = (string.IsNullOrEmpty(LicenseDTO.Notes))
                            ? (object)DBNull.Value
                            : LicenseDTO.Notes,

                ["IsActive"] = LicenseDTO.IsActive,
                ["CreatedByUserID"] = LicenseDTO.CreatedByUserID
            };

            return clsDBManager1.AddNewRecord_InDB(NonQuery, DicParameters);
        }
        public static bool UpdateLicense_InDB(clsLicenseDTO LicenseDTO)
        {
            string NonQuery = @"UPDATE [dbo].[Licenses]
                                SET [IsActive] = @IsActive     
                              WHERE [LicenseID] = @LicenseID;";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["IsActive"] = LicenseDTO.IsActive,

                ["LicenseID"] = LicenseDTO.LicenseID
            };

            return clsDBManager1.UpdateRecord_InDB(NonQuery, DicParameters);
        }
    }
}
