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
    }
}
