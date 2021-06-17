using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyaBackend.Views
{
    public class WorkStatus
    {
        public int Id { get; set; }

        public String WorkName { get; set; }

        public String Cover { get; set; }

        public String WorkDescription { get; set; }

        public String Address { get; set; }

        public int Salary { get; set; }

        public String StartDay { get; set; }

        public String EndDay { get; set; }

        public int LikesNum { get; set; }

        public int CollectNum { get; set; }

        public String StartTime { get; set; }

        public String EndTime { get; set; }

        public double TotalTime { get; set; }

        public int WeekDay { get; set; }

        public int Status { get; set; }


    }
}
