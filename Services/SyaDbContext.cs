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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Like>(b =>
           {
               b.HasKey(x => new { x.WorkId, x.StudentId });
           });
            modelBuilder.Entity<FavoriteHasWork>(f =>
            {
                f.HasKey(x => new { x.WorkId, x.FavoriteId });
            });

            modelBuilder.Entity<User>()
            .HasOne(u => u.Resume)
            .WithOne(r => r.Student)
            .HasForeignKey<Resume>(r => r.StudentId);

            modelBuilder.Entity<User>()
           .HasMany(u => u.StudentApplies)
           .WithOne(a => a.Student);

            modelBuilder.Entity<User>()
           .HasMany(u => u.TeacherApplies)
           .WithOne(a => a.Teacher);


        }

        public DbSet<User> Users { get; set; }

        public DbSet<Work> Works { get; set; }

        public DbSet<Like> Likes { get; set; }

        public DbSet<Favorite> Favorites { get; set; }

        public DbSet<FavoriteHasWork> FavoriteHasWorks { get; set; }

        public DbSet<Resume> Resumes { get; set; }

        public DbSet<Apply> Applies { get; set; }
    }
}
