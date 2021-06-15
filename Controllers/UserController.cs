using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SyaBackend.Models;
using SyaBackend.Utils;
using StackExchange.Redis;
using SyaBackend.Views;
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
            return null;
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User value)
        {

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
