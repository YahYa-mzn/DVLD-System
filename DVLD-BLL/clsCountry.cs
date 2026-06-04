// Class: Country Business Logic
// Read-only country data access
// Provides country lookup by ID or name
// Used by Person objects to store nationality
// No CRUD operations (countries are static reference data)

using System;
using System.Data;
using DVLD_DAL;


namespace DVLD_BLL
{
    public class clsCountry
    {
        enum enMode
        {
            NullOrEmpty = 0,
            Read = 1
        }

        private enMode _Mode { get; set; } = enMode.NullOrEmpty;
        public int CountryID { get; private set; }
        public string CountryName { get; private set; }

        // Converts DTO to business object
        private static clsCountry Convert_clsCountryDTO_To_clsCountry(clsCountryDAL.clsCountryDTO CountryDTO)
        {
            return new clsCountry(CountryDTO.CountryID, CountryDTO.CountryName, enMode.Read);
        }

        // Resets country to empty state
        internal void EmptyObject()
        {
            this.CountryID = -1;
            this.CountryName = string.Empty;
        }


        private clsCountry() { }
        private clsCountry(int CountryID, string CountryName, enMode Mode = enMode.Read)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
            this._Mode = Mode;
        }


        // Finds country by ID
        internal static clsCountry Find(int CountryID)
        {
            return Convert_clsCountryDTO_To_clsCountry(clsCountryDAL.GetCountry_InDB(CountryID));
        }


        // Gets all countries for combo box population
        public static DataTable GetAllCountries()
        {
            return clsCountryDAL.GetAllCountries_InDB();
        }
    }
}