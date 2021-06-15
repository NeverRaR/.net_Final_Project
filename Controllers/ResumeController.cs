using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using SyaBackend.Services;
using SyaBackend.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SyaBackend.Requests;
using SyaBackend.Models;
using SyaBackend.Views;

namespace SyaBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ResumeController : ControllerBase
    {
        private readonly SyaDbContext _dataBase;
        private readonly IDatabase _redis;

        public ResumeController(SyaDbContext context, RedisClient client)
        {
            _dataBase = context;
            _redis = client.GetDatabase();
        }

        [HttpPost("CreateResume")]
        public Object CreateResume([FromBody]ResumeDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (!user.Role.Equals(1))
            {
                return new ErrorInfo("You aren't student!");
            }
            Resume resume = new Resume();
            MakeResume(resume, body, user);
            _dataBase.Resumes.Add(resume);
            _dataBase.SaveChanges();
            ResumeInfo resumeInfo = new ResumeInfo();
            resumeInfo.SetResume(resume);
            resumeInfo.StudentId = user.UserId;
            return resumeInfo;
        }

        [HttpDelete("DeleteResume")]
        public Object DeleteResume()
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (!user.Role.Equals(1))
            {
                return new ErrorInfo("You aren't student!");
            }
            Resume resume = _dataBase.Resumes.Where(r => r.Student.UserId == user.UserId).FirstOrDefault();
            if (resume == null)
            {
                return new ErrorView(-1,"You dont have resume!");
            }

            _dataBase.Resumes.Remove(resume);
            _dataBase.SaveChanges();
            return 1;
        }

        [HttpPut("UpdateResume")]
        public Object UpdateResume([FromBody] ResumeDTO body)
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (!user.Role.Equals(1))
            {
                return new ErrorInfo("You aren't student!");
            }
            Resume resume = _dataBase.Resumes.Where(r => r.Student.UserId == user.UserId).FirstOrDefault();
            if (resume == null)
            {
                return new ErrorView(-1,"You dont have resume!");
            }
            MakeResume(resume, body, user);
            _dataBase.Resumes.Update(resume);
            _dataBase.SaveChanges();
            ResumeInfo resumeInfo = new ResumeInfo();
            resumeInfo.SetResume(resume);
            resumeInfo.StudentId = user.UserId;
            return resumeInfo;
        }

        [HttpPost("GetResumeInfo")]
        public Object GetResumeInfo([FromBody] ResumeIdDTO body)
        {
            Resume resume = _dataBase.Resumes.Find(body.ResumeId);
            if (resume == null)
            {
                return new ErrorView(-1, "Resume isn't exist!");
            }
            ResumeInfo resumeInfo = new ResumeInfo();
            resumeInfo.SetResume(resume);
            resumeInfo.StudentId =resume.StudentId;
            return resumeInfo;
        }

        [HttpPost("GetResume")]
        public Object GetResume()
        {
            User user = RedisHelper.GetUser(Request, _dataBase.Users, _redis);
            if (!user.Role.Equals(1))
            {
                return new ErrorInfo("You aren't student!");
            }
            Resume resume = _dataBase.Resumes.Where(r => r.Student.UserId == user.UserId).FirstOrDefault();
            if (resume == null)
            {
                return new ErrorView(-1, "Resume isn't exist!");
            }
            ResumeInfo resumeInfo = new ResumeInfo();
            resumeInfo.SetResume(resume);
            resumeInfo.StudentId =user.UserId;
            return resumeInfo;
        }

        private void MakeResume(Resume resume, ResumeDTO body, User user)
        {
            resume.Academic = body.Academic;
            resume.Age = body.Age;
            resume.Name = body.StudentName;
            resume.City = body.City;
            resume.Education = body.Education;
            resume.Community = body.Community;
            resume.Project = body.Project;
            resume.Skill = body.Skill;
            resume.Introduction = body.Introduction;
            resume.Student = user;
        }
    }
}
