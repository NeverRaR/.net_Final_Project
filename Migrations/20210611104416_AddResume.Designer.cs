﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SyaBackend;

namespace SyaBackend.Migrations
{
    [DbContext(typeof(SyaDbContext))]
    [Migration("20210611104416_AddResume")]
    partial class AddResume
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("SyaBackend.Models.Favorite", b =>
                {
                    b.Property<int>("FavoriteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("FavoriteId");

                    b.HasIndex("UserId");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("SyaBackend.Models.FavoriteHasWork", b =>
                {
                    b.Property<int>("WorkId")
                        .HasColumnType("int");

                    b.Property<int>("FavoriteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AddDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("WorkId", "FavoriteId");

                    b.HasIndex("FavoriteId");

                    b.ToTable("FavoriteHasWorks");
                });

            modelBuilder.Entity("SyaBackend.Models.Like", b =>
                {
                    b.Property<int>("WorkId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("WorkId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("SyaBackend.Models.Resume", b =>
                {
                    b.Property<int>("ResumeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Academic")
                        .HasColumnType("longtext");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<string>("Community")
                        .HasColumnType("longtext");

                    b.Property<string>("Education")
                        .HasColumnType("longtext");

                    b.Property<string>("Introduction")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Project")
                        .HasColumnType("longtext");

                    b.Property<string>("Skill")
                        .HasColumnType("longtext");

                    b.HasKey("ResumeId");

                    b.ToTable("Resumes");
                });

            modelBuilder.Entity("SyaBackend.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Avatar")
                        .HasColumnType("longtext");

                    b.Property<string>("Bank")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Registered")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("ResumeId")
                        .HasColumnType("int");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Sale")
                        .HasColumnType("longtext");

                    b.Property<string>("Salt")
                        .HasColumnType("longtext");

                    b.Property<string>("Tel")
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.HasIndex("ResumeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SyaBackend.Models.Work", b =>
                {
                    b.Property<int>("WorkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<string>("Cover")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("EndDay")
                        .HasColumnType("longtext");

                    b.Property<string>("EndTime")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.Property<string>("StartDay")
                        .HasColumnType("longtext");

                    b.Property<string>("StartTime")
                        .HasColumnType("longtext");

                    b.Property<int?>("TeacherUserId")
                        .HasColumnType("int");

                    b.Property<int>("WeekDay")
                        .HasColumnType("int");

                    b.HasKey("WorkId");

                    b.HasIndex("TeacherUserId");

                    b.ToTable("Works");
                });

            modelBuilder.Entity("SyaBackend.Models.Favorite", b =>
                {
                    b.HasOne("SyaBackend.Models.User", "User")
                        .WithMany("Favorites")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SyaBackend.Models.FavoriteHasWork", b =>
                {
                    b.HasOne("SyaBackend.Models.Favorite", null)
                        .WithMany("FavoriteHasWorks")
                        .HasForeignKey("FavoriteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SyaBackend.Models.Work", null)
                        .WithMany("FavoriteHasWorks")
                        .HasForeignKey("WorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SyaBackend.Models.Like", b =>
                {
                    b.HasOne("SyaBackend.Models.User", null)
                        .WithMany("Likes")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SyaBackend.Models.Work", null)
                        .WithMany("Likes")
                        .HasForeignKey("WorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SyaBackend.Models.User", b =>
                {
                    b.HasOne("SyaBackend.Models.Resume", "Resume")
                        .WithMany()
                        .HasForeignKey("ResumeId");

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("SyaBackend.Models.Work", b =>
                {
                    b.HasOne("SyaBackend.Models.User", "Teacher")
                        .WithMany("Works")
                        .HasForeignKey("TeacherUserId");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SyaBackend.Models.Favorite", b =>
                {
                    b.Navigation("FavoriteHasWorks");
                });

            modelBuilder.Entity("SyaBackend.Models.User", b =>
                {
                    b.Navigation("Favorites");

                    b.Navigation("Likes");

                    b.Navigation("Works");
                });

            modelBuilder.Entity("SyaBackend.Models.Work", b =>
                {
                    b.Navigation("FavoriteHasWorks");

                    b.Navigation("Likes");
                });
#pragma warning restore 612, 618
        }
    }
}
