using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.AppCode.Helper
{
    public static class DateTimeHelper
    {
        public static int MonthDifference(this DateTime rValue)
        {
            var lValue = DateTime.Now;
            return (lValue.Month - rValue.Month) + 12 * (lValue.Year - rValue.Year);
        }
    }
}
