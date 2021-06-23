using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SyaBackend.Models;
using SyaBackend.Utils;
using SyaBackend.Requests;
using SyaBackend.Views;
using SyaBackend.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SyaBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnnounceController : ControllerBase
    {
        private readonly SyaDbContext _dataBase;
        private readonly IDatabase _redis;

        public AnnounceController(SyaDbContext context, RedisClient client)
        {
            _dataBase = context;
            _redis = client.GetDatabase();
        }

        // POST api/<AnnounceController>
        [HttpPost("CreateAnnounce")]
        public int CreateAnnounce([FromBody] CreateAnnouncementDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null || user.Role!=0)
            {
                return -1;
            }
            Announcement announcement = new Announcement();
            announcement.User = user;
            announcement.Title = body.Title;
            announcement.Content = body.Content;
            announcement.sendTime = DateTime.Now;
            _dataBase.Announcements.Add(announcement);
            _dataBase.SaveChanges();

            var users = _dataBase.Users.ToList();
            foreach(var someone in users)
            {
                AnnouncementSend announcementSend = new AnnouncementSend();
                announcementSend.AnnouncementId = announcement.AnnouncementId;
                announcementSend.ReceiverId = someone.UserId;
                announcementSend.Status = 0;
                _dataBase.AnnouncementSends.Add(announcementSend);
            }
            _dataBase.SaveChanges();
            return announcement.AnnouncementId;
        }

        
        [HttpPost("GetAnnounce")]
        public AnnouncementInfoListByPage GetAnnounce([FromBody] PageDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null )
            {
                return null;
            }
            var announcementSends = _dataBase.AnnouncementSends.Where(a => a.ReceiverId == user.UserId);
            return GetAnnouncementInfoListByPage(announcementSends, body.Pagesize, body.Pagenum);
        }

        [HttpPost("GetAnnounceContent")]
        public AnnouncementInfo GetAnnounceContent([FromBody] AnnouncementIdDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null)
            {
                return null;
            }
            AnnouncementSend announcementSend = _dataBase.AnnouncementSends.Find(body.AnnouncementId,user.UserId);
            if (announcementSend == null)
            {
                return null;
            }
            Announcement announcement = _dataBase.Announcements.Find(announcementSend.AnnouncementId);
            AnnouncementInfo announcementInfo = new AnnouncementInfo(announcementSend, announcement);
            announcementSend.Status = 1;
            _dataBase.AnnouncementSends.Update(announcementSend);
            _dataBase.SaveChanges();

            return announcementInfo;
        }

        [HttpPost("DeleteAnnounce")]
        public int DeleteAnnounce([FromBody] AnnouncementIdDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null)
            {
                return 0;
            }
            AnnouncementSend announcementSend = _dataBase.AnnouncementSends.Find(body.AnnouncementId,user.UserId);
            if (announcementSend == null)
            {
                return 0;
            }
          
            _dataBase.AnnouncementSends.Remove(announcementSend);
            _dataBase.SaveChanges();

            return 2;
        }

        [HttpPost("DeleteAnnounceAll")]
        public int DeleteAnnounceAll([FromBody] AnnouncementIdDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null || user.Role != 0)
            {
                return 0;
            }
            Announcement announcement = _dataBase.Announcements.Find(body.AnnouncementId);
            if (announcement == null)
            {
                return 0;
            }

            _dataBase.Announcements.Remove(announcement);
            _dataBase.SaveChanges();

            return 2;
        }

        [HttpPost("GetSendAnnounce")]
        public AnnouncementInfoListByPage GetSendAnnounce([FromBody] PageDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null || user.Role != 0)
            {
                return null;
            }
            var announcements = _dataBase.Announcements.Where(a => a.User.UserId == user.UserId);
            return GetAnnouncementInfoListByPage(announcements, body.Pagesize, body.Pagenum);
        }


        private AnnouncementInfoListByPage GetAnnouncementInfoListByPage(IEnumerable<AnnouncementSend> announcementSendList, int pageSize, int pageNum)
        {
            AnnouncementInfoListByPage announcementInfoListByPage = new AnnouncementInfoListByPage();
            int totalPage = 1 + (announcementSendList.Count() - 1) / pageSize;
            announcementInfoListByPage.Totalpage = totalPage;
            announcementInfoListByPage.Pagenum = pageNum;
            var announcementSendListByPage = announcementSendList.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            LinkedList<AnnouncementInfo> announcementInfoList = new LinkedList<AnnouncementInfo>();
            foreach (var announcementSend in announcementSendListByPage)
            {
                Announcement announcement = _dataBase.Announcements.Find(announcementSend.AnnouncementId);
                announcementInfoList.AddLast(new AnnouncementInfo(announcementSend, announcement));
            }
            announcementInfoListByPage.AnnouncementItem = announcementInfoList;
            return announcementInfoListByPage;

        }

        private AnnouncementInfoListByPage GetAnnouncementInfoListByPage(IEnumerable<Announcement> announcementList, int pageSize, int pageNum)
        {
            AnnouncementInfoListByPage announcementInfoListByPage = new AnnouncementInfoListByPage();
            int totalPage = 1 + (announcementList.Count() - 1) / pageSize;
            announcementInfoListByPage.Totalpage = totalPage;
            announcementInfoListByPage.Pagenum = pageNum;
            var announcementListByPage = announcementList.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            LinkedList<AnnouncementInfo> announcementInfoList = new LinkedList<AnnouncementInfo>();
            foreach (var announcement in announcementListByPage)
            {                
                announcementInfoList.AddLast(new AnnouncementInfo(announcement));
            }
            announcementInfoListByPage.AnnouncementItem = announcementInfoList;
            return announcementInfoListByPage;

        }

    }
}
