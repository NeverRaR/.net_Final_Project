using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyaBackend.Views
{
    public class LeaveInfoListByPage
    {
        public int Totalpage { get; set; }
        public int Pagenum { get; set; }

        public int Total { get; set; }
        public IEnumerable<LeaveInfo> Leavelist { get; set; }
    }
}
