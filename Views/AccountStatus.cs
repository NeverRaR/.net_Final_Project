using SyaBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyaBackend.Views
{
    public class AccountStatus
    {
        public int Id { get; set; }

        public String Username { get; set; }

        public String Email { get; set; }

        public int Role { get; set; }

        public void SetUser(User user)
        {
            Id=user.Id;
            Email = user.Email;
            Role = user.Role;
            Username = user.Username;
        }
    }
}
