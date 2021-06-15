using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SyaBackend.Models
{
    [Table("announcement")]
    public class Announcement
    {
        public int AnnouncementId { get; set; }

        public User User { get; set; }

        public String Title { get; set; } = "";

        public String Content { get; set; } = "";

        [DataType(DataType.Date)]
        public DateTime sendTime { get; set; }

        [ForeignKey("AnnouncementId")]
        public List<AnnouncementSend> AnnouncementSends { get; set; }
    }
}
