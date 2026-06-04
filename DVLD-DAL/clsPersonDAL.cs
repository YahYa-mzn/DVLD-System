// Class: Person Data Access Layer
// Handles all database operations for People table
// Provides extensive filtering options for people management
// Supports soft delete (IsMarkedToDelete flag) and permanent delete
// Handles optional name fields (SecondName, ThirdName)
// Validates unique constraints (NationalNo, Phone, Email)
// NOTE: Contains many methods due to multiple filter combinations
//       Author notes this should be code-generated to reduce repetition

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Permissions;
using System.Text;
using DVLD_DAL;

namespace DVLD_DAL
{
    public class clsPersonDAL
    {
        // Data Transfer Object for person data
        public class clsPersonDTO
        {
            public clsPersonDTO() { }

            public int PersonID { get; set; }
            public string NationalNo { get; set; }
            public string FirstName { get; set; }
            public string SecondName { get; set; }
            public string ThirdName { get; set; }
            public string LastName { get; set; }
            public char Gender { get; set; }
            public DateTime BirthDate { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public int CountryID { get; set; }
            public string ImagePath { get; set; }
            public bool IsMarkedToDelete { get; set; }
        }

        // Fills DTO from SqlDataReader
        internal static clsPersonDTO _FillPersonDTO(SqlDataReader Reader)
        {
            clsPersonDTO PersonDTO = new clsPersonDTO();

            PersonDTO.PersonID = Convert.ToInt32(Reader["PersonID"]);
            PersonDTO.NationalNo = Reader["NationalNo"].ToString();
            PersonDTO.FirstName = Reader["FirstName"].ToString();

            // Handle optional name fields
            PersonDTO.SecondName = string.IsNullOrEmpty(Reader["SecondName"].ToString())
                                    ? ""
                                    : Reader["SecondName"].ToString();

            PersonDTO.ThirdName = string.IsNullOrEmpty(Reader["ThirdName"].ToString())
                                    ? ""
                                    : Reader["ThirdName"].ToString();

            PersonDTO.LastName = Reader["LastName"].ToString();
            PersonDTO.Gender = Convert.ToChar(Reader["Gender"]);
            PersonDTO.BirthDate = Convert.ToDateTime(Reader["BirthDate"]);
            PersonDTO.Phone = Reader["Phone"].ToString();
            PersonDTO.Email = Reader["Email"].ToString();
            PersonDTO.Address = Reader["Address"].ToString();
            PersonDTO.CountryID = Convert.ToInt32(Reader["CountryID"]);

            PersonDTO.ImagePath = string.IsNullOrEmpty(Reader["ImagePath"].ToString())
                                    ? ""
                                    : Reader["ImagePath"].ToString();

            PersonDTO.IsMarkedToDelete = Convert.ToBoolean(Reader["IsMarkedToDelete"]);

            return PersonDTO;

        }


