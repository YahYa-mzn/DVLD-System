using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DAL
{
    public static class clsDriverDAL
    {
        public class clsDriverDTO
        {
            public clsDriverDTO() { }

            public clsDriverDTO(int DriverID, clsPersonDAL.clsPersonDTO PersonDTO, DateTime CreationDate, int CreatedByUserID)
            {
                this.DriverID = DriverID;
                this.PersonDTO = PersonDTO;
                this.CreationDate = CreationDate;
                this.CreatedByUserID = CreatedByUserID;
            }

            public int DriverID {  get; set; }
            public clsPersonDAL.clsPersonDTO PersonDTO { get; set; }
            public DateTime CreationDate { get; set; }
            public int CreatedByUserID {  get; set; }
        }
        
        internal static clsDriverDTO _FillDriverDTO(SqlDataReader Reader)
        {
            clsDriverDTO DriverDTO = new clsDriverDTO();

            DriverDTO.DriverID = Convert.ToInt32(Reader["DriverID"]);
            DriverDTO.PersonDTO = clsPersonDAL._FillPersonDTO(Reader);
            DriverDTO.CreationDate = Convert.ToDateTime(Reader["CreationDate"]);
            DriverDTO.CreatedByUserID = Convert.ToInt32(Reader["CreatedByUserID"]);

            return DriverDTO;
        }

        // Reading: Getting all drivers with filters
        public static DataTable GetAllDriversList_InDB()
        {
            string Query = @"SELECT * FROM DriversListInfo_View; ";

            return clsDBManager1.GetAllRecords_InDB(Query);
        }
        public static DataTable GetAllDriversListFilteredByDriverID_InDB(int DriverID)
        {
            string Query = @"SELECT * FROM DriversListInfo_View 
                             WHERE DriverID = @DriverID; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["DriverID"] = DriverID
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }
        public static DataTable GetAllDriversListFilteredByPersonID_InDB(int PersonID)
        {
            string Query = @"SELECT * FROM DriversListInfo_View 
                             WHERE PersonID = @PersonID; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["PersonID"] = PersonID
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }
        public static DataTable GetAllDriversListFilteredByNationalNo_InDB(string NationalNo)
        {
            string Query = @"SELECT * FROM DriversListInfo_View 
                             WHERE NationalNo  LIKE '' + @NationalNo + '%'; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["NationalNo"] = NationalNo
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }

        // Reading: Getting all driver's number
        public static int GetSystemRecordsNumber_InDB()
        {
            string Query = @"SELECT COUNT(*) FROM Drivers; ";

            return clsDBManager.CountRecords_InDB(Query);
        }


        // Reading: Getting a driver by DriverID or PersonID
        public static clsDriverDTO GetDriver_InDB(int DriverID)
        {
            string Query = @"SELECT TOP 1 * FROM Drivers AS D 
                             INNER JOIN People AS P 
                                 ON P.PersonID = D.PersonID 
                             WHERE D.DriverID = @DriverID; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["DriverID"] = DriverID
            };

            return clsDBManager1.GetRecord_InDB(Query, DicParameters, _FillDriverDTO);
        }
        public static clsDriverDTO GetDriverByPersonID_InDB(int PersonID)
        {
            string Query = @"SELECT TOP 1 * FROM Drivers AS D 
                             INNER JOIN People AS P 
                                 ON P.PersonID = D.PersonID 
                             WHERE D.PersonID = @PersonID; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["PersonID"] = PersonID
            };

            return clsDBManager1.GetRecord_InDB(Query, DicParameters, _FillDriverDTO);
        }

        // Reading: Checking if driver exists
        public static bool IsDriverExists_InDB(int PersonID)
        {
            string Query = @"SELECT TOP 1 Found = 1 FROM Drivers AS D 
                             INNER JOIN People AS P 
                                 ON P.PersonID = D.DriverID 
                             WHERE P.PersonID = @PersonID; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["PersonID"] = PersonID
            };

            return clsDBManager1.IsExist_InDB(Query, DicParameters);
        }

        // Writing: Adding a driver
        public static int AddNewDriver_InDB(clsDriverDTO DriverDTO)
        {
            string NonQuery = @"INSERT INTO Drivers
                                (
                                    PersonID,
                                    CreationDate,
                                    CreatedByUserID
                                )
                                VALUES
                                (
                                    @PersonID,
                                    @CreationDate,
                                    @CreatedByUserID
                                ); ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["PersonID"] = DriverDTO.PersonDTO.PersonID,
                ["CreationDate"] = DriverDTO.CreationDate,
                ["CreatedByUserID"] = DriverDTO.CreatedByUserID
            };

            return clsDBManager1.AddNewRecord_InDB(NonQuery, DicParameters);
        }
    }
}
