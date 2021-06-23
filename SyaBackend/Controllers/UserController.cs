using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SyaBackend.Models;
using SyaBackend.Utils;
using StackExchange.Redis;
using SyaBackend.Views;
using SyaBackend.Requests;
using SyaBackend.Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SyaBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly SyaDbContext _dataBase;
        private readonly IDatabase _redis;

        public UserController(SyaDbContext context, RedisClient client)
        {
            _dataBase = context;
            _redis = client.GetDatabase();
        }


        [HttpPost("GetUserInfo")]
        public Object GetUserInfo()
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null)  return new ErrorInfo("sessionId is invalid!");
            UserStatus userStatus = new UserStatus();
            userStatus.setUser(user);
            userStatus.NofApply= _dataBase.Applies.Where(a => a.Student.UserId == user.UserId).Count();
            userStatus.NofAbsent = _dataBase.LeaveInformation.Where(l => l.Student.UserId == user.UserId).Count();
            userStatus.AbsentTime = _dataBase.Takes.Where(t => t.StudentId == user.UserId).Sum(t => t.AbsentTime);
            userStatus.WorkTime = _dataBase.Takes.Where(t => t.StudentId == user.UserId).Sum(t => t.WorkTime);

            return userStatus;
        }

        [HttpPost("UpdateUser")]
        public Object UpdateUser([FromBody] UpdateUserDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);

            if (user == null) return new ErrorInfo("sessionId is invalid!");
            user.Bank = body.Bank;
            user.Avatar = body.Avatar;
            user.Gender = body.Gender ? 1 : 0;
            user.Tel = body.Tel;
            _dataBase.Users.Update(user);
            _dataBase.SaveChanges();

            UserStatus userStatus = new UserStatus();
            userStatus.setUser(user);
            userStatus.NofApply = _dataBase.Applies.Where(a => a.Student.UserId == user.UserId).Count();
            userStatus.NofAbsent = _dataBase.LeaveInformation.Where(l => l.Student.UserId == user.UserId).Count();
            userStatus.AbsentTime = _dataBase.Takes.Where(t => t.StudentId == user.UserId).Sum(t => t.AbsentTime);
            userStatus.WorkTime = _dataBase.Takes.Where(t => t.StudentId == user.UserId).Sum(t => t.WorkTime);

            return userStatus;
        }
    }
}
