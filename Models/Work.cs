using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SyaBackend.Models
{
    [Table("work")]
    public class Work
    {
        [Key]
        public int WorkId { get; set; }

        public String Name { get; set; }

        public String Cover { get; set; }

        public String Description { get; set; }

        public String Address { get; set; }

        public int Salary { get; set; }

        public String StartDay { get; set; }

        public String EndDay { get; set; }

        public String StartTime { get; set; }

        public String EndTime { get; set; }

        public int WeekDay { get; set; }

        public  User Teacher { get; set; }

        [ForeignKey("WorkId")]
        public List<Like> Likes { get; set; }

        [ForeignKey("WorkId")]
        public List<Take> Takes { get; set; }

        [ForeignKey("WorkId")]
        public List<FavoriteHasWork> FavoriteHasWorks { get; set; }

        public List<Apply> Applies { get; set; }

        public List<LeaveInformation> LeaveInformation { get; set; }

        public double GetTotalTime()
        {
            double totalHour = 0.0;
            int totalDay = 0;
            int totalWeek = 0;
            try
            {
                String[] startTimes = StartTime.Split(":");
                String[] endTimes = EndTime.Split(":");
                if (startTimes.Length != endTimes.Length)
                {
                    return 0;
                }
                if (startTimes.Length == 0 || startTimes.Length > 3)
                {
                    return 0;
                }
                int i;
                double rate = 1.0;
                for (i = 0; i < startTimes.Length; ++i)
                {
                    totalHour += (Double.Parse(endTimes[i]) - Double.Parse(startTimes[i])) * rate;
                    rate /= 60;
                }

                String[] startDays = StartDay.Split("-");
                String[] endDays = EndDay.Split("-");
                totalDay += (int.Parse(endDays[0]) - int.Parse(startDays[0])) * 365;
                totalDay += (int.Parse(endDays[1]) - int.Parse(startDays[1])) * 30;
                totalDay += int.Parse(endDays[2]) - int.Parse(startDays[2]);
                totalWeek = 1 + totalDay / 7;
            }
            catch (Exception e)
            {
                Console.Write(e.Message + "\n" + e.StackTrace);
                return 0;
            }
            return totalWeek * totalHour;
        }
    }
}
