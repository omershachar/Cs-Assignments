using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.Utilities
{
    public static class Validator
    {
        public static bool IsStringValid(string str)
            => !string.IsNullOrWhiteSpace(str) && str.All(char.IsLetter);

        public static bool IsNumberValid(string num)
            => !string.IsNullOrWhiteSpace(num) && num.All(char.IsDigit);

        public static bool IsDateValid(DateTime date)
            => date.Year > 1900 && date.Year < DateTime.Now.Year;

        public static bool IsColorCodeValid(string code)
        {
            return !(string.IsNullOrWhiteSpace(code) || code.Length != 7 || code[0] != '#');
        }

        public static bool IsEmailValid(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            var parts = email.Split('@');
            return parts.Length == 2 && parts[0].Length > 0 && parts[1].Contains('.');
        }
    }
}
