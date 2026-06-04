// Class: Input Validation
// Provides validation methods for all input types:
//   - Basic character type checking (letters, digits, alphanumeric)
//   - Person fields (names, national number, phone, address, email)
//   - User fields (username, password, password confirmation)
//   - DateToCompare range validation
// Used throughout BLL and presentation layers

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DVLD_BLL
{
    public static class clsValidation
    {
        // Basic character type validators
        public static bool IsOnlyLetters(string Str1)
        {
            if (string.IsNullOrEmpty(Str1)) return false;

            foreach (char C in Str1)
            {
                if (!char.IsLetter(C)) return false;
            }

            return true;
        }

        public static bool IsOnlyDigits(string Str1)
        {
            if (string.IsNullOrEmpty(Str1)) return false;

            foreach (char C in Str1)
            {
                if (!char.IsDigit(C)) return false;
            }

            return true;
        }

        public static bool IsOnlyLettersAndDigits(string Str1)
        {
            if (string.IsNullOrEmpty(Str1)) return false;
            foreach (char C in Str1)
            {
                if (!char.IsLetterOrDigit(C)) return false;
            }

            return true;
        }

        // Name validators (SecondName and ThirdName are optional)
        public static bool IsValidOptionalName(string Name, int MinLength = 2, int MaxLength = 25)
        {
            if (string.IsNullOrEmpty(Name)) return true;
            if (!(Name.Length >= MinLength && Name.Length <= MaxLength)) return false;

            return IsOnlyLetters(Name);
        }

        public static bool IsValidRequiredName(string Name, int MinLength = 2, int MaxLength = 25)
        {
            if (string.IsNullOrEmpty(Name)) return false;
            if (!(Name.Length >= MinLength && Name.Length <= MaxLength)) return false;

            return IsOnlyLetters(Name);
        }

        // National number validator (alphanumeric)
        public static bool IsValidNationalNo(string NationalNo, int MinLength = 2, int MaxLength = 50)
        {
            if (string.IsNullOrEmpty(NationalNo)) return false;
            if (!(NationalNo.Length >= MinLength && NationalNo.Length <= MaxLength)) return false;

            return IsOnlyLettersAndDigits(NationalNo);
        }

        // Phone validator (digits only)
        public static bool IsValidPhone(string Phone, int MinLength = 7, int MaxLength = 15)
        {
            if (string.IsNullOrEmpty(Phone)) return false;
            if (!(Phone.Length >= MinLength && Phone.Length <= MaxLength)) return false;

            return IsOnlyDigits(Phone);
        }

        // Address validators (allows specific symbols)
        static bool IsAddressSymbol(char AddressChar)
        {
            return (AddressChar == ',' || AddressChar == '.' || AddressChar == '-' || AddressChar == '/' ||
                    AddressChar == '#' || AddressChar == '(' || AddressChar == ')');
        }

        static bool IsValidAddressCharacters(string Address)
        {
            foreach (char C in Address)
            {
                if (!(char.IsLetterOrDigit(C) || char.IsWhiteSpace(C) || IsAddressSymbol(C)))
                    return false;
            }

            return true;
        }

        public static bool IsValidAddress(string Address, int MinLength = 5, int MaxLength = 500)
        {
            if (string.IsNullOrEmpty(Address)) return false;
            if (!(Address.Length >= MinLength && Address.Length <= MaxLength)) return false;

            return IsValidAddressCharacters(Address);
        }

        // Email validator (regex pattern)
        public static bool IsValidEmail(string Email)
        {
            if (string.IsNullOrEmpty(Email)) return false;

            var pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(Email, pattern);
        }


        // UserName validator (letters, digits, underscore, dot)
        public static bool IsValidUserName(string UserName, int MinLength = 3, int MaxLength = 20)
        {
            if (!(UserName.Length >= MinLength && UserName.Length <= MaxLength) || string.IsNullOrEmpty(UserName)) return false;

            foreach (char C in UserName)
            {
                if (!(char.IsLetterOrDigit(C) || C == '_' || C == '.')) return false;
            }

            return true;
        }

        // Password validator (requires uppercase, lowercase, digit, and symbol)
        public static bool IsValidPassword(string Password, int MinLength = 8, int MaxLength = 64)
        {
            if (!(Password.Length >= MinLength && Password.Length <= MaxLength) || string.IsNullOrEmpty(Password)) return false;

            int UpperCaseLettersCounter = 0;
            int LowerCaseLettersCounter = 0;
            int DigitsCounter = 0;
            int SymbolsCounter = 0;

            foreach (char C in Password)
            {
                if (char.IsUpper(C))
                    UpperCaseLettersCounter++;

                else if (char.IsLower(C))
                    LowerCaseLettersCounter++;

                else if (char.IsDigit(C))
                    DigitsCounter++;

                else if (char.IsPunctuation(C) || char.IsSymbol(C))
                    SymbolsCounter++;
            }

            return (UpperCaseLettersCounter > 0 && LowerCaseLettersCounter > 0 && DigitsCounter > 0 && SymbolsCounter > 0);
        }

        // Password confirmation validator
        public static bool IsValidPasswordConfirmation(string Password, string PasswordConfirmation)
        {
            return Password == PasswordConfirmation;
        }


        // Date range validator 
        public static bool IsDateBetween(DateTime DateToCompare, DateTime StartDate, DateTime EndDate)
        {
            return DateToCompare >= StartDate && DateToCompare <= EndDate;
        }

        // Number Positivity
        public static bool IsPositiveOrNull(int value)
        {
            return value >= 0;
        }
        public static bool IsPositiveOrNull(double value)
        {
            return value >= 0;
        }
        public static bool IsPositiveOrNull(float value)
        {
            return value >= 0;
        }
        public static bool IsPositiveOrNull(decimal value)
        {
            return value >= 0;
        }
        public static bool IsPositiveOrNull(long value)
        {
            return value >= 0;
        }
    }
}