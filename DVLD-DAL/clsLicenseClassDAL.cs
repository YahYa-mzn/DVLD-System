using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    public static class clsLicenseClassDAL
    {
        public class clsLicenseClassDTO
        {
            public clsLicenseClassDTO() { }

            public int LicenseClassID {  get; set; }
            public string LicenseClassName { get; set; }
            public string LicenseClassDescription { get; set; }
            public int MinimumAgeAllowed { get; set; }
            public int DefaultValidityLength { get; set; } 
            public decimal ClassFees {  get; set; }
        }

        internal static clsLicenseClassDTO _FillLicenseClassDTO(SqlDataReader Reader)
        {
            clsLicenseClassDTO LicenseClassDTO = new clsLicenseClassDTO();

            LicenseClassDTO.LicenseClassID = Convert.ToInt32(Reader["LicenseClassID"]);
            LicenseClassDTO.LicenseClassName = Reader["LicenseClassName"].ToString();
            LicenseClassDTO.LicenseClassDescription = Reader["LicenseClassDescription"].ToString();
            LicenseClassDTO.MinimumAgeAllowed = Convert.ToInt32(Reader["MinimumAgeAllowed"]);
            LicenseClassDTO.DefaultValidityLength = Convert.ToInt32(Reader["DefaultValidityLength"]);
            LicenseClassDTO.ClassFees = Convert.ToDecimal(Reader["ClassFees"]);

            return LicenseClassDTO;
        }

        // Reading: Getting all the license classes
        public static DataTable GetAllLicenseClasses_InDB()
        {
            string Query = @"SELECT * FROM LicenseClasses; ";

            return clsDBManager1.GetAllRecords_InDB(Query);
        }

        // Reading: Getting the license class
        public static clsLicenseClassDTO GetLicenseClassByLicenseClassID_InDB(int LicenseClassID)
        {
            string Query = @"SELECT TOP 1 * FROM LicenseClasses 
                             WHERE LicenseClassID = @LicenseClassID; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["LicenseClassID"] = LicenseClassID
            };

            return clsDBManager1.GetRecord_InDB(Query, DicParameters, _FillLicenseClassDTO);
        }
    }
}
