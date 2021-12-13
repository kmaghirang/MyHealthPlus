using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace MyHealthPlus.Utilities.Helper
{
    public class TimeZoneConverterHelper
    {
        public static DateTime TimeZone()
        {
            try
            {
                TimeZoneInfo timeZoneInfo;
                DateTime dateTime;
                //Set the time zone information to US Mountain Standard Time 
                timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById($"{WebConfigurationManager.AppSettings["TimeZone"]}");
                //Get date and time in US Mountain Standard Time 
                dateTime = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
                return dateTime;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
