using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SyaBackend.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

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

        public Resume Resume { get; set; }

        public List<Work> Works { get; set; }

        public List<Favorite> Favorites { get; set; }

        public List<Apply> StudentApplies { get; set; }

        public List<Apply> TeacherApplies { get; set; }

        [ForeignKey("StudentId")]
        public List<Like> Likes { get; set; }
    }
}
