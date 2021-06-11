using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SyaBackend.Services
{
    //指定下划线为json序列化格式
    public class UnderScoreCaseConverter : JsonNamingPolicy
    {

        public UnderScoreCaseConverter()
        {
           
        }



        public override string ConvertName(string name)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < name.Length; i++)
            {
                if (Char.IsUpper(name[i]) && i > 0)
                {
                    sb.Append("_");
                }
                sb.Append(Char.ToLower(name[i]));
            }
            return sb.ToString();
        }
    }
}
