using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyaBackend.Views
{
    public class ErrorInfo
    {
        public String Message { get; set; }

        public ErrorInfo(String m)
        {
            Message = m;
        }
    }
}
