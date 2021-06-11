using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyaBackend.Models
{
    public class Apply
    {
        public int ApplyId { get; set; }
        public Work Work { get; set; }
        public User Student { get; set; }
        public Resume Resume { get; set; }
        public User Teacher { get; set; }

        public int Status;
    }
}
