// Class: Country Data Access Layer
// Read-only country data operations
// Provides methods to retrieve country information by ID or name
// Countries table is static reference data (no insert/update/delete)

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DVLD_DAL;

namespace DVLD_DAL
{
    public class clsCountryDAL
    {
        // Data Transfer Object for country data
        public class clsCountryDTO
        {
            public clsCountryDTO(int CountryID = -1, string CountryName = "")
            {
                this.CountryID = CountryID;
                this.CountryName = CountryName;
            }

            public int CountryID { get; set; }
            public string CountryName { get; set; }
        }

        // Fills DTO from SqlDataReader
        private static clsCountryDTO _FillCountryDTO(SqlDataReader Reader)
        {
            clsCountryDTO CountryDTO = new clsCountryDTO();

            CountryDTO.CountryID = Convert.ToInt32(Reader["CountryID"]);
            CountryDTO.CountryName = (Reader["CountryName"]).ToString();

            return CountryDTO;
        }

        // Gets all countries for dropdown population
        public static DataTable GetAllCountries_InDB()
        {
            string Query = "SELECT * FROM Countries; ";

            return clsDBManager1.GetAllRecords_InDB(Query);
        }

        // Gets single country by ID
        public static clsCountryDTO GetCountry_InDB(int CountryID)
        {
            string Query = "SELECT TOP 1 * FROM Countries WHERE CountryID = @CountryID; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["CountryID"] = CountryID
            };

            return clsDBManager1.GetRecord_InDB(Query, DicParameters, _FillCountryDTO);
        }
    }
}