using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DAL
{
    public static class clsTestTypeDAL
    {
        public class clsTestTypeDTO
        {
            public clsTestTypeDTO() { }
            public clsTestTypeDTO(int TestTypeID, string TestTypeTitle, string TestTypeDescription, decimal TestTypeFees) 
            
            {
                this.TestTypeID = TestTypeID;
                this.TestTypeTitle = TestTypeTitle;
                this.TestTypeDescription = TestTypeDescription;
                this.TestTypeFees = TestTypeFees;
            }

            public int TestTypeID { get; set; }
            public string TestTypeTitle { get; set; }
            public string TestTypeDescription {  get; set; }
            public decimal TestTypeFees {  get; set; }
        }

        internal static clsTestTypeDTO _FillTestTypeDTO(SqlDataReader Reader)
        {
            clsTestTypeDTO TestTypeDTO = new clsTestTypeDTO();

            TestTypeDTO.TestTypeID = Convert.ToInt32(Reader["TestTypeID"]);
            TestTypeDTO.TestTypeTitle = Reader["TestTypeTitle"].ToString();
            TestTypeDTO.TestTypeDescription = Reader["TestTypeDescription"].ToString();
            TestTypeDTO.TestTypeFees = Convert.ToDecimal(Reader["TestTypeFees"]);

            return TestTypeDTO;
        }

        // Reading: Getting all test types 
        public static DataTable GetAllTestTypes_InDB()
        {
            string Query = "SELECT * FROM TestTypes;";

            return clsDBManager1.GetAllRecords_InDB(Query);
        }
        // Reading: Getting test type by TestTypeID to Update
        public static clsTestTypeDTO GetTestTypeByTestTypeID_InDB(int TestTypeID)
        {
            string Query = @"SELECT TOP 1 * FROM TestTypes 
                            WHERE TestTypeID = @TestTypeID; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["TestTypeID"] = TestTypeID
            };

            return clsDBManager1.GetRecord_InDB(Query, DicParameters, _FillTestTypeDTO);
        }

        // Writing: Updating only the description and the fees
        public static bool UpdateTestType_InDB(clsTestTypeDTO TestTypeDTO)
        {
            string NonQuery = @"UPDATE [dbo].[TestTypes]
                                   SET [TestTypeDescription] = @TestTypeDescription,
                                       [TestTypeFees] = @TestTypeFees
                                WHERE TestTypeID = @TestTypeID; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["TestTypeDescription"] = TestTypeDTO.TestTypeDescription,
                ["TestTypeFees"] = TestTypeDTO.TestTypeFees,

                ["TestTypeID"] = TestTypeDTO.TestTypeID
            };

            return clsDBManager1.UpdateRecord_InDB(NonQuery, DicParameters);
        }
    }
}
