using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyaBackend.Views
{
    public class AnnouncementInfoListByPage
    {
        public int Totalpage { get; set; }

        public int Pagenum { get; set; }

        public IEnumerable<AnnouncementInfo> AnnouncementItem { get; set; }
    }
}
