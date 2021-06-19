using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SyaBackend.Models
{
    [Table("leave_information")]
    public class LeaveInformation
    {

        public int LeaveInformationId { get; set; }

        public Work Work { get; set; }

        public User Student { get; set; }

        public String Content { get; set; } = "";

        public String Proof { get; set; } = "";

        public int Status { get; set; }

        [DataType(DataType.Date)]
        public DateTime RequestTime { get; set; }


        public String LeaveDay { get; set; }


        public String LeaveStart { get; set; }


        public String LeaveEnd { get; set; }


        public Double GetTotalTime()
        {
            double totalTime = 0.0;
            try
            {
                String[] startTimes = LeaveStart.Split(":");
                String[] endTimes = LeaveEnd.Split(":");
                if (startTimes.Length != endTimes.Length) return 0;
                if (startTimes.Length == 0 || startTimes.Length > 3) return 0;
                int i;
                double rate = 1.0;
                for (i = 0; i < startTimes.Length; ++i)
                {
                    totalTime += (Double.Parse(endTimes[i]) - Double.Parse(startTimes[i])) * rate;
                    rate /= 60;
                }
            }
            catch (Exception e)
            {               
                return 0;
            }
            return totalTime;
        }
    }
}
