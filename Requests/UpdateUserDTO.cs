using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyaBackend.Requests
{
    public class UpdateUserDTO
    {
        public bool Gender { get; set; }
        public String Avatar { get; set; }
        public String Tel { get; set; }
        public String Bank { get; set; }
    }
}