        // Reading: getting active/deleted people in the system 
        public static DataTable GetAllPeople_InDB()
        {
            string Query = @"SELECT P.*, C.CountryName AS Nationality 
                           FROM People AS P 
                           INNER JOIN Countries AS C 
                           ON P.CountryID = C.CountryID; ";

            return clsDBManager1.GetAllRecords_InDB(Query);
        }
        public static DataTable GetAllPeopleFilteredByPersonID_InDB(int PersonID)
        {
            string Query = @"SELECT P.*, C.CountryName AS Nationality 
                           FROM People AS P 
                           INNER JOIN Countries AS C 
                           ON P.CountryID = C.CountryID
                           WHERE PersonID = @PersonID; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["PersonID"] = PersonID
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }
        public static DataTable GetAllPeopleFilteredByNationalNo_InDB(string NationalNo)
        {
            string Query = @"SELECT P.*, C.CountryName AS Nationality 
                           FROM People AS P 
                           INNER JOIN Countries AS C 
                           ON P.CountryID = C.CountryID
                           WHERE NationalNo LIKE '' + @NationalNo + '%'; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["NationalNo"] = NationalNo
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }
        public static DataTable GetAllPeopleFilteredByFirstName_InDB(string FirstName)
        {
            string Query = @"SELECT P.*, C.CountryName AS Nationality 
                           FROM People AS P 
                           INNER JOIN Countries AS C 
                           ON P.CountryID = C.CountryID
                           WHERE FirstName LIKE '' + @FirstName + '%'; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["FirstName"] = FirstName
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }
        public static DataTable GetAllPeopleFilteredBySecondName_InDB(string SecondName)
        {
            string Query = @"SELECT P.*, C.CountryName AS Nationality 
                           FROM People AS P 
                           INNER JOIN Countries AS C 
                           ON P.CountryID = C.CountryID
                           WHERE SecondName LIKE '' + @SecondName + '%'; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["SecondName"] = SecondName
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }
        public static DataTable GetAllPeopleFilteredByThirdName_InDB(string ThirdName)
        {
            string Query = @"SELECT P.*, C.CountryName AS Nationality 
                           FROM People AS P 
                           INNER JOIN Countries AS C 
                           ON P.CountryID = C.CountryID
                           WHERE ThirdName LIKE '' + @ThirdName + '%'; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["ThirdName"] = ThirdName
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }
        public static DataTable GetAllPeopleFilteredByLastName_InDB(string LastName)
        {
            string Query = @"SELECT P.*, C.CountryName AS Nationality 
                           FROM People AS P 
                           INNER JOIN Countries AS C 
                           ON P.CountryID = C.CountryID
                           WHERE LastName LIKE '' + @LastName + '%'; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["LastName"] = LastName
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }
        public static DataTable GetAllPeopleFilteredByPhone_InDB(string Phone)
        {
            string Query = @"SELECT P.*, C.CountryName AS Nationality 
                           FROM People AS P 
                           INNER JOIN Countries AS C 
                           ON P.CountryID = C.CountryID
                           WHERE Phone LIKE '' + @Phone + '%'; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["Phone"] = Phone
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }
        public static DataTable GetAllPeopleFilteredByEmail_InDB(string Email)
        {
            string Query = @"SELECT P.*, C.CountryName AS Nationality 
                           FROM People AS P 
                           INNER JOIN Countries AS C 
                           ON P.CountryID = C.CountryID
                           WHERE Email LIKE '' + @Email + '%'; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["Email"] = Email
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }


