using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DAL
{
    public static class clsApplicationDAL
    {
        public class clsApplicationDTO
        {
            public clsApplicationDTO() { }

            public int ApplicationID { get; set; }
            public clsPersonDAL.clsPersonDTO Person { get; set; }
            public int ApplicationTypeID { get; set; }
            public DateTime ApplicationDate { get; set; }
            public int ApplicationStatus { get; set; }
            public DateTime StatusModificationDate { get; set; }
            public decimal PaidFees { get; set; }
            public int CreatedByUserID { get; set; }
        }

        internal static clsApplicationDTO _FillApplicationDTO(SqlDataReader Reader)
        {
            clsApplicationDTO ApplicationDTO = new clsApplicationDTO();

            ApplicationDTO.ApplicationID = Convert.ToInt32(Reader["ApplicationID"]);
            ApplicationDTO.Person = clsPersonDAL._FillPersonDTO(Reader);
            ApplicationDTO.ApplicationTypeID = Convert.ToInt32(Reader["ApplicationTypeID"]);
            ApplicationDTO.ApplicationDate = Convert.ToDateTime(Reader["ApplicationDate"]);
            ApplicationDTO.ApplicationStatus = Convert.ToInt32(Reader["ApplicationStatus"]);

            if (Reader["StatusModificationDate"] != DBNull.Value && !string.IsNullOrEmpty(Reader["StatusModificationDate"].ToString()))
                 ApplicationDTO.StatusModificationDate = Convert.ToDateTime(Reader["StatusModificationDate"]);

            else
                ApplicationDTO.StatusModificationDate = default(DateTime);

            ApplicationDTO.PaidFees = Convert.ToDecimal(Reader["PaidFees"]);
            ApplicationDTO.CreatedByUserID = Convert.ToInt32(Reader["CreatedByUserID"]);

            return ApplicationDTO;
        }

        // Reading: Getting Application by ApplicationID
        public static clsApplicationDTO GetApplicationByApplicationID_InDB(int ApplicationID)
        {
            string Query = @"SELECT P.*, Apps.* 
                             FROM Applications AS Apps   

                             INNER JOIN People AS P 
                                ON P.PersonID = Apps.ApplicantPersonID

                             WHERE ApplicationID = @ApplicationID; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["ApplicationID"] = ApplicationID,
            };

            return clsDBManager1.GetRecord_InDB<clsApplicationDTO>(Query, DicParameters, _FillApplicationDTO);
        }


        // Writing: Adding - Updating - Deleting Application
        public static int AddNewApplication_InDB(clsApplicationDTO ApplicationDTO)
        {
            string NonQuery = @"INSERT INTO [dbo].[Applications]
                                  (ApplicantPersonID,
                                  ApplicationTypeID,
                                  ApplicationDate,
                                  ApplicationStatus,
                                  StatusModificationDate,
                                  PaidFees,
                                  CreatedByUserID)
                                VALUES
                                  (@ApplicantPersonID,
                                  @ApplicationTypeID,
                                  @ApplicationDate,
                                  @ApplicationStatus,
                                  @StatusModificationDate,
                                  @PaidFees,
                                  @CreatedByUserID);";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["ApplicantPersonID"] = ApplicationDTO.Person.PersonID,
                ["ApplicationTypeID"] = ApplicationDTO.ApplicationTypeID,
                ["ApplicationDate"] = ApplicationDTO.ApplicationDate,
                ["ApplicationStatus"] = ApplicationDTO.ApplicationStatus,

                ["StatusModificationDate"] = (ApplicationDTO.StatusModificationDate == default(DateTime))
                                             ? (object) DBNull.Value
                                             : (object) ApplicationDTO.StatusModificationDate,

                ["PaidFees"] = ApplicationDTO.PaidFees,
                ["CreatedByUserID"] = ApplicationDTO.CreatedByUserID,
            };

            return clsDBManager1.AddNewRecord_InDB(NonQuery, DicParameters);
        }
        public static bool UpdateApplication_InDB(clsApplicationDTO ApplicationDTO)
        {
            string NonQuery = @"UPDATE [dbo].[Applications]
                                SET 
                                    ApplicationStatus      = @ApplicationStatus,
                                    StatusModificationDate = @StatusModificationDate

                                WHERE ApplicationID = @ApplicationID;";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["ApplicationStatus"] = ApplicationDTO.ApplicationStatus,
                ["StatusModificationDate"] = (ApplicationDTO.StatusModificationDate == default(DateTime))
                                             ? (object) DBNull.Value
                                             : ApplicationDTO.StatusModificationDate,

                ["ApplicationID"] = ApplicationDTO.ApplicationID
            };

            return clsDBManager1.UpdateRecord_InDB(NonQuery, DicParameters);
        }
        public static bool DeleteApplication_InDB(int ApplicationID)
        {
            string NonQuery = @"DELETE FROM Applications 
                                WHERE ApplicationID = @ApplicationID; ";

            return clsDBManager1.DeleteRecord_InDB(NonQuery, "ApplicationID", ApplicationID);
        }
    }
}
