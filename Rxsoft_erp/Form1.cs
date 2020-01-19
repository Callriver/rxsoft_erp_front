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
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string parameters = "product_id=1";
            string result = "";
            result = HttpUtil.HttpApi("http://localhost:8080/product/product-find", parameters, "POST");
            Console.WriteLine(result);
        }
    }
}
