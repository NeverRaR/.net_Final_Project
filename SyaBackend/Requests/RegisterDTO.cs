using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyaBackend.Requests
{
    public class RegisterDTO
    {

        public String Username { get; set; }

        public String Email { get; set; }

        public String Password { get; set; }

        public int Role { get; set; }
    }
}
