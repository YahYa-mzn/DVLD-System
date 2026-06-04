using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DAL;

namespace DVLD_BLL
{
    public class clsApplicationType
    {
        enum enMode { NullOrEmpty = 0, Update = 1 }
        public enum enApplicationType 
        {
            NewLocalDrivingLicenseService = 1,
            RenewDrivingLicenseService = 2,
            ReplacementForLostDrivingLicense = 3,
            ReplacementForDamagedDrivingLicense = 4,
            ReleaseDetainedDrivingLicense = 5,
            NewInternationalLicense = 6,
            RetakeTest = 7,
            ReactivateLocalDrivingLicenseApplication = 8
        }

        public enApplicationType ApplicationTypeID { get; private set; }
        public string ApplicationTypeTitle { get; private set; }
        public decimal ApplicationTypeFees { get; private set; }

        private enMode _Mode { get; set; } = enMode.NullOrEmpty;

        internal static clsApplicationType _Convert_clsApplicationTypeDTO_To_clsApplicationType(clsApplicationTypeDAL.clsApplicationTypeDTO AppTypeDTO)
        {
            return new clsApplicationType((enApplicationType)AppTypeDTO.ApplicationTypeID,  AppTypeDTO.ApplicationTypeTitle, AppTypeDTO.ApplicationTypeFees, enMode.Update);
        }
        internal static clsApplicationTypeDAL.clsApplicationTypeDTO _Convert_clsApplicationType_To_clsApplicationTypeDTO(clsApplicationType AppType)
        {
            return new clsApplicationTypeDAL.clsApplicationTypeDTO(Convert.ToInt32(AppType.ApplicationTypeID), AppType.ApplicationTypeTitle, AppType.ApplicationTypeFees);
        }

        private bool _Update()
        {
            return clsApplicationTypeDAL.UpdateApplicationType_InDB(_Convert_clsApplicationType_To_clsApplicationTypeDTO(this));
        }


        private clsApplicationType(enApplicationType ApplicationTypeID, string ApplicationTypeTitle, decimal ApplicationTypeFees, enMode Mode = enMode.Update)
        {
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationTypeFees = ApplicationTypeFees;
            this._Mode = Mode;
        }
        
        public bool SetUpdatedAppTypeInfo(string ApplicationTypeTitle, decimal ApplicationTypeFees)
        {
            if (this._Mode != enMode.Update) return false;

            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationTypeFees = ApplicationTypeFees;

            return this.Save();
        }
        public static clsApplicationType Find(enApplicationType AppTypeID)
        {
            int IntAppTypeID = Convert.ToInt32(AppTypeID);
            return _Convert_clsApplicationTypeDTO_To_clsApplicationType(clsApplicationTypeDAL.GetApplicationTypeByApplicationTypeID_InDB(IntAppTypeID));   
        }
        
        public bool Save()
        {
            return (this._Mode == enMode.Update) ? _Update() : false;
        }

        public static DataTable GetApplicationTypesList()
        {
            return clsApplicationTypeDAL.GetAllApplicationTypes_InDB();
        }
    }
}
