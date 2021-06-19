using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SyaBackend.Models;
namespace SyaBackend.Views
{
    public class LeaveInfo
    {

        public int LeaveId { get; set; }
        public int WorkId { get; set; }

        public int StudentId { get; set; }

        public String WorkName { get; set; }

        public String StudentName { get; set; }
        public String Content { get; set; }
        public String Proof { get; set; }


        public int Status { get; set; }


        public String LeaveDay { get; set; }


        public String LeaveStart { get; set; }


        public String LeaveEnd { get; set; }

        public Double LeaveDuration { get; set; }

        public DateTime RequestTime { get; set; }

        public LeaveInfo(LeaveInformation leaveInformation)
        {
            LeaveId = leaveInformation.LeaveInformationId;
            StudentId = leaveInformation.Student.UserId;
            StudentName = leaveInformation.Student.Username;
            WorkId = leaveInformation.Work.WorkId;
            WorkName = leaveInformation.Work.Name;
            Content = leaveInformation.Content;
            Proof = leaveInformation.Proof;
            Status = leaveInformation.Status;
            RequestTime = leaveInformation.RequestTime;
            LeaveDay = leaveInformation.LeaveDay;
            LeaveStart = leaveInformation.LeaveStart;
            LeaveEnd = leaveInformation.LeaveEnd;
            LeaveDuration = leaveInformation.GetTotalTime();
        }
    }
}
