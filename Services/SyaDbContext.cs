using Microsoft.EntityFrameworkCore;
using SyaBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyaBackend
{
    public class SyaDbContext : DbContext
    {
        public SyaDbContext(DbContextOptions<SyaDbContext> options)
    :   base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
