using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SyaBackend.Services;
using SyaBackend.Utils;
using SyaBackend.Models;
using SyaBackend.Views;
using SyaBackend.Requests;
using StackExchange.Redis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Threading;

namespace SyaBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {

        private readonly SyaDbContext _dataBase;
        private readonly IDatabase _redis;
        private readonly String _mailName;
        private readonly String _mailPassword;
        private readonly String _mailHost;

        public MessageController(SyaDbContext context, RedisClient client, IConfiguration configuration)
        {
            _dataBase = context;
            _redis = client.GetDatabase();
            var section = configuration.GetSection("Mail");
            _mailName = section.GetSection("Username").Value;
            _mailPassword = section.GetSection("Password").Value;
            _mailHost = section.GetSection("Host").Value;         
        }

        [HttpPost("CreateMessage")]
        public Object CreateMessage([FromBody] CreateMessageDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null)
            {
                return new ErrorInfo("sessionId is invalid!");
            }
            if (user.Role.Equals(1))
            {
                return new ErrorInfo("Student cannot create message!");
            }
            User receiver = _dataBase.Users.Find(body.ReceiverId);
            MessageLibrary message = new MessageLibrary();
            message.MessageType = body.MessageType;
            message.ContentType = 0;
            message.Content = body.Content;
            message.Receiver = receiver;
            message.Sender = user;
            message.Status = 0;
            message.Time = DateTime.Now;
            _dataBase.MessageLibraries.Add(message);
            _dataBase.SaveChanges();

            MailInfo info = new MailInfo();
            info.SmtpServer = _mailHost;
            info.MailFrom = _mailName;
            info.UserPassword = _mailPassword;
            info.MailTo = receiver.Email;
            info.MailSubject = "SYA System:you have a new message!";
            info.MailContent = "Dear " + receiver.Username + ",you receive a new message from teacher " + user.Username + ",please check it in SYA system!";

            //AsynMailHelper.Execute(info);
           ThreadPool.QueueUserWorkItem(AsynMailHelper.Execute,info);

            return new MessageInfo(message);
        }

        [HttpPost("DeleteMessage")]
        public Object DeleteMessage([FromBody] MessageIdDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null)
            {
                return new ErrorInfo("sessionId is invalid!");
            }
            MessageLibrary messageLibrary = _dataBase.MessageLibraries.Find(body.MessageId);

            if(messageLibrary==null|| messageLibrary.Status == 2)
            {
                return new ErrorInfo("Delete Failed!");
            }

            messageLibrary.Status = 2;
            _dataBase.MessageLibraries.Update(messageLibrary);
            _dataBase.SaveChanges();
            return 2;

        }

        [HttpPost("ViewedMessage")]
        public Object ViewedMessage([FromBody] MessageIdDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null)
            {
                return new ErrorInfo("sessionId is invalid!");
            }
          
            MessageLibrary messageLibrary = _dataBase.MessageLibraries.Find(body.MessageId);

            if (messageLibrary == null )
            {
                return new ErrorInfo("Viewed Failed!");
            }

            messageLibrary.Status = 1;
            _dataBase.MessageLibraries.Update(messageLibrary);
            _dataBase.SaveChanges();
            return 1;

        }

        [HttpPost("FindSendMessage")]
        public Object FindSendMessage([FromBody] PageDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null)
            {
                return new ErrorInfo("sessionId is invalid!");
            }

            var messageList = _dataBase.MessageLibraries.Where(m => m.Sender.UserId == user.UserId && m.ContentType == 0);

            return GetMessageInfoListByPage(messageList, body.Pagesize, body.Pagenum);

        }

        [HttpPost("FindReceiveMessage")]
        public Object FindReceiveMessage([FromBody] PageDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null)
            {
                return new ErrorInfo("sessionId is invalid!");
            }

            var messageList = _dataBase.MessageLibraries.Where(m => m.Receiver.UserId == user.UserId && m.ContentType == 0&& m.Status!=2);

            return GetMessageInfoListByPage(messageList, body.Pagesize, body.Pagenum);

        }

        [HttpPost("FindReceiveResign")]
        public Object FindReceiveResign([FromBody] PageDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null)
            {
                return new ErrorInfo("sessionId is invalid!");
            }

            var messageList = _dataBase.MessageLibraries.Where(m => m.Receiver.UserId == user.UserId && m.ContentType == 1 && m.Status != 2);

            return GetMessageInfoListByPage(messageList, body.Pagesize, body.Pagenum);

        }


        private MessageInfoListByPage GetMessageInfoListByPage(IEnumerable<MessageLibrary> MessageList, int pageSize, int pageNum)
        {
            MessageInfoListByPage messageInfoListByPage = new MessageInfoListByPage();
            int totalPage = 1 + (MessageList.Count() - 1) / pageSize;
            messageInfoListByPage.Totalpage = totalPage;
            messageInfoListByPage.Pagenum = pageNum;
            var messageListByPage = MessageList.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            LinkedList<MessageInfo> messageInfoList = new LinkedList<MessageInfo>();
            foreach (var message in messageListByPage)
            {
                _dataBase.Entry(message).Reference(m => m.Sender).Load();
                _dataBase.Entry(message).Reference(m => m.Receiver).Load();
                messageInfoList.AddLast(new MessageInfo(message));
            }
            messageInfoListByPage.MessageItem = messageInfoList;

            return messageInfoListByPage;
        }


    }
}
