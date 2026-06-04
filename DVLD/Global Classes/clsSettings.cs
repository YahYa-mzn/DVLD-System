// Class: Application Settings
// Centralized configuration for paths and constants
// Contains:
//   - People: Age limits, default images, folder paths
//   - Users: Remember me file, password visibility icons
//   - License Classes: class name

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Global_Classes
{
    internal static class clsSettings
    {
        public static string ImgTrue = @"C:\Users\user\Desktop\DVLD\Utilities\Icons\Icons\True.png";
        public static string ImgPending = @"C:\Users\user\Desktop\DVLD\Utilities\Icons\Icons\Pending.png";
        public static string ImgFalse = @"C:\Users\user\Desktop\DVLD\Utilities\Icons\Icons\False.png";

        public static string ImgUnlocked = @"C:\Users\user\Desktop\DVLD\Utilities\Icons\Icons\unlock_add (1).png";
        public static string ImgLocked = @"C:\Users\user\Desktop\DVLD\Utilities\Icons\Icons\lock_close (1).png";

        // People-related settings
        public static class clsPeople
        {
            public static int MaxAge = 60;
            public static int MinAge = 18;
            public static string DefaultCountryName = "Morocco";
            public static string InitialSaveFileDlgDir = @"C:\Users\user\Desktop";
            public static string FolderImagesPath = @"C:\Users\user\Desktop\DVLD\People Images";
            public static string DefaultMaleImagePath = @"C:\Users\user\Desktop\DVLD\Utilities\Icons\Icons\Male 512.png";
            public static string DefaultFemaleImagePath = @"C:\Users\user\Desktop\DVLD\Utilities\Icons\Icons\Female 512.png";
        }

        // User-related settings
        public static class clsUsers
        {
            public static string RememberMeFile = @"C:\Users\user\Desktop\DVLD\Remember Me.txt";
            public static string ShowPasswordPicPath = @"C:\Users\user\Desktop\DVLD\Utilities\Icons\Icons\Visible.png";
            public static string HidePasswordPicPath = @"C:\Users\user\Desktop\DVLD\Utilities\Icons\Icons\Invisible.png";
        }

        // License Classes-related settings
        public static class clsLicenseClasses
        {
            public static string DefaultLicenseClassName = "Class 3 - Ordinary Driving";
        }

        public static class clsTests
        {
            public static string VisionTestImagePath = @"C:\Users\user\Desktop\DVLD\Utilities\Icons\Icons\Vision Test 32.png";
            public static string WrittenTestImagePath = @"C:\Users\user\Desktop\DVLD\Utilities\Icons\Icons\Written Test 32.png";
            public static string PracticalTestImagePath = @"C:\Users\user\Desktop\DVLD\Utilities\Icons\Icons\Street Test 32.png";
        }
    }
}