using System;
using DVLD_DAL;

namespace DVLD_BLL
{
    internal class clsSerialNumber
    {
        // Sql Agent job that make the latest serial number = 1 when it is a new year

        public enum enSerialNumberID
        {
            Local = 1,
            International = 2
        }

        public enSerialNumberID SerialNumberID { get; private set; }
        public string SerialNumberName { get; private set; }
        public int LatestSerialNumber { get; private set; }

        private string _Prefix
        {
            get 
            { 
                return (SerialNumberID == enSerialNumberID.Local) 
                       ? "L" 
                       : "IL"; 
            }
        }


        private static clsSerialNumber _Convert_DTO_To_Object(clsSerialNumberDAL.clsSerialNumberDTO SerialNumberDTO)
        {
            clsSerialNumber SerialNumber = new clsSerialNumber();

            SerialNumber.SerialNumberID = (enSerialNumberID) SerialNumberDTO.SerialNumberID;
            SerialNumber.SerialNumberName = SerialNumberDTO.SerialNumberName;
            SerialNumber.LatestSerialNumber = SerialNumberDTO.LatestSerialNumber;

            return SerialNumber;
        }
        private clsSerialNumberDAL.clsSerialNumberDTO _Convert_Object_To_DTO(clsSerialNumber SerialNumber)
        {
            clsSerialNumberDAL.clsSerialNumberDTO SerialNumberDTO = new clsSerialNumberDAL.clsSerialNumberDTO();

            SerialNumberDTO.SerialNumberID = Convert.ToInt32(SerialNumber.SerialNumberID);
            SerialNumberDTO.SerialNumberName = SerialNumber.SerialNumberName;
            SerialNumberDTO.LatestSerialNumber = SerialNumber.LatestSerialNumber;

            return SerialNumberDTO;
        }

        private bool _Update() => clsSerialNumberDAL.UpdateSerialNumber_InDB(_Convert_Object_To_DTO(this));


        clsSerialNumber() { }
        clsSerialNumber(enSerialNumberID SerialNumberID, string SerialNumberName, int LatestSerialNumber)
        {
            this.SerialNumberID = SerialNumberID;
            this.SerialNumberName = SerialNumberName;
            this.LatestSerialNumber = LatestSerialNumber;
        }

        public static clsSerialNumber Find(enSerialNumberID SerialNumberID) 
            => _Convert_DTO_To_Object(clsSerialNumberDAL.GetSerialNumber_InDB( Convert.ToInt32(SerialNumberID) ));
        

        private string GetAutoNumber()
        {
            if (LatestSerialNumber >= 1 && LatestSerialNumber < 10)
                return $"00000{LatestSerialNumber}";


            if (LatestSerialNumber >= 10 && LatestSerialNumber < 100)
                return $"0000{LatestSerialNumber}";


            if (LatestSerialNumber >= 100 && LatestSerialNumber < 1000)
                return $"000{LatestSerialNumber}";


            if (LatestSerialNumber >= 1000 && LatestSerialNumber < 10000)
                return $"00{LatestSerialNumber}";


            if (LatestSerialNumber >= 10000 && LatestSerialNumber < 100000)
                return $"0{LatestSerialNumber}";


            if (LatestSerialNumber >= 100000 && LatestSerialNumber < 1000000)
                return $"{LatestSerialNumber}";

            return "-1";
        }

        public string GenerateNewSerialNumber()
        {
            // Local License serial number: [L-yyyy-00000]
            // L-2026-000001

            // International License serial number: [IL-yyyy-0000]
            // IL-2026-000001

            string StrYear = DateTime.Now.Year.ToString();
            string SerialNumber = this._Prefix + "-" + StrYear + "-" + GetAutoNumber();

            return SerialNumber;
        }
        public bool UpdateLatestSerialNumber()
        {
            this.LatestSerialNumber++;
            return _Update();
        }
    }
}