        // Reading: getting only the active or only the deleted people in the system
        public static DataTable GetPeopleFilteredByIsMarkedToDelete_InDB(bool IsMarkedToDelete)
        {
            string Query = @"SELECT P.*, C.CountryName AS Nationality 
                   FROM People AS P 
                   INNER JOIN Countries AS C 
                   ON P.CountryID = C.CountryID
                   WHERE IsMarkedToDelete = @IsMarkedToDelete; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["IsMarkedToDelete"] = IsMarkedToDelete
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }
        public static DataTable GetPeopleFilteredByIsMarkedToDeleteAndPersonID_InDB(int PersonID, bool IsMarkedToDelete)
        {
            string Query = @"SELECT P.*, C.CountryName AS Nationality 
                   FROM People AS P 
                   INNER JOIN Countries AS C 
                   ON P.CountryID = C.CountryID
                   WHERE IsMarkedToDelete = @IsMarkedToDelete
                   AND PersonID = @PersonID; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["PersonID"] = PersonID,
               ["IsMarkedToDelete"] = IsMarkedToDelete
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }
        public static DataTable GetPeopleFilteredByIsMarkedToDeleteAndNationalNo_InDB(string NationalNo, bool IsMarkedToDelete)
        {
            string Query = @"SELECT P.*, C.CountryName AS Nationality 
                   FROM People AS P 
                   INNER JOIN Countries AS C 
                   ON P.CountryID = C.CountryID
                   WHERE IsMarkedToDelete = @IsMarkedToDelete
                   AND NationalNo LIKE '' + @NationalNo + '%'; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["NationalNo"] = NationalNo,
                ["IsMarkedToDelete"] = IsMarkedToDelete
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }
        public static DataTable GetPeopleFilteredByIsMarkedToDeleteAndFirstName_InDB(string FirstName, bool IsMarkedToDelete)
        {
            string Query = @"SELECT P.*, C.CountryName AS Nationality 
                   FROM People AS P 
                   INNER JOIN Countries AS C 
                   ON P.CountryID = C.CountryID
                   WHERE IsMarkedToDelete = @IsMarkedToDelete
                   AND FirstName LIKE '' + @FirstName + '%'; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["FirstName"] = FirstName,
               ["IsMarkedToDelete"] = IsMarkedToDelete
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }
        public static DataTable GetPeopleFilteredByIsMarkedToDeleteAndSecondName_InDB(string SecondName, bool IsMarkedToDelete)
        {
            string Query = @"SELECT P.*, C.CountryName AS Nationality 
                   FROM People AS P 
                   INNER JOIN Countries AS C 
                   ON P.CountryID = C.CountryID
                   WHERE IsMarkedToDelete = @IsMarkedToDelete
                   AND SecondName LIKE '' + @SecondName + '%'; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["SecondName"] = SecondName,
               ["IsMarkedToDelete"] = IsMarkedToDelete
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }
        public static DataTable GetPeopleFilteredByIsMarkedToDeleteAndThirdName_InDB(string ThirdName, bool IsMarkedToDelete)
        {
            string Query = @"SELECT P.*, C.CountryName AS Nationality 
                   FROM People AS P 
                   INNER JOIN Countries AS C 
                   ON P.CountryID = C.CountryID
                   WHERE IsMarkedToDelete = @IsMarkedToDelete
                   AND ThirdName LIKE '' + @ThirdName + '%'; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["ThirdName"] = ThirdName,
               ["IsMarkedToDelete"] = IsMarkedToDelete
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }
        public static DataTable GetPeopleFilteredByIsMarkedToDeleteAndLastName_InDB(string LastName, bool IsMarkedToDelete)
        {
            string Query = @"SELECT P.*, C.CountryName AS Nationality 
                   FROM People AS P 
                   INNER JOIN Countries AS C 
                   ON P.CountryID = C.CountryID
                   WHERE IsMarkedToDelete = @IsMarkedToDelete
                   AND LastName LIKE '' + @LastName + '%'; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["LastName"] = LastName,
                ["IsMarkedToDelete"] = IsMarkedToDelete
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }
        public static DataTable GetPeopleFilteredByIsMarkedToDeleteAndPhone_InDB(string Phone, bool IsMarkedToDelete)
        {
            string Query = @"SELECT P.*, C.CountryName AS Nationality 
                   FROM People AS P 
                   INNER JOIN Countries AS C 
                   ON P.CountryID = C.CountryID
                   WHERE IsMarkedToDelete = @IsMarkedToDelete
                   AND Phone LIKE '' + @Phone + '%'; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["Phone"] = Phone,
               ["IsMarkedToDelete"] = IsMarkedToDelete
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }
        public static DataTable GetPeopleFilteredByIsMarkedToDeleteAndEmail_InDB(string Email, bool IsMarkedToDelete)
        {
            string Query = @"SELECT P.*, C.CountryName AS Nationality 
                   FROM People AS P 
                   INNER JOIN Countries AS C 
                   ON P.CountryID = C.CountryID
                   WHERE IsMarkedToDelete = @IsMarkedToDelete
                   AND Email LIKE '' + @Email + '%'; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["Email"] = Email,
                ["IsMarkedToDelete"] = IsMarkedToDelete
            };

            return clsDBManager1.GetAllRecordsFilteredBy_InDB(Query, DicParameters);
        }

        
        // Reading: getting only one person
        public static clsPersonDTO GetPersonByPersonID_InDB(int PersonID)
        {
            string Query = @"SELECT TOP 1 * FROM People                         
                            WHERE PersonID = @PersonID; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["PersonID"] = PersonID
            };

            return clsDBManager1.GetRecord_InDB(Query, DicParameters, _FillPersonDTO);
        }
        public static clsPersonDTO GetPersonByNationalNo_InDB(string NationalNo)
        {
            string Query = @"SELECT TOP 1 * FROM People                        
                            WHERE NationalNo = @NationalNo; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["NationalNo"] = NationalNo
            };

