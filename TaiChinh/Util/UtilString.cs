using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace TaiChinh.Util
{
    public static class UtilString
    {
        public static string GetMoney(decimal? value)
        {
            return string.Format("{0:C}", value);
        }
        public static string GetDay(DateTime? value)
        {
            return value.Value.ToString("dddd dd/MM/yyyy");
        }
    }
}
