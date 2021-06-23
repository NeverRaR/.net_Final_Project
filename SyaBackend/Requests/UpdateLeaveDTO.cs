using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyaBackend.Requests
{
    public class UpdateLeaveDTO
    {

        public int LeaveId { get; set; }
        public int WorkId { get; set; }


        public String Content { get; set; }


        public String Proof { get; set; }


        public int Status { get; set; }


        public String LeaveDay { get; set; }


        public String LeaveStart { get; set; }


        public String LeaveEnd { get; set; }
    }
}
