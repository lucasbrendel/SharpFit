using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SharpFit
{
    /// <summary>
    /// 
    /// </summary>
    public class APIAccess
    {
        /// <summary>
        /// 
        /// </summary>
        public enum Units
        {
            Metric,
            Imperial
        }

        /// <summary>
        /// 
        /// </summary>
        public enum RequestResult
        {
            Success,
            Failure
        }

        public static bool IsValidDate(string date)
        {
            if (String.IsNullOrEmpty(date))
            {
                return false;
            }

            // Return true if date is a valid date
            return Regex.IsMatch(date,
                      @"^(\d{4}-\d{2}\-\d{2})",
                      RegexOptions.Singleline);
        }
    }
}
