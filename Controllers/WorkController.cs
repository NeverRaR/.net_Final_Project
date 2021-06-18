using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using SyaBackend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SyaBackend.Models;
using SyaBackend.Requests;
using SyaBackend.Utils;
using SyaBackend.Views;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SyaBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly SyaDbContext _dataBase;
        private readonly IDatabase _redis;

        public WorkController(SyaDbContext context, RedisClient client)
        {
            _dataBase = context;
            _redis = client.GetDatabase();
        }
        
        [HttpPost("CreateWork")]
        public Object CreateWork([FromBody] CreateWorkDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user.Role.Equals(1))
            {
                return new ErrorInfo("Student cannot create work");
            }
            if (body.StartTime.Equals(body.EndTime))
            {
                return new ErrorInfo("Duration time is 0.");
            }

            Work work = new Work();
            work.Address = body.Address;
            work.Cover = body.Cover;
            work.Description = body.WorkDescription;
            work.Name = body.WorkName;
            work.EndDay = body.EndDay;
            work.EndTime = body.EndTime;
            work.Salary = body.Salary;
            work.StartDay = body.StartDay;
            work.StartTime = body.StartTime;
            work.WeekDay = body.WeekDay;
            work.Teacher = user;

            _dataBase.Works.Add(work);
            _dataBase.SaveChanges();

            return GetWorkStatus(work);
        }

        [HttpPost("ViewWorkInfo")]
        public WorkStatus ViewWorkInfo([FromBody] WorkIdDTO body)
        {
            Work work = _dataBase.Works.Find(body.WorkId);
            return GetWorkStatus(work);
        }

        [HttpPost("ViewOwnWork")]
        public Object ViewOwnWork([FromBody] PageDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null)
            {
                return new ErrorInfo("sessionId is invalid!");
            }
           var takeWithWorkList = from take in _dataBase.Takes
                                  where take.StudentId == user.UserId
                                  join work in _dataBase.Works
                                  on take.WorkId equals work.WorkId
                               select new TakeWithWork() { TakeInfo=take,WorkInfo=work};
         
            return GetWorkStatusListByPage(takeWithWorkList, body.Pagenum, body.Pagesize);
        }

        [HttpPost("ViewHistoryWork")]
        public Object ViewHistoryWork([FromBody] PageDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null)
            {
                return new ErrorInfo("sessionId is invalid!");
            }
            if (user.Role.Equals(1))
            {
                return new ErrorInfo("ViewHistoryWork is not for students. Students please try ViewOwnWork.");
            }
            var takeWithWorkList = from work in _dataBase.Works
                                   where work.Teacher.UserId == user.UserId
                                   select new TakeWithWork() { TakeInfo = null, WorkInfo = work };

            return GetWorkStatusListByPage(takeWithWorkList, body.Pagenum,body.Pagesize);
        }

        [HttpPost("ViewAllWork")]
        public Object ViewAllWork([FromBody] PageDTO body)
        {
           
            var takeWithWorkList = from work in _dataBase.Works
                                   select new TakeWithWork() { TakeInfo = null, WorkInfo = work };

            return GetWorkStatusListByPage(takeWithWorkList, body.Pagenum, body.Pagesize);
        }

        [HttpPost("FindWork")]
        public Object FindWork([FromBody] PageQueryDTO body)
        {
            String query = body.Query;
            var takeWithWorkList = from work in _dataBase.Works
                                   where work.Address.Contains(query) || work.Name.Contains(query)||work.Description.Contains(query)
                                   select new TakeWithWork() { TakeInfo = null, WorkInfo = work };

            return GetWorkStatusListByPage(takeWithWorkList, body.Pagenum, body.Pagesize);
        }

        [HttpPost("FindOwnWork")]
        public Object FindOwnWork([FromBody] PageQueryDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null)
            {
                return new ErrorInfo("sessionId is invalid!");
            }

            String query = body.Query;
            var takeWithWorkList = from take in _dataBase.Takes
                                   where take.StudentId == user.UserId
                                   join work in _dataBase.Works
                                   on take.WorkId equals work.WorkId
                                   where work.Address.Contains(query) || work.Name.Contains(query) || work.Description.Contains(query)
                                   select new TakeWithWork() { TakeInfo = take, WorkInfo = work };

            return GetWorkStatusListByPage(takeWithWorkList, body.Pagenum, body.Pagesize);
        }

        [HttpPost("DeleteWork")]
        public Object DeleteWork([FromBody] WorkIdDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null)
            {
                return new ErrorInfo("sessionId is invalid!");
            }
            if (user.Role.Equals(1))
            {
                return new ErrorInfo("You are a student!");
            }
            Work work = _dataBase.Works.Find(body.WorkId);
            if(work == null)
            {
                return new ErrorView(-1, "Work isn't exist!");
            }
            if(work.Teacher.UserId != user.UserId)
            {
                return new ErrorInfo("You are not the owner!");
            }
            _dataBase.Works.Remove(work);
            _dataBase.SaveChanges();

            return 1;
        }

        [HttpPost("ChangeWorkInfo")]
        public Object ChangeWorkInfo([FromBody] UpdateWorkDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null)
            {
                return new ErrorInfo("sessionId is invalid!");
            }
            if (user.Role.Equals(1))
            {
                return new ErrorInfo("You are a student!");
            }
            Work work = _dataBase.Works.Find(body.WorkId);
            if (work == null)
            {
                return new ErrorView(-1, "Work isn't exist!");
            }
            if (work.Teacher.UserId != user.UserId)
            {
                return new ErrorInfo("You are not the owner!");
            }

            if(body.Address != null)
                work.Address = body.Address;
            if (body.Cover != null)
                work.Cover = body.Cover;
            if (body.WorkDescription != null)
                work.Description = body.WorkDescription;
            if (body.WorkName != null)
                work.Name = body.WorkName;
            if (body.EndDay != null)
                work.EndDay = body.EndDay;
            if (body.EndTime != null)
                work.EndTime = body.EndTime;
            if (body.Salary != null)
                work.Salary = (int) body.Salary;
            if (body.StartDay != null)
                work.StartDay = body.StartDay;
            if (body.StartTime != null)
                work.StartTime = body.StartTime;
            if (body.WeekDay != null)
                work.WeekDay =(int) body.WeekDay;

            _dataBase.Works.Update(work);
            _dataBase.SaveChanges();

            return GetWorkStatus(work);
        }


        [HttpPost("ChangeLike")]
        public Object ChangeLike([FromBody] WorkIdDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null)
            {
                return new ErrorInfo("sessionId is invalid!");
            }
            Work work = _dataBase.Works.Find(body.WorkId);
            if (work == null)
            {
                return new ErrorView(-1, "Work isn't exist!");
            }
            Like like = _dataBase.Likes.Find(work.WorkId, user.UserId);
            if (like == null)
            {
                like = new Like();
                like.StudentId = user.UserId;
                like.WorkId = work.WorkId;
                _dataBase.Likes.Add(like);
                _dataBase.SaveChanges();
                return 1;
            }
            _dataBase.Likes.Remove(like);
            _dataBase.SaveChanges();
            return 0;

        }

        [HttpPost("GetLike")]
        public Object GetLike([FromBody] WorkIdDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null)
            {
                return new ErrorInfo("sessionId is invalid!");
            }
            Work work = _dataBase.Works.Find(body.WorkId);
            if (work == null)
            {
                return new ErrorView(-1, "Work isn't exist!");
            }
            Like like = _dataBase.Likes.Find(work.WorkId, user.UserId);
            if (like == null)
            {            
                return 0;
            }
           
            return 1;

        }


        [HttpPost("GetResign")]
        public Object GetResign([FromBody] WorkIdDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null)
            {
                return new ErrorInfo("sessionId is invalid!");
            }
            Work work = _dataBase.Works.Find(body.WorkId);
            if (work == null)
            {
                return new ErrorView(-1, "Work isn't exist!");
            }
            _dataBase.Entry(work).Reference(w => w.Teacher).Load();
            Take take = _dataBase.Takes.Find(work.WorkId, user.UserId);
            if (take == null)
            {
                return 0;
            }

            take.Status = 1;
            _dataBase.Takes.Update(take);

            Apply apply = _dataBase.Applies.Find(work.WorkId, user.UserId);

            if(apply != null)
            {
                _dataBase.Applies.Remove(apply);
            }

            MessageLibrary messageResign = new MessageLibrary();
            String content = user.Username + "同学辞去" + work.Name + "工作";
            messageResign.MessageType = 0;
            messageResign.ContentType = 1;
            messageResign.Content = content;
            messageResign.Status = 0;
            messageResign.Time = DateTime.Now;
            messageResign.Sender = user;
            messageResign.Receiver = work.Teacher;

            _dataBase.MessageLibraries.Add(messageResign);
            _dataBase.SaveChanges();


            return 1;

        }


        [HttpPost("DeleteResign")]
        public Object DeleteResign  ([FromBody] WorkIdDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (user == null)
            {
                return new ErrorInfo("sessionId is invalid!");
            }
         
            Take take = _dataBase.Takes.Find(body.WorkId, user.UserId);
            if (take == null)
            {
                return 1;
            }

            if(take.Status == 0)
            {
                return 0;
            }
            _dataBase.Takes.Remove(take);
            _dataBase.SaveChanges();
            return 1;
        }

        private WorkStatusListByPage GetWorkStatusListByPage(IEnumerable<TakeWithWork> takeWithWorkList,int pageNum,int pageSize)
        {
            int totalPage = 1 + (takeWithWorkList.Count() - 1) /pageSize;
            LinkedList<WorkStatus> workStatusList = new LinkedList<WorkStatus>();
            var takeWithWorkListByPage = takeWithWorkList.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            foreach (var takeWithWork in takeWithWorkListByPage)
            {
                WorkStatus workStatus = GetWorkStatus(takeWithWork.WorkInfo);
                if (takeWithWork.TakeInfo != null)
                {
                    workStatus.Status = takeWithWork.TakeInfo.Status;
                }
                workStatusList.AddLast(workStatus);
            }
            WorkStatusListByPage workStatusListByPage = new WorkStatusListByPage();
            workStatusListByPage.Totalpage = totalPage;
            workStatusListByPage.Worklist = workStatusList;
            workStatusListByPage.Pagenum = pageNum;

            return workStatusListByPage;
        }
        private WorkStatus GetWorkStatus(Work work)
        {
            WorkStatus workStatus = new WorkStatus();
            if (work == null)
            {
                return workStatus;
            }

            workStatus.Address = work.Address;
            workStatus.Cover = work.Cover;
            workStatus.EndDay = work.EndDay;
            workStatus.EndTime = work.EndTime;
            workStatus.StartDay = work.StartDay;
            workStatus.StartTime = work.StartTime;
            workStatus.Salary = work.Salary;
            workStatus.WeekDay = work.WeekDay;
            workStatus.WorkName = work.Name;
            workStatus.WorkDescription = work.Description;
            workStatus.Id = work.WorkId;

            workStatus.CollectNum = _dataBase.FavoriteHasWorks.Where(f => f.WorkId == work.WorkId).Count();
            workStatus.LikesNum = _dataBase.Likes.Where(l => l.WorkId == work.WorkId).Count();
            workStatus.TotalTime = work.GetTotalTime();
            

            return workStatus;

        }

    }
}
