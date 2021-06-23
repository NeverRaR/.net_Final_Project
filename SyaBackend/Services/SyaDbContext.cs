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
            modelBuilder.Entity<Like>(l =>
           {
               l.HasKey(x => new { x.WorkId, x.StudentId });
           });

            modelBuilder.Entity<MessageLibrary>(m =>
            {
                m.HasKey(x => new { x.MessageLibraryId });
            });


            modelBuilder.Entity<FavoriteHasWork>(f =>
            {
                f.HasKey(x => new { x.WorkId, x.FavoriteId });
            });

            modelBuilder.Entity<Take>(t =>
            {
                t.HasKey(x => new { x.WorkId, x.StudentId });
            });

            modelBuilder.Entity<AnnouncementSend>(a =>
            {
                a.HasKey(x => new { x.AnnouncementId, x.ReceiverId });
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

            modelBuilder.Entity<User>()
            .HasMany(u => u.ReceiverMessageLibraries)
            .WithOne(m => m.Receiver);

            modelBuilder.Entity<User>()
           .HasMany(u => u.SenderMessageLibraries)
           .WithOne(m => m.Sender);


        }

        public DbSet<User> Users { get; set; }

        public DbSet<Work> Works { get; set; }

        public DbSet<Like> Likes { get; set; }

        public DbSet<Favorite> Favorites { get; set; }

        public DbSet<FavoriteHasWork> FavoriteHasWorks { get; set; }

        public DbSet<Resume> Resumes { get; set; }

        public DbSet<Apply> Applies { get; set; }

        public DbSet<Take> Takes { get; set; }

        public DbSet<LeaveInformation> LeaveInformation { get; set; }

        public DbSet<MessageLibrary> MessageLibraries { get; set; }

        public DbSet<Announcement> Announcements { get; set; }

        public DbSet<AnnouncementSend> AnnouncementSends { get; set; }
    }
}

/*
 SELECT C.TABLE_SCHEMA            ,
           C.REFERENCED_TABLE_NAME   ,
           C.REFERENCED_COLUMN_NAME  ,
           C.TABLE_NAME             ,
           C.COLUMN_NAME            ,
           C.CONSTRAINT_NAME        ,
           T.TABLE_COMMENT          ,
           R.UPDATE_RULE            ,
           R.DELETE_RULE 
      FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE C
      JOIN INFORMATION_SCHEMA. TABLES T
        ON T.TABLE_NAME = C.TABLE_NAME
      JOIN INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS R
        ON R.TABLE_NAME = C.TABLE_NAME
       AND R.CONSTRAINT_NAME = C.CONSTRAINT_NAME
       AND R.REFERENCED_TABLE_NAME = C.REFERENCED_TABLE_NAME
      WHERE C.REFERENCED_TABLE_NAME IS NOT NULL AND C.TABLE_SCHEMA='db_example';
*/