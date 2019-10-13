using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Shared
{
    public static class DateTimeFormatter
    {
        public static string StandardDateFormatting = "yyyy-MM-dd";
        public static string StandardTimeStampFormatting = "yyyy-MM-dd HH:mm:ss";
        public static DateTime? GetDateTime(string YYYYMMDD)
        {
            if (!string.IsNullOrEmpty(YYYYMMDD))
            {
                int year = int.Parse(YYYYMMDD.Substring(0, 4));            
                int month = int.Parse(YYYYMMDD.Substring(5, 2));
                int day = int.Parse(YYYYMMDD.Substring(8, 2));
                return new DateTime(year, month, day);
            }
            else
            {
                return null;
            }               
        }
    }
}