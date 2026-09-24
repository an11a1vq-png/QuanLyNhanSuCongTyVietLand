using System;
using System.Text.RegularExpressions;

namespace VietLandHR.Utils
{
    /// <summary>
    /// Utility để validate dữ liệu
    /// </summary>
    public static class ValidationHelper
    {
        /// <summary>
        /// Validate email format
        /// </summary>
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Validate phone number (Việt Nam)
        /// </summary>
        public static bool IsValidPhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            // Định dạng: +84xxx, 0xxx, hoặc 84xxx
            string pattern = @"^(0|84|\+84)(\d{9,10})$";
            return Regex.IsMatch(phone.Replace(" ", "").Replace("-", ""), pattern);
        }



        /// <summary>
        /// Validate không để trống
        /// </summary>
        public static bool IsNotEmpty(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Validate độ dài chuỗi
        /// </summary>
        public static bool IsValidLength(string value, int minLength, int maxLength)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            return value.Length >= minLength && value.Length <= maxLength;
        }

        /// <summary>
        /// Validate ngày sinh hợp lệ
        /// </summary>
        public static bool IsValidDateOfBirth(DateTime dateOfBirth)
        {
            DateTime today = DateTime.Now;
            int age = today.Year - dateOfBirth.Year;

            if (dateOfBirth.Date > today.AddYears(-age))
                age--;

            // Tuổi phải từ 18 đến 70
            return age >= 18 && age <= 70 && dateOfBirth < today;
        }

        /// <summary>
        /// Validate username format
        /// Chỉ chứa chữ, số, _ và có độ dài 6-20 ký tự
        /// </summary>
        public static bool IsValidUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return false;

            string pattern = @"^[a-zA-Z0-9_]{6,20}$";
            return Regex.IsMatch(username, pattern);
        }

        /// <summary>
        /// Validate số ngày hợp lệ
        /// </summary>
        public static bool IsValidNumberOfDays(int numberOfDays)
        {
            return numberOfDays > 0 && numberOfDays <= 365;
        }

        /// <summary>
        /// Validate khoảng ngày
        /// FromDate phải trước ToDate
        /// </summary>
        public static bool IsValidDateRange(DateTime fromDate, DateTime toDate)
        {
            return fromDate < toDate && fromDate >= DateTime.Now.Date;
        }
    }
}

