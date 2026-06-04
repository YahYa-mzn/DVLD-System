using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    public static class clsApplicationTypeDAL
    {
        public class clsApplicationTypeDTO
        {
            public clsApplicationTypeDTO() { }

            public clsApplicationTypeDTO(int ApplicationTypeID, string ApplicationTypeTitle, decimal ApplicationTypeFees)
            {
                this.ApplicationTypeID = ApplicationTypeID;
                this.ApplicationTypeTitle = ApplicationTypeTitle;
                this.ApplicationTypeFees = ApplicationTypeFees;
            }

            public int ApplicationTypeID { get; set; }
            public string ApplicationTypeTitle { get; set; }
            public decimal ApplicationTypeFees { get; set; }
        }

        internal static clsApplicationTypeDTO _FillApplicationTypeDTO(SqlDataReader Reader)
        {
            clsApplicationTypeDTO AppTypeDTO = new clsApplicationTypeDTO(); 

            AppTypeDTO.ApplicationTypeID = Convert.ToInt32(Reader["ApplicationTypeID"]);
            AppTypeDTO.ApplicationTypeTitle = Reader["ApplicationTypeTitle"].ToString();
            AppTypeDTO.ApplicationTypeFees = Convert.ToDecimal(Reader["ApplicationTypeFees"]);

            return AppTypeDTO;
        }

        // Reading: Getting all application types 
        public static DataTable GetAllApplicationTypes_InDB()
        {
            string Query = "SELECT * FROM ApplicationTypes; ";

            return clsDBManager1.GetAllRecords_InDB(Query);
        }
        // Reading: Getting the application type to update
        public static clsApplicationTypeDTO GetApplicationTypeByApplicationTypeID_InDB(int AppTypeID) 
        {
            string Query = @"SELECT TOP 1 * FROM ApplicationTypes 
                             WHERE ApplicationTypeID = @ApplicationTypeID;";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["ApplicationTypeID"] = AppTypeID
            };
 
            return clsDBManager1.GetRecord_InDB(Query, DicParameters,_FillApplicationTypeDTO); 
        }

        // Writing: Updating
        public static bool UpdateApplicationType_InDB(clsApplicationTypeDTO AppTypeDTO)
        {
            string NonQuery = @"UPDATE [dbo].[ApplicationTypes]
                                  SET [ApplicationTypeTitle] = @ApplicationTypeTitle, 
                                      [ApplicationTypeFees] =  @ApplicationTypeFees
                                WHERE [ApplicationTypeID] = @ApplicationTypeID; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["ApplicationTypeTitle"] = AppTypeDTO.ApplicationTypeTitle,
                ["ApplicationTypeFees"] = AppTypeDTO.ApplicationTypeFees,
                ["ApplicationTypeID"] = AppTypeDTO.ApplicationTypeID
            };

            return clsDBManager1.UpdateRecord_InDB(NonQuery, DicParameters);
        }
    }
}
