using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SyaBackend.Models;

namespace SyaBackend.Views
{
    public class MessageInfo
    {

        public int MessageId { get; set; }


        public int MessageType { get; set; }


        public String Content { get; set; }


        public DateTime MessageTime { get; set; }


        public int SenderId { get; set; }

        public int RecevierId { get; set; }
        public int Status { get; set; }

        public String SenderName { get; set; }


        public String ReceiverName { get; set; }

        public MessageInfo(MessageLibrary messageLibrary)
        {
            MessageId = messageLibrary.MessageLibraryId;
            MessageType = messageLibrary.MessageType;
            Content = messageLibrary.Content;
            MessageTime = messageLibrary.Time;
            SenderId = messageLibrary.Sender.UserId;
            SenderName = messageLibrary.Sender.Username;
            RecevierId = messageLibrary.Receiver.UserId;
            ReceiverName = messageLibrary.Receiver.Username;
            Status = messageLibrary.Status;
        }
    }
}
