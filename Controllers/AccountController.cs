﻿using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using SyaBackend.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SyaBackend.Requests;
using SyaBackend.Models;
using SyaBackend.Views;
using App.Metrics.Concurrency;
using Microsoft.AspNetCore.Http;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SyaBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {


        private readonly SyaDbContext _dataBase;
        private readonly IDatabase _redis;

        public AccountController(SyaDbContext context, RedisHelper client)
        {
            _dataBase = context;
            _redis = client.GetDatabase();
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost("Register")]
        public AccountStatus Register([FromBody]  RegisterDTO request)
        {
            AccountStatus accountStatus = new AccountStatus();
            if (request.Role == 0) return accountStatus;
            var users = _dataBase.Users.Where(x => x.Username == request.Username);
            if (users.Count()>0) return accountStatus;
            User user = new User();
            user.Username = request.Username;
            double seed = ThreadLocalRandom.NextDouble();
            user.Salt = HashHelper.ComputeSHA256Hash(request.Username + seed);
            user.Password= HashHelper.ComputeSHA256Hash(request.Password + user.Salt);
            user.Email = request.Email;
            user.Role = request.Role;
            user.Registered = new DateTime();
            _dataBase.Users.Add(user);
            _dataBase.SaveChanges();
            accountStatus.SetUser(user);

            return accountStatus;

        }

        [HttpPost("Login")]
        public AccountStatus Login([FromBody] LoginDTO request)
        {
            AccountStatus accountStatus = new AccountStatus();
            var users = _dataBase.Users.Where(x => x.Username == request.Username);
            if (users.Count() == 0) return accountStatus;
            User user = users.First();
            String passwordHashed = HashHelper.ComputeSHA256Hash(request.Password + user.Salt);
            if (!user.Password.Equals(passwordHashed)) return accountStatus;

            double seed = ThreadLocalRandom.NextDouble();
            String sessionId = HashHelper.ComputeMD5Hash(user.Username + seed);
            _redis.StringSet(sessionId, user.Id, new TimeSpan(8, 0, 0));

            var cookieOptions= new CookieOptions();
            cookieOptions.Path = "/";
            cookieOptions.HttpOnly = true;
            cookieOptions.MaxAge = new TimeSpan(8, 0, 0);

            Response.Cookies.Append("sessionId", sessionId, cookieOptions);
            accountStatus.SetUser(user);

            return accountStatus;
        }

        [HttpPost("LoginStatus")]
        public AccountStatus LoginStatus()
        {
            AccountStatus accountStatus = new AccountStatus();
            String sessionId = "no sessionId";
            bool hasSessionId = Request.Cookies.TryGetValue("sessionId",out sessionId);
            if (!hasSessionId) return accountStatus;
            int id = (int) _redis.StringGet(sessionId) ;
            User user = _dataBase.Users.Find(id);
            accountStatus.SetUser(user);
            return accountStatus;
        }

        [HttpPost("Logout")]
        public void Logout()
        {
            AccountStatus accountStatus = new AccountStatus();
            String sessionId = "no sessionId";
            bool hasSessionId = Request.Cookies.TryGetValue("sessionId", out sessionId);
            if (!hasSessionId)  return ;
            _redis.KeyDelete(sessionId);
            Response.Cookies.Delete("sessionId");
        }

    }
}
