using Newtonsoft.Json;
using SyaBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyaBackend.Views
{
    public class UserStatus
    {

        public int UserId { get; set; }

        public int UserRole { get; set; }

        public String UserName { get; set; }

        public Boolean Gender { get; set; }

        public String Avatar { get; set; }

        public String Email { get; set; }

        public String Tel { get; set; }

        public String Bank { get; set; }

        public int NofApply { get; set; }

        [JsonProperty("nof_absent")]
        public int NofAbsent { get; set; }

        public Double WorkTime { get; set; }

        public Double AbsentTime { get; set; }

        public Double Income { get; set; }

        public void setUser(User user)
        {
            UserId = user.UserId;
            UserRole = user.Role;
            UserName = user.Username;
            Gender = user.Gender.Equals(1);
            Avatar = user.Avatar;
            Email = user.Email;
            Tel = user.Tel;
            Bank = user.Bank;
        }
    }
}
