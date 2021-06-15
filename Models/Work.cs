using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SyaBackend.Models
{
    [Table("work")]
    public class Work
    {
        [Key]
        public int WorkId { get; set; }

        public String Name { get; set; }

        public String Cover { get; set; }

        public String Description { get; set; }

        public String Address { get; set; }

        public int Salary { get; set; }

        public String StartDay { get; set; }

        public String EndDay { get; set; }

        public String StartTime { get; set; }

        public String EndTime { get; set; }

        public int WeekDay { get; set; }

        public  User Teacher { get; set; }

        [ForeignKey("WorkId")]
        public List<Like> Likes { get; set; }

        [ForeignKey("WorkId")]
        public List<Take> Takes { get; set; }

        [ForeignKey("WorkId")]
        public List<FavoriteHasWork> FavoriteHasWorks { get; set; }

        public List<Apply> Applies { get; set; }

        public List<LeaveInformation> LeaveInformation { get; set; }
    }
}
