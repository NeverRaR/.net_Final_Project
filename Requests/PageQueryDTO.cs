using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyaBackend.Requests
{
    public class PageQueryDTO
    {
        public String Query { get; set; }
        public int Pagenum { get; set; }

        public int Pagesize { get; set; }
    }
}
