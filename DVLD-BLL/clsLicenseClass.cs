using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using DVLD_DAL;

namespace DVLD_BLL
{
    public class clsLicenseClass
    {
        enum enMode { NullOrEmpty = 0, Read = 1}

        public enum enLicenseClass
        {
            Class1_SmallMotorcycle = 1,
            Class2_HeavyMotorcycle = 2,
            Class3_OrdinaryDriving = 3,
            Class4_Commercial = 4,
            Class5_Agricultural = 5,
            Class6_SmallAndMediumBus = 6,
            Class7_TruckAndHeavyVehicle = 7
        }

        public enLicenseClass LicenseClassID { get; private set; }
        public string LicenseClassName { get; private set; }
        public string LicenseClassDescription { get; private set; }
        public int MinimumAgeAllowed { get; private set; }
        public int DefaultValidityLength { get; private set; }
        public decimal ClassFees { get; private set; }

        public DateTime ExpirationDate
        {
            get { return DateTime.Today.AddYears(this.DefaultValidityLength); }
        }

        private enMode _Mode { get; set; } = enMode.NullOrEmpty;

        private static clsLicenseClass _Convert_clsLicenseClassDTO_To_clsLicenseClass(clsLicenseClassDAL.clsLicenseClassDTO LicenseClassDTO)
        {
            clsLicenseClass LicenseClass = new clsLicenseClass();

            LicenseClass.LicenseClassID = (enLicenseClass)LicenseClassDTO.LicenseClassID;
            LicenseClass.LicenseClassName = LicenseClassDTO.LicenseClassName;
            LicenseClass.LicenseClassDescription = LicenseClassDTO.LicenseClassDescription;
            LicenseClass.MinimumAgeAllowed = LicenseClassDTO.MinimumAgeAllowed;
            LicenseClass.DefaultValidityLength = LicenseClassDTO.DefaultValidityLength;
            LicenseClass.ClassFees = LicenseClassDTO.ClassFees;

            return LicenseClass;
        }
        private static clsLicenseClassDAL.clsLicenseClassDTO _Convert_clsLicenseClass_To_clsLicenseClassDTO(clsLicenseClass LicenseClass)
        {
            clsLicenseClassDAL.clsLicenseClassDTO LicenseClassDTO = new clsLicenseClassDAL.clsLicenseClassDTO();

            LicenseClassDTO.LicenseClassID = Convert.ToInt32(LicenseClass.LicenseClassID);
            LicenseClassDTO.LicenseClassName = LicenseClass.LicenseClassName;
            LicenseClassDTO.LicenseClassDescription = LicenseClass.LicenseClassDescription;
            LicenseClassDTO.MinimumAgeAllowed = LicenseClass.MinimumAgeAllowed;
            LicenseClassDTO.DefaultValidityLength = LicenseClass.DefaultValidityLength;
            LicenseClassDTO.ClassFees = LicenseClass.ClassFees;

            return LicenseClassDTO;
        }

        internal void _EmptyObject()
        {
            this.LicenseClassName = string.Empty;
            this.LicenseClassDescription = string.Empty;
            this.MinimumAgeAllowed = 0;
            this.DefaultValidityLength = 0;
            this.ClassFees = 0;

            this._Mode = enMode.NullOrEmpty;
        }


        clsLicenseClass() { }
        clsLicenseClass(enLicenseClass LicenseClassID, string LicenseClassName, string LicenseClassDescription, int MinimumAgeAllowed, int DefaultValidityLength, decimal ClassFees, enMode Mode)
        {
            this.LicenseClassID = LicenseClassID;
            this.LicenseClassName = LicenseClassName;
            this.LicenseClassDescription = LicenseClassDescription;
            this.MinimumAgeAllowed = MinimumAgeAllowed;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;
            this._Mode = Mode;
        }


       

        public static clsLicenseClass Find(enLicenseClass LicenseClassID) => _Convert_clsLicenseClassDTO_To_clsLicenseClass(clsLicenseClassDAL.GetLicenseClassByLicenseClassID_InDB(Convert.ToInt32(LicenseClassID)));
        public static DataTable GetLicenseClassesList() => clsLicenseClassDAL.GetAllLicenseClasses_InDB(); 
    }
}
