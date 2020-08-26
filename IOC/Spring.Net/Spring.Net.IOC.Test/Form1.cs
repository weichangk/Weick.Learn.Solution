using Spring.Net.IOC.Factory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spring.Net.IOC.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //通过封装的ioc容器SpringNetIocHelper获取对象测试
        private void button1_Click(object sender, EventArgs e)
        {
            IUserInfoService UserInfoService = SpringNetIocHelper.GetService<IUserInfoService>("UserInfoService");
            MessageBox.Show(UserInfoService.ShowMsg());
        }

        //通过封装的ioc容器SpringNetIocHelper获取带属性注入的对象测试
        private void button2_Click(object sender, EventArgs e)
        {
            IUserInfoService UserInfoService = SpringNetIocHelper.GetService<IUserInfoService>("UserInfoService");
            MessageBox.Show(UserInfoService.ShowMsg1());
        }

        //通过封装的ioc容器SpringNetIocHelper获取构造函数注入属性的对象测试
        private void button3_Click(object sender, EventArgs e)
        {
            ICtorDIService CtorDIService = SpringNetIocHelper.GetService<ICtorDIService>("CtorDIService");
            MessageBox.Show(CtorDIService.ShowMsg());
        }
    }
}
