using System.Globalization;
using System.Text.RegularExpressions;

namespace ITS.Infrastructure.Extensions
{
    public static class ValidationExtensions
    {
        private const string PersianDateValidationPattern = @"^$|^([1۱][۰-۹ 0-9]{3}[/\/]([0 ۰][۱-۶ 1-6])[/\/]([0 ۰][۱-۹ 1-9]|[۱۲12][۰-۹ 0-9]|[3۳][01۰۱])|[1۱][۰-۹ 0-9]{3}[/\/]([۰0][۷-۹ 7-9]|[1۱][۰۱۲012])[/\/]([۰0][1-9 ۱-۹]|[12۱۲][0-9 ۰-۹]|(30|۳۰)))$";

        public static bool IsNationalCode(this string nationalCode)
        {
            if (Regex.Match(nationalCode, @"^[0-9]{10}$").Success)
                return true;
            return false;
        }

        public static bool IsPhoneNumber(this string phoneNumber)
        {
            if (CheckOnlyDigitAndElevenLength(phoneNumber) && phoneNumber.Substring(0, 2) == "09")
                return true;

            return false;
        }

        public static bool IsPersianDate(this string date)
        {
            if (LeapYearValidation(date) && Regex.Match(date, PersianDateValidationPattern).Success)
                return true;

            return false;
        }
        public static bool IsNullablePersianDate(this string date)
        {
            if (string.IsNullOrEmpty(date))
                return true;

            if (LeapYearValidation(date) && Regex.Match(date, PersianDateValidationPattern).Success)
                return true;

            return false;
        }

        private static bool LeapYearValidation(string date)
        {
            var persianDateSplit = date.Split('/');
            var year = int.Parse(persianDateSplit[0]);
            var month = int.Parse(persianDateSplit[1]);
            var day = int.Parse(persianDateSplit[2]);

            PersianCalendar pc = new PersianCalendar();
            if (!pc.IsLeapYear(year) && month == 12 && day > 29)
                return false;

            return true;
        }

        private static bool CheckOnlyDigitAndElevenLength(string phoneNumber)
        {
            if (!string.IsNullOrWhiteSpace(phoneNumber) && Regex.Match(phoneNumber, @"^[0-9]{11}$").Success)
                return true;

            return false;
        }
    }
}