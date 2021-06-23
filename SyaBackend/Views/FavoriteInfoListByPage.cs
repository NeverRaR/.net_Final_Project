using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyaBackend.Views
{
    public class FavoriteInfoListByPage
    {
        public IEnumerable<FavoriteInfo> FavoriteItem { set; get; }

        public int Totalpage { get; set; }

        public int Pagenum { get; set; }
    }
}
