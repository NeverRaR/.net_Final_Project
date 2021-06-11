﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Metrics.Concurrency;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using SyaBackend.Models;

namespace SyaBackend.Utils
{
    public class RedisHelper
    {
        static public User GetUser(HttpRequest request, DbSet<User> users, IDatabase redis)
        {
            String sessionId = "no sessionId";
            bool hasSessionId = request.Cookies.TryGetValue("sessionId", out sessionId);
            if (!hasSessionId) return null;
            return GetUser(sessionId, users, redis);
        }

        static public User GetUser(String sessionId, DbSet<User> users, IDatabase redis)
        {
            String id = redis.StringGet(sessionId);
            if (id == null) return null;
            User user = users.Find(int.Parse(id));
            return user;
        }


        static public String CreateSessionId(String useranme,String password, DbSet<User> users, IDatabase redis)
        {
            var userList = users.Where(x => x.Username == useranme);
            if (userList.Count() == 0) return null;
            User user = users.First();
            String passwordHashed = HashHelper.ComputeSHA256Hash(password + user.Salt);
            if (!user.Password.Equals(passwordHashed)) return null;

            double seed = ThreadLocalRandom.NextDouble();
            String sessionId = HashHelper.ComputeMD5Hash(user.Username + seed);
            redis.StringSet(sessionId, user.UserId, new TimeSpan(8, 0, 0));
            return sessionId;
        }
    }
}
