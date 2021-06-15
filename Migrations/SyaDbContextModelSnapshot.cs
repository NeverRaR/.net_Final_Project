﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SyaBackend;

namespace SyaBackend.Migrations
{
    [DbContext(typeof(SyaDbContext))]
    partial class SyaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("SyaBackend.Models.Announcement", b =>
                {
                    b.Property<int>("AnnouncementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("sendTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("AnnouncementId");

                    b.HasIndex("UserId");

                    b.ToTable("announcement");
                });

            modelBuilder.Entity("SyaBackend.Models.AnnouncementSend", b =>
                {
                    b.Property<int>("AnnouncementId")
                        .HasColumnType("int");

                    b.Property<int>("ReceiverId")
                        .HasColumnType("int");

                    b.HasKey("AnnouncementId", "ReceiverId");

                    b.HasIndex("ReceiverId");

                    b.ToTable("announcement_send");
                });

            modelBuilder.Entity("SyaBackend.Models.Apply", b =>
                {
                    b.Property<int>("ApplyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ResumeId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("StudentUserId")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherUserId")
                        .HasColumnType("int");

                    b.Property<int?>("WorkId")
                        .HasColumnType("int");

                    b.HasKey("ApplyId");

                    b.HasIndex("ResumeId");

                    b.HasIndex("StudentUserId");

                    b.HasIndex("TeacherUserId");

                    b.HasIndex("WorkId");

                    b.ToTable("apply");
                });

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

                    b.ToTable("favorite");
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

                    b.ToTable("favorite_has_work");
                });

            modelBuilder.Entity("SyaBackend.Models.LeaveInformation", b =>
                {
                    b.Property<int>("LeaveInformationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("longtext");

                    b.Property<string>("LeaveDay")
                        .HasColumnType("longtext");

                    b.Property<string>("LeaveEnd")
                        .HasColumnType("longtext");

                    b.Property<string>("LeaveStart")
                        .HasColumnType("longtext");

                    b.Property<string>("Proof")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("RequestTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("StudentUserId")
                        .HasColumnType("int");

                    b.Property<int?>("WorkId")
                        .HasColumnType("int");

                    b.HasKey("LeaveInformationId");

                    b.HasIndex("StudentUserId");

                    b.HasIndex("WorkId");

                    b.ToTable("leave_information");
                });

            modelBuilder.Entity("SyaBackend.Models.Like", b =>
                {
                    b.Property<int>("WorkId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("WorkId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("work_like");
                });

            modelBuilder.Entity("SyaBackend.Models.MessageLibrary", b =>
                {
                    b.Property<int>("MessageLibraryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("longtext");

                    b.Property<int>("ContentType")
                        .HasColumnType("int");

                    b.Property<int>("MessageType")
                        .HasColumnType("int");

                    b.Property<int?>("ReceiverUserId")
                        .HasColumnType("int");

                    b.Property<int?>("SenderUserId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime(6)");

                    b.HasKey("MessageLibraryId");

                    b.HasIndex("ReceiverUserId");

                    b.HasIndex("SenderUserId");

                    b.ToTable("message_library");
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

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("ResumeId");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("resume");
                });

            modelBuilder.Entity("SyaBackend.Models.Take", b =>
                {
                    b.Property<int>("WorkId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("AbsentNum")
                        .HasColumnType("int");

                    b.Property<double>("AbsentTime")
                        .HasColumnType("double");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<double>("WorkTime")
                        .HasColumnType("double");

                    b.HasKey("WorkId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("takes");
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

                    b.ToTable("user");
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

                    b.ToTable("work");
                });

            modelBuilder.Entity("SyaBackend.Models.Announcement", b =>
                {
                    b.HasOne("SyaBackend.Models.User", "User")
                        .WithMany("Announcements")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SyaBackend.Models.AnnouncementSend", b =>
                {
                    b.HasOne("SyaBackend.Models.Announcement", null)
                        .WithMany("AnnouncementSends")
                        .HasForeignKey("AnnouncementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SyaBackend.Models.User", null)
                        .WithMany("AnnouncementSends")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SyaBackend.Models.Apply", b =>
                {
                    b.HasOne("SyaBackend.Models.Resume", "Resume")
                        .WithMany("Applies")
                        .HasForeignKey("ResumeId");

                    b.HasOne("SyaBackend.Models.User", "Student")
                        .WithMany("StudentApplies")
                        .HasForeignKey("StudentUserId");

                    b.HasOne("SyaBackend.Models.User", "Teacher")
                        .WithMany("TeacherApplies")
                        .HasForeignKey("TeacherUserId");

                    b.HasOne("SyaBackend.Models.Work", "Work")
                        .WithMany("Applies")
                        .HasForeignKey("WorkId");

                    b.Navigation("Resume");

                    b.Navigation("Student");

                    b.Navigation("Teacher");

                    b.Navigation("Work");
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

            modelBuilder.Entity("SyaBackend.Models.LeaveInformation", b =>
                {
                    b.HasOne("SyaBackend.Models.User", "Student")
                        .WithMany("LeaveInformation")
                        .HasForeignKey("StudentUserId");

                    b.HasOne("SyaBackend.Models.Work", "Work")
                        .WithMany("LeaveInformation")
                        .HasForeignKey("WorkId");

                    b.Navigation("Student");

                    b.Navigation("Work");
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

            modelBuilder.Entity("SyaBackend.Models.MessageLibrary", b =>
                {
                    b.HasOne("SyaBackend.Models.User", "Receiver")
                        .WithMany("ReceiverMessageLibraries")
                        .HasForeignKey("ReceiverUserId");

                    b.HasOne("SyaBackend.Models.User", "Sender")
                        .WithMany("SenderMessageLibraries")
                        .HasForeignKey("SenderUserId");

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("SyaBackend.Models.Resume", b =>
                {
                    b.HasOne("SyaBackend.Models.User", "Student")
                        .WithOne("Resume")
                        .HasForeignKey("SyaBackend.Models.Resume", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SyaBackend.Models.Take", b =>
                {
                    b.HasOne("SyaBackend.Models.User", null)
                        .WithMany("Takes")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SyaBackend.Models.Work", null)
                        .WithMany("Takes")
                        .HasForeignKey("WorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SyaBackend.Models.Work", b =>
                {
                    b.HasOne("SyaBackend.Models.User", "Teacher")
                        .WithMany("Works")
                        .HasForeignKey("TeacherUserId");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SyaBackend.Models.Announcement", b =>
                {
                    b.Navigation("AnnouncementSends");
                });

            modelBuilder.Entity("SyaBackend.Models.Favorite", b =>
                {
                    b.Navigation("FavoriteHasWorks");
                });

            modelBuilder.Entity("SyaBackend.Models.Resume", b =>
                {
                    b.Navigation("Applies");
                });

            modelBuilder.Entity("SyaBackend.Models.User", b =>
                {
                    b.Navigation("Announcements");

                    b.Navigation("AnnouncementSends");

                    b.Navigation("Favorites");

                    b.Navigation("LeaveInformation");

                    b.Navigation("Likes");

                    b.Navigation("ReceiverMessageLibraries");

                    b.Navigation("Resume");

                    b.Navigation("SenderMessageLibraries");

                    b.Navigation("StudentApplies");

                    b.Navigation("Takes");

                    b.Navigation("TeacherApplies");

                    b.Navigation("Works");
                });

            modelBuilder.Entity("SyaBackend.Models.Work", b =>
                {
                    b.Navigation("Applies");

                    b.Navigation("FavoriteHasWorks");

                    b.Navigation("LeaveInformation");

                    b.Navigation("Likes");

                    b.Navigation("Takes");
                });
#pragma warning restore 612, 618
        }
    }
}
