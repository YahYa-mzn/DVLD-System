using System;
using System.Data;
using System.Xml.Linq;
using DVLD_DAL;

namespace DVLD_BLL
{
    public class clsApplication
    {
        public enum enReadMode
        {
            None = 0,
            New = 1,
            Canceled = 2,
            Completed = 3
        }

        protected enum enMode
        {
            NullOrEmpty = 0, 
            AddNew = 1,
            Update = 2,
            Delete = 3
        }
        public enum enApplicationStatus
        {
            New = 1, 
            Canceled = 2,
            Completed = 3
        }


        public int ApplicationID { get; private set; }
        public clsPerson Person { get; private set; }
        public clsApplicationType ApplicationType { get; private set; }
        public DateTime ApplicationDate { get; private set; }

        // You should complete the application based on certain conditions 
        // So modify it in the child class or the class that do composition on it
        public enApplicationStatus ApplicationStatus { get; protected set; } 
        public DateTime StatusModificationDate { get; protected set; }
        public decimal PaidFees { get; private set; }
        public int CreatedByUserID { get; private set; }

        protected enMode _Mode { get; set; } = enMode.NullOrEmpty;


        protected static clsApplication _Convert_clsApplicationDTO_To_clsApplication(clsApplicationDAL.clsApplicationDTO ApplicationDTO)
        {
            clsApplication Application = new clsApplication();  

            Application.ApplicationID = ApplicationDTO.ApplicationID;
            Application.Person = clsPerson._Convert_DTO_To_Object(ApplicationDTO.Person);

            // Lazy loading for this class (Small)
            Application.ApplicationType = clsApplicationType.Find( (clsApplicationType.enApplicationType) ApplicationDTO.ApplicationTypeID );

            Application.ApplicationDate = ApplicationDTO.ApplicationDate;
            Application.ApplicationStatus = (enApplicationStatus)ApplicationDTO.ApplicationStatus;
            Application.StatusModificationDate = ApplicationDTO.StatusModificationDate;
            Application.PaidFees = ApplicationDTO.PaidFees;
            Application.CreatedByUserID = ApplicationDTO.CreatedByUserID;

            Application._Mode = enMode.Update;

            return Application;
        }
        protected static clsApplicationDAL.clsApplicationDTO _Convert_clsApplication_To_clsApplicationDTO(clsApplication Application)
        {
            clsApplicationDAL.clsApplicationDTO ApplicationDTO = new clsApplicationDAL.clsApplicationDTO();

            ApplicationDTO.ApplicationID = Application.ApplicationID;
            ApplicationDTO.Person = clsPerson._Convert_Object_To_DTO(Application.Person);
            ApplicationDTO.ApplicationTypeID = Convert.ToInt32(Application.ApplicationType.ApplicationTypeID);
            ApplicationDTO.ApplicationDate = Application.ApplicationDate;
            ApplicationDTO.ApplicationStatus = Convert.ToInt32(Application.ApplicationStatus);
            ApplicationDTO.StatusModificationDate = Application.StatusModificationDate;
            ApplicationDTO.PaidFees = Application.PaidFees;
            ApplicationDTO.CreatedByUserID = Application.CreatedByUserID;

            return ApplicationDTO;
        }

        private void _EmptyObject()
        {
            this.ApplicationID = -1;
            this.Person._EmptyObject();
            this.ApplicationType = null; // bc the ApplicationTypes are fixed in the system, and you cant empty its info
            this.ApplicationDate = default(DateTime);
            this.ApplicationStatus = enApplicationStatus.Canceled;
            this.StatusModificationDate = default(DateTime);
            this.PaidFees = 0;
            this.CreatedByUserID = -1;

            this._Mode = enMode.NullOrEmpty;
        }

        private bool _AddNew()
        {
            this.ApplicationID = clsApplicationDAL.AddNewApplication_InDB(_Convert_clsApplication_To_clsApplicationDTO(this));

            return (this.ApplicationID != -1);
        }
        private bool _Update()
        {
            return clsApplicationDAL.UpdateApplication_InDB(_Convert_clsApplication_To_clsApplicationDTO(this));
        }
        private bool _Delete()
        {
            if (clsApplicationDAL.DeleteApplication_InDB(this.ApplicationID))
            {
                this._EmptyObject();
                return true;
            }

            return false;
        }


