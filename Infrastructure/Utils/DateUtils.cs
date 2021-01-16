using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Infrastructure.Utils
{
    public class DateUtils
    {
        private static string GetDayNumberSuffix(DateTime date)
        {
            switch (date.Day)
            {
                case 1:
                case 0x15:
                case 0x1f:
                    return @"\s\t";

                case 2:
                case 0x16:
                    return @"\n\d";

                case 3:
                case 0x17:
                    return @"\r\d";
            }
            return @"\t\h";
        }
        public static string FormatDateTime(string date, string format)
        {
            DateTime time;
            if (DateTime.TryParse(date, out time) && !string.IsNullOrEmpty(format))
            {
                format = Regex.Replace(format, @"(?<!\\)((\\\\)*)(S)", "$1" + GetDayNumberSuffix(time));
                return time.ToString(format);
            }
            return string.Empty;
        }

        public static string GetPrettyDate(string date)
        {
            DateTime time;
            if (DateTime.TryParse(date, out time))
            {
                var span = DateTime.Now.Subtract(time);
                var totalDays = (int)span.TotalDays;
                var totalSeconds = (int)span.TotalSeconds;
                // return FormatDateTime(date, "dd-MM-yyyy HH:mm");
                if ((totalDays < 0) || (totalDays >= 0x1f))
                {
                    return FormatDateTime(date, "HH:mm dd-MM-yyyy");
                }
                if (totalDays == 0)
                {
                    if (totalSeconds < 60)
                    {
                        return "vừa xong";//GetLocalisedText("Date.JustNow");
                    }
                    if (totalSeconds < 120)
                    {
                        return "1 phút trước";//GetLocalisedText("Date.OneMinuteAgo");
                    }
                    if (totalSeconds < 0xe10)
                    {
                        //  return string.Format(GetLocalisedText("Date.MinutesAgo"), Math.Floor((double)(((double)totalSeconds) / 60.0)));
                        return string.Format("{0} phút trước", Math.Floor((double)(((double)totalSeconds) / 60.0)));
                    }
                    if (totalSeconds < 0x1c20)
                    {
                        //  return GetLocalisedText("Date.OneHourAgo");
                        return "1 giờ trước";
                    }
                    if (totalSeconds < 0x15180)
                    {
                        // return string.Format(GetLocalisedText("Date.HoursAgo"), Math.Floor((double)(((double)totalSeconds) / 3600.0)));
                        return string.Format("{0} giờ trước", Math.Floor((double)(((double)totalSeconds) / 3600.0)));
                    }
                }
                if (totalDays == 1)
                {
                    // return GetLocalisedText("Date.Yesterday");
                    return "ngày hôm qua";
                }
                if (totalDays < 7)
                {
                    // return string.Format(GetLocalisedText("Date.DaysAgo"), totalDays);
                    return string.Format("{0} ngày trước", totalDays);
                }
                if (totalDays < 0x1f)
                {
                    //  return string.Format(GetLocalisedText("Date.WeeksAgo"), Math.Ceiling((double)(((double)totalDays) / 7.0)));
                    return string.Format("{0} tuần trước", Math.Ceiling((double)(((double)totalDays) / 7.0)));
                }
            }
            return date;
        }
    }
}
