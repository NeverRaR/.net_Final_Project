using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SyaBackend.Utils
{
    public class HashHelper
    {
        private static char[] hexDigits = {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd',
            'e', 'f' };

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
                    sb.Append(retVal[i].ToString("x2"));
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
                    sb.Append(retVal[i].ToString("x2"));
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
