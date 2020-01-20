using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace Rxsoft_erp.utils
{
    class HttpUtil
    {
          /// <summary>
       /// 调用api返回json
       /// </summary>
       /// <param name="url">api地址</param>
       /// <param name="jsonstr">接收参数</param>
       /// <param name="type">类型</param>
       /// <returns></returns>
        public static string HttpApi(string url, string parameters, string type)
       {
           Encoding encoding = Encoding.ASCII;
           HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);//webrequest请求api地址
           request.Accept = "text/html,application/xhtml+xml,*/*";
           //参数类型
           request.ContentType = "application/x-www-form-urlencoded";
           //解决因为URL协议问题导致的+号消失
           byte[] buffer = encoding.GetBytes(parameters.Replace("+", "%2B"));
           //参数数据长度
           request.ContentLength = buffer.Length;
           request.Method = type.ToUpper().ToString();//get或者post
           //设置超时时间
           request.Timeout = 20000;
           HttpWebResponse response;
           string responseContent = "";
           try
           {
               //将参数写入请求地址中
               request.GetRequestStream().Write(buffer, 0, buffer.Length);

               //发送请求
               response = (HttpWebResponse)request.GetResponse();
               //读取返回数据
               StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
               responseContent = streamReader.ReadToEnd();
               streamReader.Close();
               response.Close();
               request.Abort();
           }
           catch (Exception e)
           {
               XtraMessageBox.Show(e.Message, "error");
           }
           return responseContent; 
       }
       //组装请求参数
        private static string BuildQuery(IDictionary<string, string> parameters, string encode)
       {
           StringBuilder postData = new StringBuilder();
           bool hasParam = false;
           IEnumerator<KeyValuePair<string, string>> dem = parameters.GetEnumerator();
           while (dem.MoveNext())
           {
               string name = dem.Current.Key;
               string value = dem.Current.Value;
               // 忽略参数名或参数值为空的参数
               if (!string.IsNullOrEmpty(name))
               {
                   if (hasParam)
                   {
                       postData.Append("&");
                   }
                   postData.Append(name);
                   postData.Append("=");
                   if (encode == "gb2312")
                   {
                       postData.Append(HttpUtility.UrlEncode(value, Encoding.GetEncoding("gb2312")));
                   }
                   else if (encode == "utf8")
                   {
                       postData.Append(HttpUtility.UrlEncode(value, Encoding.UTF8));
                   }
                   else
                   {
                       postData.Append(value);
                   }
                   hasParam = true;
               }
           }
           return postData.ToString();
       }
    }
}
