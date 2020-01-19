using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace 自己的名称空间
{
    public class ApiHelper
    {
        /// <summary>
        /// api调用方法/注意一下API地址
        /// </summary>
        /// <param name="controllerName">控制器名称--自己所需调用的控制器名称</param>
        /// <param name="overb">请求方式--get-post-delete-put</param>
        /// <param name="action">方法名称--如需一个Id(方法名/ID)(方法名/?ID)根据你的API灵活运用</param>
        /// <param name="obj">方法参数--如提交操作传整个对象</param>
        /// <returns>json字符串--可以反序列化成你想要的</returns>
        public static string GetApiMethod(string controllerName, string overb, string action, object obj = null)
        {
            Task<HttpResponseMessage> task = null;
            string json = "";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:****/api/" + controllerName + "/");
            switch (overb)
            {
                case "get":
                    task = client.GetAsync(action);
                    break;
                case "post":
                    task = client.PostAsJsonAsync(action, obj);
                    break;
                case "delete":
                    task = client.DeleteAsync(action);
                    break;
                case "put":
                    task = client.PutAsJsonAsync(action, obj);
                    break;
                default:
                    break;
            }
            task.Wait();
            var response = task.Result;
            if (response.IsSuccessStatusCode)
            {
                var read = response.Content.ReadAsStringAsync();
                read.Wait();
                json = read.Result;
            }
            return json;
        }
    }
}