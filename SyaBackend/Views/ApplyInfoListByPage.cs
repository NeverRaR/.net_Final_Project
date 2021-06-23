using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyaBackend.Views
{
    public class ApplyInfoListByPage
    {
        public IEnumerable<ApplyInfo> Applist { get; set; }

        public int Totalpage { get; set; }

        public int Pagenum { get; set; }
    }
}
