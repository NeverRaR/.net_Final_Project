using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SyaBackend.Utils
{
    public class HashHelper
    {

        [DllImport(@"D:\VSProject\SyaBackend\x64\Debug\SYAWin32DLL.dll")]
        private static extern char Encode(int code);

        public static String ComputeSHA256Hash(String rawData)
        {
            byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(rawData);
            try
            {
                SHA256 sha256 = new SHA256CryptoServiceProvider();
                byte[] retVal = sha256.ComputeHash(bytValue);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    byte byte0 = retVal[i];
                    char ch1 = Encode((byte0 >> 4) & 0xf);
                    char ch2 = Encode(byte0 & 0xf);
                    sb.Append(ch1);
                    sb.Append(ch2);
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("GetSHA256HashFromString() fail,error:" + ex.Message);
            }
        }

        public static String ComputeMD5Hash(String rawData)
        {
            byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(rawData);
            try
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(bytValue);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    byte byte0 = retVal[i];
                    char ch1 = Encode((byte0 >> 4) & 0xf);
                    char ch2 = Encode(byte0  & 0xf);
                    sb.Append(ch1);
                    sb.Append(ch2);

                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("GetSHA256HashFromString() fail,error:" + ex.Message);
            }
        }
    }
}
