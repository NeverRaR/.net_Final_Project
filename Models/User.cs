using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SyaBackend.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public int Role { get; set; }

        public int Gender { get; set; }

        public string Username { get; set; }

        public string Avatar { get; set; }

        public string Email { get; set; }

        public string Tel { get; set; }

        public string Bank { get; set; }

        [DataType(DataType.Date)]
        public DateTime Registered { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public string Sale { get; set; }
    }
}
