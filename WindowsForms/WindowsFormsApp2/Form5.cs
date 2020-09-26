using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form5 : Form
    {

        public event EventHandler<MsgEventArgs> MsgInfoEvent;//类中声明事件；发布事件；提供外部订阅+=和注销-=
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //触发事件，外部订阅事件的函数将被执行
            EventHandler<MsgEventArgs> msgInfo = MsgInfoEvent;
            if (msgInfo != null)
            {
                msgInfo(this, new MsgEventArgs(this.textBox1.Text));
            }
        }
        public void SetText(string msg)
        {
            System.Threading.Thread.Sleep(3000);
            this.textBox1.Text = msg;
        }
    }

}
