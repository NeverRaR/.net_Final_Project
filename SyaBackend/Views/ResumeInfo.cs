using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SyaBackend.Models;

namespace SyaBackend.Views
{
    public class ResumeInfo
    {
        public int StudentId { get; set; }
        public int Age { get; set; }
        public String StudentName { get; set; }
        public String City { get; set; }
        public String Education { get; set; }
        public String Community { get; set; }
        public String Project { get; set; }
        public String Academic { get; set; }
        public String Skill { get; set; }
        public String Introduction { get; set; }

        public void SetResume(Resume resume)
        {
            Academic = resume.Academic;
            Age = resume.Age;
            StudentName = resume.Name;
            City = resume.City;
            Education = resume.Education;
            Community = resume.Community;
            Project = resume.Project;
            Skill = resume.Skill;
            Introduction = resume.Introduction;
        }
    }
}