        private clsApplication() { }
        protected clsApplication(int ApplicationID, clsPerson Person, clsApplicationType ApplicationType, DateTime ApplicationDate, enApplicationStatus ApplicationStatus, 
                       DateTime StatusModificationDate, decimal PaidFees, int CreatedByUserID, enMode Mode = enMode.Update)
        {
            this.ApplicationID = ApplicationID;
            this.Person = Person;
            this.ApplicationType = ApplicationType;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationStatus = ApplicationStatus;
            this.StatusModificationDate = StatusModificationDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;

            this._Mode = Mode;
        }


        internal static clsApplication GetAddNewApplicationObject(clsPerson Person, clsApplicationType ApplicationType, int CreatedByUserID)
        {
            if (Person == null) return null;
            if (!clsUser.IsUserExists(CreatedByUserID)) return null;

            return new clsApplication(-1, Person, ApplicationType, DateTime.Now, enApplicationStatus.New, default(DateTime),
                                      ApplicationType.ApplicationTypeFees, CreatedByUserID, enMode.AddNew);
        }

        internal static clsApplication Find(int ApplicationID)
        {
            return (ApplicationID != -1)
                   ? _Convert_clsApplicationDTO_To_clsApplication(clsApplicationDAL.GetApplicationByApplicationID_InDB(ApplicationID))
                   : null;
        }
        
        public bool CancelApplication()
        {
            if (this._Mode != enMode.Update) return false;
            if (this.ApplicationStatus != enApplicationStatus.New) return false;

            this.ApplicationStatus = enApplicationStatus.Canceled;
            this.StatusModificationDate = DateTime.Now;

            return this.SaveBaseApplication();
        }
        internal bool CompleteApplication()
        {
            if (this._Mode != enMode.Update) return false;

            this.ApplicationStatus = enApplicationStatus.Completed;
            this.StatusModificationDate = DateTime.Now;

            return this.SaveBaseApplication();
        }
        public bool ReactivateApplication(int ReactivatedByUserID)
        {
            if (this._Mode != enMode.Update) return false;
            if (this.ApplicationStatus != enApplicationStatus.Canceled) return false;

            clsApplication ReactivatingApplication = GetAddNewApplicationObject(this.Person,
                                                                    clsApplicationType.Find(clsApplicationType.enApplicationType.ReactivateLocalDrivingLicenseApplication),
                                                                    ReactivatedByUserID);
            if (ReactivatingApplication == null) return false;  
            if (!ReactivatingApplication.SaveBaseApplication()) return false;

            this.ApplicationStatus = enApplicationStatus.New;
            if (!this.SaveBaseApplication()) return false;
            
            return ReactivatingApplication.CompleteApplication();
        }

        public void PrepareObjectToDelete()
        {
            if (ApplicationStatus == enApplicationStatus.Completed) return;

            this._Mode = enMode.Delete;
        }

        internal virtual bool SaveBaseApplication()
        {
            switch (this._Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        this._Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _Update();

                default:
                    return false;
            }
        }
        internal virtual bool DeleteBaseApplication()
        {
            return (this._Mode == enMode.Delete && this.ApplicationStatus != enApplicationStatus.Completed)
                    ? _Delete() 
                    : false;
        }

        protected static int _GetIntApplicationStatusByReadMode(enReadMode ReadMode)
        {
            switch (ReadMode)
            {
                case enReadMode.None:
                    return -1;

                case enReadMode.New:
                    return Convert.ToInt32(enApplicationStatus.New);

                case enReadMode.Canceled:
                    return Convert.ToInt32(enApplicationStatus.Canceled);

                case enReadMode.Completed:
                    return Convert.ToInt32(enApplicationStatus.Completed);

                default:
                    return -1;
            }
        }
    }
}
