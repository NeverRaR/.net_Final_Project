using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyaBackend.Views
{
    public class ErrorView
    {
        public int ErrorCode { get; set; }
        public String Message { get; set; }

        public ErrorView(int ErrorCode, String Message)
        {
            this.ErrorCode = ErrorCode;
            this.Message = Message;
        }

    }
}
