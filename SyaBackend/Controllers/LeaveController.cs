using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SyaBackend.Utils;
using SyaBackend.Services;
using SyaBackend.Models;
using SyaBackend.Views;
using SyaBackend.Requests;
using StackExchange.Redis;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SyaBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {

        private readonly SyaDbContext _dataBase;
        private readonly IDatabase _redis;

        public LeaveController(SyaDbContext context, RedisClient client)
        {
            _dataBase = context;
            _redis = client.GetDatabase();
        }
        [HttpPost("RequestRest")]
        public LeaveInfo RequestRest([FromBody] LeaveDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null )
            {
                return null;
            }
            LeaveInformation leaveInformation = new LeaveInformation();
            Work work = _dataBase.Works.Find(body.WorkId);
            if (work == null) return null;
            leaveInformation.Work = work;
            leaveInformation.Student = user;
            leaveInformation.Content = body.Content;
            leaveInformation.Proof = body.Proof;
            leaveInformation.Status = 0;
            leaveInformation.RequestTime = DateTime.Now;
            leaveInformation.LeaveDay = body.LeaveDay;
            leaveInformation.LeaveStart = body.LeaveStart;
            leaveInformation.LeaveEnd = body.LeaveEnd;
            _dataBase.LeaveInformation.Add(leaveInformation);
            _dataBase.SaveChanges();
            return new LeaveInfo(leaveInformation);
        }

        [HttpPost("ProViewLeaves")]
        public LeaveInfoListByPage ProViewLeave([FromBody] PageDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null || user.Role == 1)
            {
                return null;
            }
            var leaveList = from work in _dataBase.Works
                            where work.Teacher.UserId == user.UserId
                            join leave in _dataBase.LeaveInformation
                            on work.WorkId equals leave.Work.WorkId
                            select leave;
            return GetLeaveInfoListByPage(leaveList, body.Pagenum, body.Pagesize);
        }

        [HttpPost("ProManageLeave")]
        public LeaveInfo ProManageLeave([FromBody] LeaveManagementDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null || user.Role == 1)
            {
                return null;
            }
            LeaveInformation leaveInformation = _dataBase.LeaveInformation.Find(body.LeaveId);
            if (leaveInformation == null)
            {
                return null;

            }
            leaveInformation.Status = body.Status;
            _dataBase.Entry(leaveInformation).Reference(l => l.Student).Load();
            _dataBase.Entry(leaveInformation).Reference(l => l.Work).Load();
            _dataBase.LeaveInformation.Update(leaveInformation);
            _dataBase.SaveChanges();
            return new LeaveInfo(leaveInformation);
        }

        [HttpPost("ViewLeave")]
        public LeaveInfoListByPage ViewLeave([FromBody] PageDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null)
            {
                return null;
            }
            var leaveList = _dataBase.LeaveInformation.Where(l => l.Student.UserId == user.UserId);
            return GetLeaveInfoListByPage(leaveList, body.Pagenum, body.Pagesize);
        }

        [HttpPost("UpdateLeave")]
        public LeaveInfo UpdateLeave([FromBody] UpdateLeaveDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null)
            {
                return null;
            }
            LeaveInformation leaveInformation = _dataBase.LeaveInformation.Find(body.LeaveId);
            if (leaveInformation == null) return null;
            Work work = _dataBase.Works.Find(body.WorkId);
            if (work == null) return null;
            leaveInformation.Work = work;
            leaveInformation.Student = user;
            leaveInformation.Content = body.Content;
            leaveInformation.Proof = body.Proof;
            leaveInformation.Status = 0;
            leaveInformation.RequestTime = DateTime.Now;
            leaveInformation.LeaveDay = body.LeaveDay;
            leaveInformation.LeaveStart = body.LeaveStart;
            leaveInformation.LeaveEnd = body.LeaveEnd;
            _dataBase.LeaveInformation.Update(leaveInformation);
            _dataBase.SaveChanges();
            return new LeaveInfo(leaveInformation);
        }
        private LeaveInfoListByPage GetLeaveInfoListByPage(IEnumerable<LeaveInformation> leaveInformationList, int pageNum, int pageSize)
        {
            int total = leaveInformationList.Count();
            int totalPage = 1 + (total - 1) / pageSize;
            LinkedList<LeaveInfo> leaveInfoList = new LinkedList<LeaveInfo>();
            var leaveListByPage = leaveInformationList.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            foreach (var leave in leaveListByPage)
            {
                _dataBase.Entry(leave).Reference(l => l.Student).Load();
                _dataBase.Entry(leave).Reference(l => l.Work).Load();

                leaveInfoList.AddLast(new LeaveInfo(leave));
            }
            LeaveInfoListByPage leavenfoListByPage = new LeaveInfoListByPage();
            leavenfoListByPage.Totalpage = totalPage;
            leavenfoListByPage.Leavelist = leaveInfoList;
            leavenfoListByPage.Pagenum = pageNum;
            leavenfoListByPage.Total = total;

            return leavenfoListByPage;
        }

    }
}
