using DevExpress.XtraEditors;
using Rxsoft_erp.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rxsoft_erp
{
    public partial class loginForm : DevExpress.XtraEditors.XtraForm
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            login();
        }
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private void login() {
            string userid = textEdit1.Text;
            string password = textEdit2.Text;
            string parameters = "userid=" + userid + "&password=" + Md5Util.GetMd5Hash(password);
            Console.WriteLine(parameters);
            string userLoginInfo = HttpUtil.HttpApi("http://localhost:8080/user/login", parameters, "POST");
            XtraMessageBox.Show(userLoginInfo, "userLoginInfo");
        }

        private void textEdit2_KeyPress(object sender, KeyPressEventArgs e)
        {
            login();
        }
    }
}
