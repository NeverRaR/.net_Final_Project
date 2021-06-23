using System;

namespace SyaBackend.Utils
{
    public class DateHelper
    {
        public  static String FormatTime(String time)
        {
            String[]
            times = time.Split(":");
            if (times.Length == 0 || times.Length > 3)
            {
                throw new Exception(time + ":Time length is wrong!");
            }
            int i;
            String formattedTime = times[0];
            for (i = 1; i < times.Length; ++i)
            {
                formattedTime += ":" + times[i];
            }
            for (; i < 3; ++i)
            {
                formattedTime += ":00";
            }
            return formattedTime;
        }
    }
}
