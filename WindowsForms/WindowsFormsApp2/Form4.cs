using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    //窗体间的数据传递可以使用委托和事件

    public partial class Form4 : Form
    {
        //定义委托
        public Action<string> SendMsg { get; set; }

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();         
            SendMsg += form5.SetText;//绑定委托；但委托被执行时，绑定委托的函数将被执行；可同步，异步且能带回调执行委托

            form5.MsgInfoEvent += BingEvent;//订阅事件；但事件被触发时，订阅事件的函数将被调用

            //委托与事件的区别：个人乱扯
            //委托由定义者注册和注销和执行；事件由定义者触发，提供调用者注册和注销
            //委托使用Func<> 和 Action<> 可以满足丰富的委托类型，注册委托的函数需要满足委托函数签名，可实现同步，异步且能带回调执行委托
            //事件直接用EventArgs，或EventArgs继承自定义事件类丰富事件属性；注册事件函数需要提过(object sender, MsgEventArgs e)参数


            banding(form5, panel1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //执行委托
            //if (SendMsg != null)
            //{
            //    //执行委托，向form5传值
            //    SendMsg(this.textBox1.Text);
            //}  

            //同步执行委托；阻塞
            Debug.WriteLine("button1_Click begin");
            //SendMsg.Invoke(this.textBox1.Text);

            //异步执行委托;非阻塞
            //需要在程序入口添加 Control.CheckForIllegalCrossThreadCalls = false; //设置不捕获线程异常 
            //解决“线程间操作无效: 从不是创建控件“xxxx”的线程访问它。”
            //SendMsg.BeginInvoke(this.textBox1.Text,null,null);
            SendMsg.BeginInvoke(this.textBox1.Text, Callback, null);//异步执行委托，委托函数执行完成后再执行回调函数Callback

            Debug.WriteLine("button1_Click end");
        }

        //SendMsg回调函数
        public void Callback(IAsyncResult iar)
        {
            //获取绑定委托函数的引用
            AsyncResult ar = (AsyncResult)iar;
            Action<string> del = (Action<string>)ar.AsyncDelegate;
            del.EndInvoke(iar);//等待委托函数执行完成
            Debug.WriteLine("Callback end");
        }

        //订阅事件函数
        private void BingEvent(object sender, MsgEventArgs e)
        {
            this.textBox1.Text = e.Msg;
        }

        private void banding(Form form, Panel panel)
        {
            panel.Controls.Clear();
            form.FormBorderStyle = FormBorderStyle.None;
            form.StartPosition = FormStartPosition.Manual;
            //form.Size = page.Size;
            form.Dock = DockStyle.Fill;
            form.TopLevel = false;
            panel.Controls.Add(form);
            form.Show();
        }


    }
}
