using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SyaBackend.Models
{
    public class Resume
    {
        [Key]
        public int ResumeId { get; set; }

        public int Age { get; set; }

        public String Name { get; set; }

        public String City { get; set; }

        public String Education { get; set; }

        public String Community { get; set; }

        public String Project { get; set; }

        public String Academic { get; set; }

        public String Skill { get; set; }

        public String Introduction { get; set; }
        public int StudentId { get; set; }
        public User Student { get; set; }

        public List<Apply> Applies { get; set; }
    }
}
