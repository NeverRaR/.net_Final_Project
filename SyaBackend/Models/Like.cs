using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SyaBackend.Models
{
    [Table("work_like")]
    public class Like
    {
        public int WorkId { get; set; }
        public int StudentId { get; set; }

    }
}
