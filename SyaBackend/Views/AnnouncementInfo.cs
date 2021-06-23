using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SyaBackend.Models;

namespace SyaBackend.Views
{
    public class AnnouncementInfo
    {


        public int AnnouncementId { get; set; }

        public int UserId { get; set; }

        public String Title { get; set; }

        public int Status { get; set; }

        public String SendTime { get; set; }

        public String Content { get; set; }

        public AnnouncementInfo(Announcement announcement)
        {
            AnnouncementId = announcement.AnnouncementId;
            Title = announcement.Title;
            SendTime = announcement.sendTime.ToString();
            Content = announcement.Content;
        }
        public AnnouncementInfo(AnnouncementSend announcementSend, Announcement announcement)
        {
            Status = announcementSend.Status;
            UserId = announcementSend.ReceiverId;
            AnnouncementId = announcement.AnnouncementId;
            Title = announcement.Title;
            SendTime = announcement.sendTime.ToString();
            Content = announcement.Content;
        }    
    }
}