            return clsDBManager1.GetRecord_InDB(Query, DicParameters, _FillPersonDTO);
        }


        // Reading: counting records
        public static int GetAllSystemRecordsNumber_InDB()
        {
            string Query = "SELECT COUNT(*) FROM People;";

            return clsDBManager1.CountRecords_InDB(Query);
        }
        public static int GetSystemRecordsNumberFilteredByIsMarkedToDelete_InDB(bool IsMarkedToDelete)
        {
            string Query = "SELECT COUNT(*) FROM People WHERE IsMarkedToDelete = @IsMarkedToDelete; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["IsMarkedToDelete"] = IsMarkedToDelete 
            };

            return clsDBManager1.CountRecords_InDB(Query, DicParameters);
        }
        

        // Reading: checking the existance of unique the fields
        public static bool IsExistsByNationalNo_InDB(string NationalNo)
        {
            string Query = @"SELECT TOP 1 Found = 1 FROM People 
                             WHERE NationalNo = @NationalNo; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["NationalNo"] = NationalNo
            };

            return clsDBManager1.IsExist_InDB(Query, DicParameters);
        }
        public static bool IsExistsByPhone_InDB(string Phone)
        {
            string Query = @"SELECT TOP 1 Found = 1 FROM People 
                             WHERE Phone = @Phone; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["Phone"] = Phone
            };

            return clsDBManager1.IsExist_InDB(Query, DicParameters);
        }
        public static bool IsExistsByEmail_InDB(string Email)
        {
            string Query = @"SELECT TOP 1 Found = 1 FROM People 
                             WHERE Email = @Email; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["Email"] = Email
            };

            return clsDBManager1.IsExist_InDB(Query, DicParameters);
        }


        // Writing: Adding - Updating - Deleting
        public static int AddNewPerson_InDB(clsPersonDTO PersonDTO)
        {
            string NonQuery = @"INSERT INTO [dbo].[People] 
                                ([NationalNo], [FirstName], [SecondName], [ThirdName], [LastName], 
                                [Gender], [BirthDate], [Phone], [Email], [Address],
                                [CountryID], [ImagePath], [IsMarkedToDelete]) 
                                VALUES 
                                (@NationalNo, @FirstName, @SecondName, @ThirdName , @LastName ,
                                @Gender , @BirthDate, @Phone, @Email, @Address,
                                @CountryID, @ImagePath ,@IsMarkedToDelete); ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["NationalNo"] = PersonDTO.NationalNo,
                ["FirstName"] = PersonDTO.FirstName,
                ["SecondName"] = PersonDTO.SecondName,
                ["ThirdName"] = PersonDTO.ThirdName,
                ["LastName"] = PersonDTO.LastName,
                ["Gender"] = PersonDTO.Gender,
                ["BirthDate"] = PersonDTO.BirthDate,
                ["Phone"] = PersonDTO.Phone,
                ["Email"] = PersonDTO.Email,
                ["Address"] = PersonDTO.Address,
                ["CountryID"] = PersonDTO.CountryID,
                ["ImagePath"] = PersonDTO.ImagePath,
                ["IsMarkedToDelete"] = PersonDTO.IsMarkedToDelete,
            };

            return clsDBManager1.AddNewRecord_InDB(NonQuery, DicParameters);
        }
        public static bool UpdatePerson_InDB(clsPersonDTO PersonDTO)
        {
            string NonQuery = @"UPDATE [dbo].[People] SET 

                               [NationalNo] = @NationalNo,
                               [FirstName] = @FirstName,
                               [SecondName] = @SecondName, 
                               [ThirdName] = @ThirdName,
                               [LastName] = @LastName,
                               [Gender] = @Gender,
                               [BirthDate] = @BirthDate,
                               [Phone] = @Phone, 
                               [Email] = @Email,
                               [Address] = @Address,
                               [CountryID] = @CountryID,
                               [ImagePath] = @ImagePath, 
                               [IsMarkedToDelete] = @IsMarkedToDelete 

                               WHERE [PersonID] = @PersonID; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["NationalNo"] = PersonDTO.NationalNo,
                ["FirstName"] = PersonDTO.FirstName,
                ["SecondName"] = PersonDTO.SecondName,
                ["ThirdName"] = PersonDTO.ThirdName,
                ["LastName"] = PersonDTO.LastName,
                ["Gender"] = PersonDTO.Gender,
                ["BirthDate"] = PersonDTO.BirthDate,
                ["Phone"] = PersonDTO.Phone,
                ["Email"] = PersonDTO.Email,
                ["Address"] = PersonDTO.Address,
                ["CountryID"] = PersonDTO.CountryID,
                ["ImagePath"] = PersonDTO.ImagePath,
                ["IsMarkedToDelete"] = PersonDTO.IsMarkedToDelete,

                ["PersonID"] = PersonDTO.PersonID
            };

            return clsDBManager1.UpdateRecord_InDB(NonQuery, DicParameters);
        }
        public static bool DeletePerson_InDB(int PersonID)
        {
            string NonQuery = @"DELETE FROM People WHERE PersonID = @PersonID; ";

            return clsDBManager1.DeleteRecord_InDB(NonQuery, "PersonID", PersonID);
        }

    }
}