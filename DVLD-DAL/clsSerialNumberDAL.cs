using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    public static class clsSerialNumberDAL
    {
        public class clsSerialNumberDTO
        {
            public clsSerialNumberDTO() { }

            public int SerialNumberID { get; set; }
            public string SerialNumberName { get; set; }
            public int LatestSerialNumber { get; set; }
        }

        private static clsSerialNumberDTO _FillDTO(SqlDataReader Reader)
        {
            clsSerialNumberDTO SerialNumberDTO = new clsSerialNumberDTO();

            SerialNumberDTO.SerialNumberID = Convert.ToInt32(Reader["SerialNumberID"]);
            SerialNumberDTO.SerialNumberName = Reader["SerialNumberName"].ToString();
            SerialNumberDTO.LatestSerialNumber = Convert.ToInt32(Reader["LatestSerialNumber"]);

            return SerialNumberDTO;
        }

        // Reading: Getting the serial number by ID
        public static clsSerialNumberDTO GetSerialNumber_InDB(int SerialNumberID)
        {
            string Query = @"SELECT * FROM SerialNumbers WHERE SerialNumberID = @SerialNumberID; ";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["SerialNumberID"] = SerialNumberID
            };

            return clsDBManager1.GetRecord_InDB<clsSerialNumberDTO>(Query, DicParameters, _FillDTO);
        }


        // Writing: Updating
        public static bool UpdateSerialNumber_InDB(clsSerialNumberDTO SerialNumberDTO)
        {
            string NonQuery = @"UPDATE [dbo].[SerialNumbers]
                                   SET [LatestSerialNumber] = @LatestSerialNumber
                                 WHERE [SerialNumberID] = @SerialNumberID;";

            Dictionary<string, object> DicParameters = new Dictionary<string, object>()
            {
                ["LatestSerialNumber"] = SerialNumberDTO.LatestSerialNumber,

                ["SerialNumberID"] = SerialNumberDTO.SerialNumberID
            };

            return clsDBManager1.UpdateRecord_InDB(NonQuery, DicParameters);
        }


    }
}
