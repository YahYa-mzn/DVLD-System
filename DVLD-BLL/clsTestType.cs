using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DVLD_DAL;

namespace DVLD_BLL
{
    public class clsTestType
    {
        enum enMode { NullOrEmpty = 0, Update = 1 }
        public enum enTestType { VisionTest = 1, WrittenTest = 2, PracticalTest = 3 };

        public enTestType TestTypeID { get; private set; }
        public string TestTypeTitle { get; private set; }
        public string TestTypeDescription { get; private set; }
        public decimal TestTypeFees { get; private set; }

        private enMode _Mode { get; set; } = enMode.NullOrEmpty;


        private static clsTestType _Convert_clsTestTypeDTO_To_clsTestType(clsTestTypeDAL.clsTestTypeDTO TestTypeDTO)
        {
            return new clsTestType((enTestType)TestTypeDTO.TestTypeID, TestTypeDTO.TestTypeTitle, TestTypeDTO.TestTypeDescription, TestTypeDTO.TestTypeFees, enMode.Update);
        }
        private clsTestTypeDAL.clsTestTypeDTO _Convert_clsTestType_To_clsTestTypeDTO(clsTestType TestType)
        {
            return new clsTestTypeDAL.clsTestTypeDTO(Convert.ToInt32(TestType.TestTypeID), TestType.TestTypeTitle, TestType.TestTypeDescription, TestType.TestTypeFees);
        }

        private bool _Update()
        {
            return clsTestTypeDAL.UpdateTestType_InDB(_Convert_clsTestType_To_clsTestTypeDTO(this));
        }


        private clsTestType() { }
        private clsTestType(enTestType TestTypeID, string TestTypeTitle, string TestTypeDescription, decimal TestTypeFees, enMode Mode = enMode.Update)

        {
            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;

            this._Mode = Mode;
        }


        public void SetUpdatedTestTypeInfo(string TestTypeDescription, decimal TestTypeFees)
        {
            if (this._Mode != enMode.Update) return;

            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;
        }

        public static clsTestType Find(enTestType TestTypeID)
        {
            int IntTestTypeID = Convert.ToInt32(TestTypeID);
            return _Convert_clsTestTypeDTO_To_clsTestType(clsTestTypeDAL.GetTestTypeByTestTypeID_InDB(IntTestTypeID)); 
        }
        public bool Save()
        {
            return (this._Mode == enMode.Update) ? _Update() : false;
        }
        
        public static DataTable GetTestTypesList()
        {
            return clsTestTypeDAL.GetAllTestTypes_InDB();
        }
    }
}
