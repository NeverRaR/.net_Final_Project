using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SyaBackend.Models;
using SyaBackend.Services;
using SyaBackend.Utils;
using StackExchange.Redis;
using SyaBackend.Requests;
using SyaBackend.Views;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SyaBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApplyController : ControllerBase
    {

        private readonly SyaDbContext _dataBase;
        private readonly IDatabase _redis;

        public ApplyController(SyaDbContext context, RedisClient client)
        {
            _dataBase = context;
            _redis = client.GetDatabase();
        }


        // POST api/<ApplyController>
        [HttpPost("CreateApply")]
        public Object CreateApply([FromBody] WorkIdDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null)
            {
                return new ErrorInfo("sessionId is invalid!");
            }
            if (!user.Role.Equals(1))
            {
                return new ErrorInfo("Only Student can Apply!");
            }
            Work work = _dataBase.Works.Find(body.WorkId);
            _dataBase.Entry(work).Reference(w => w.Teacher).Load();
            Resume resume = _dataBase.Resumes.Where(r => r.StudentId == user.UserId).SingleOrDefault();
            if (work == null) return null;
            if (resume == null) return -10;

            Apply apply = _dataBase.Applies.Where(a => a.Work.WorkId == work.WorkId && a.Student.UserId == user.UserId).SingleOrDefault();
            
            if (apply == null)
            {
                apply = new Apply();
                apply.Work = work;
                apply.Student = user;
                apply.Teacher = work.Teacher;
                apply.Resume = resume;
                apply.Status = 0;
                _dataBase.Applies.Add(apply);
                _dataBase.SaveChanges();
                return apply.ApplyId;
            }
            else if (apply.Status == 0) return -22;
            else if (apply.Status == 1) return -21;
            return null;
        }

        // POST api/<ApplyController>
        [HttpPost("ProViewApps")]
        public Object ProViewApps([FromBody] PageDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null)
            {
                return new ErrorInfo("sessionId is invalid!");
            }
            if (user.Role.Equals(1))
            {
                return new ErrorInfo("Students can't check!");
            }


            var applyList = _dataBase.Applies.Where(a => a.Teacher.UserId == user.UserId);
            
          
         
            return GetApplyInfoListByPage(applyList,body.Pagesize,body.Pagenum);
        }

        [HttpPost("ProManageApp")]
        public Object ProManageApp([FromBody] ProManageAppDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null)
            {
                return new ErrorInfo("sessionId is invalid!");
            }
            if (user.Role.Equals(1))
            {
                return new ErrorInfo("Students cannot manage application.");
            }
            if(body.Status == 1 || body.Status == 2)
            {
                Apply apply = _dataBase.Applies.Find(body.ApplyId);
                if (apply == null) return new ErrorInfo("Apply id not found.");
                if(! (apply.Status == 0)) return new ErrorInfo("Apply id not found.");
                _dataBase.Entry(apply).Reference(a => a.Student).Load();
                _dataBase.Entry(apply).Reference(a => a.Teacher).Load();
                _dataBase.Entry(apply).Reference(a => a.Work).Load();
                _dataBase.Entry(apply).Reference(a => a.Resume).Load();
                if ( body.Status == 2)
                {
                    apply.Status = 2;
                    _dataBase.Applies.Update(apply);
                }
                else
                {
                    apply.Status = 1;
                    _dataBase.Applies.Update(apply);
                    Take take = new Take();
                    take.AbsentTime = 0.0;
                    take.AbsentNum = 0;
                    take.WorkId = apply.Work.WorkId;
                    take.WorkTime = apply.Work.GetTotalTime();
                    take.StudentId=apply.Student.UserId;
                    take.Status = 0;
                    _dataBase.Takes.Add(take);
                }
                _dataBase.SaveChanges();
                return new ApplyInfo(apply);
            }
            else return new ErrorInfo("Application have been managed.");

        }

        private ApplyInfoListByPage GetApplyInfoListByPage(IEnumerable<Apply> ApplyList,int pageSize,int pageNum)
        {
            ApplyInfoListByPage applyInfoListByPage = new ApplyInfoListByPage();
            int totalPage = 1 + (ApplyList.Count() - 1) / pageSize;
            applyInfoListByPage.Totalpage = totalPage;
            applyInfoListByPage.Pagenum = pageNum;
            var applyListByPage = ApplyList.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            LinkedList<ApplyInfo> applyInfoList = new LinkedList<ApplyInfo>();
            foreach(var apply in applyListByPage)
            {
                _dataBase.Entry(apply).Reference(a => a.Student).Load();
                _dataBase.Entry(apply).Reference(a => a.Teacher).Load();
                _dataBase.Entry(apply).Reference(a => a.Work).Load();
                _dataBase.Entry(apply).Reference(a => a.Resume).Load();
                applyInfoList.AddLast(new ApplyInfo(apply));
            }
            applyInfoListByPage.Applist = applyInfoList;

            return applyInfoListByPage;
        }
    }
}
