using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SyaBackend.Models
{
    [Table("takes")]
    public class Take
    {

        public int WorkId { get; set; }

        public int StudentId { get; set; }

        public double WorkTime { get; set; }

        public int AbsentNum { get; set; }

        public double AbsentTime { get; set; }

        public int Status { get; set; }
    }
}
