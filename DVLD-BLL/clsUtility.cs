// Class: Business Logic Utilities
// Provides common helper methods for BLL:
//   - Full name construction from name parts (handles optional middle names)
//   - Date parsing from string

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BLL
{
    public static class clsUtility
    {
        // Constructs full name from parts, handling optional middle names
        public static string GetFullName(string FirstName, string SecondName, string ThirdName, string LastName)
        {
            string FullName = FirstName + " ";

            if (!string.IsNullOrEmpty(SecondName))
            {
                FullName += SecondName + " ";

                if (!string.IsNullOrEmpty(ThirdName))
                {
                    FullName += ThirdName + " ";
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(ThirdName))
                {
                    FullName += ThirdName + " ";
                }
            }

            FullName += LastName;
            return FullName;
        }

        // Determines age by two dates
        public static int GetAge(DateTime BirthDate)
        {
            int Age = DateTime.Now.Year - BirthDate.Year;

            if (BirthDate.AddYears(Age) > DateTime.Now)
                Age--;

            return Age;
        }

        // Parses string to DateTime, returns default if invalid
        public static DateTime GetDate(string StrDate)
        {
            bool IsValid = DateTime.TryParse(StrDate, out DateTime ResultDate);

            return IsValid ? ResultDate : default(DateTime);
        }

        // Capitalizes the first letter in a word
        public static string Capitalize(string Str)
        {
            if (string.IsNullOrEmpty(Str)) return Str;

            string NewStr = char.ToUpper(Str[0]) + Str.Remove(0, 1);
            return NewStr;
        }
    }
}