using SyaBackend.Models;
using System;

namespace SyaBackend.Views
{
    public class ApplyInfo
    {

        public int ApplyId { get; set; }


        public String StudentName { get; set; }


        public String TeacherName { get; set; }


        public String WorkName { get; set; }


        public int ResumeId { get; set; }


        public int Status { get; set; }

        public ApplyInfo(Apply apply)
        {
            ApplyId = apply.ApplyId;
            StudentName = apply.Student.Username;
            TeacherName = apply.Teacher.Username;
            WorkName = apply.Work.Name;
            ResumeId = apply.Resume.ResumeId;
            Status = apply.Status;
        }
    }
}
