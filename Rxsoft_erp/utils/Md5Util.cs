using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Rxsoft_erp.utils
{
    class Md5Util
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="input">需要加密的参数</param>
        /// <returns>返回MD5+BASE64双重计算的值</returns>
        public static string GetMd5Hash(String input)
        {
            //获取md5对象
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            //字符串转换成hashcode值
            byte[] b = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            //计算base64值
            return Convert.ToBase64String(b);
        }
    }
}
