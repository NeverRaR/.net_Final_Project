using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SYASharedDateHelper;

namespace SyaBackend.Requests
{
    public class UpdateWorkDTO
    {


        private String startTime;

        private String endTime;



        public int WorkId { get; set; }
        public String WorkName { set; get; }
        public String Cover { set; get; }
        public String WorkDescription { set; get; }
        public String Address { set; get; }
        public int? Salary { set; get; }
        public String StartDay { set; get; }
        public String EndDay { set; get; }
        public String StartTime
        {
            set
            {
                startTime = DateHelper.FormatTime(value);
            }
            get
            {
                return startTime;
            }
        }
        public String EndTime
        {
            set
            {
                endTime = DateHelper.FormatTime(value);
            }
            get
            {
                return endTime;
            }
        }
        public int? WeekDay { set; get; }
    }
}
