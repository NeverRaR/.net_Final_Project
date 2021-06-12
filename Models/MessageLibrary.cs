using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SyaBackend.Models
{
    public class MessageLibrary
    {
        [Key]
        public int MessageLibraryId { get; set; }

        public int MessageType { get; set; }

        public String Content { get; set; }

        [DataType(DataType.Date)]
        public DateTime Time { get; set; }

        public int Status { get; set; }

        public int ContentType { get; set; }

        public User Sender { get; set; }

        public User Receiver { get; set; }
    }
}
