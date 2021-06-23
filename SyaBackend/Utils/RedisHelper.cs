using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Metrics.Concurrency;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using SyaBackend.Models;
using CLRLogger;

namespace SyaBackend.Utils
{
    public class RedisHelper
    {
        static private Logger logger = new Logger();
        static public User GetUser(HttpRequest request, DbSet<User> users, IDatabase redis)
        {
            String sessionId = "no sessionId";
            bool hasSessionId = request.Cookies.TryGetValue("sessionId", out sessionId);
            if (!hasSessionId)
            {
                String s = "no sessionId in cookies!";
                logger.Log(ref s);
                return null;
            }
            return GetUser(sessionId, users, redis);
        }

        static public User GetUser(String sessionId, DbSet<User> users, IDatabase redis)
        {
            String s;
            String id = redis.StringGet(sessionId);
            if (id == null)
            {
                s = "invalid sessionId:" + sessionId;
                logger.Log(ref s);
                return null;
            }
            User user = users.Find(int.Parse(id));
            s = "sessionId:" + sessionId + " is user:" + user.Username;
            logger.Log(ref s);
            return user;
        }


        static public String CreateSessionId(String useranme,String password, DbSet<User> users, IDatabase redis)
        {
            var userList = users.Where(x => x.Username == useranme);
            if (userList.Count() == 0) return null;
            User user = userList.First();
            String passwordHashed = HashHelper.ComputeSHA256Hash(password + user.Salt);
            if (!user.Password.Equals(passwordHashed)) return null;

            double seed = ThreadLocalRandom.NextDouble();
            String sessionId = HashHelper.ComputeMD5Hash(user.Username + seed);
            redis.StringSet(sessionId, user.UserId, new TimeSpan(8, 0, 0));
            return sessionId;
        }
    }
}
