using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SyaBackend.Models;
using SyaBackend.Utils;
using StackExchange.Redis;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SyaBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly SyaDbContext _context;
        private readonly IDatabase _redis;

        public UserController(SyaDbContext context, RedisClient client)
        {
            _context = context;
            _redis = client.GetDatabase();
        }

        // GET: api/<UserController>
        [HttpGet]
        public string Get()
        {
            _redis.StringSet("hello", "1");
            return _redis.StringGet("hello");
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] User body)
        {
            _context.Users.Add(body);
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
