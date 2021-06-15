using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SyaBackend.Models
{
    [Table("announcement_send")]
    public class AnnouncementSend
    {
        public int AnnouncementId { get; set; }


        public int ReceiverId { get; set; }
    }
}
