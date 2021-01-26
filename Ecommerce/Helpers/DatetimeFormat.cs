using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Helpers
{
    public static class DatetimeFormat
    {
        public static string FormatDatetime(this DateTimeOffset GetgivenDate)
        {
            return GetgivenDate.ToString("MM/dd/yyyy");
        }

        public static string StringFormatDatetime(this string Date)
        {
            var Datetimeobj = Convert.ToDateTime(Date);
            return Datetimeobj.ToString("MM/dd/yyyy");
        }
    }
}
