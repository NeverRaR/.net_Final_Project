using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyaBackend.Requests
{
    public class CreateMessageDTO
    {

        public int MessageType { get; set; }


        public String Content { get; set; }


        public int ReceiverId { get; set; }
    }
}
