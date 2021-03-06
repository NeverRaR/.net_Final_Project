using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SyaBackend.Models
{
    [Table("apply")]
    public class Apply
    {
        public int ApplyId { get; set; }
        public Work Work { get; set; }
        public User Student { get; set; }
        public Resume Resume { get; set; }
        public User Teacher { get; set; }

        public int Status { get; set; }
    }
}
