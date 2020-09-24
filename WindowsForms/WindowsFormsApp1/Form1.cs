using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //注意：该实验是在.net framework 4.0中测试的
        //建议：在winform中使用Control.CheckForIllegalCrossThreadCalls = false;和task实现异步
        //总结：Control.CheckForIllegalCrossThreadCalls = false;是能实现异步访问ui线程并能在异步执行过程中拖动窗体的关键



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //初始化进度条
            progressBar1.Maximum = 100;
            progressBar1.Minimum = 0;
            progressBar1.Value = 0;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            //开启任务，异步执行，线程池线程，后台线程
            //窗体还可以拖动，不被阻塞
            func3();
            func1();
            func2();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //无线程，阻塞UI线程
            func4();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //System.InvalidOperationException:“线程间操作无效: 从不是创建控件“progressBar1”的线程访问它。”
            //可以在程序入口添加 Control.CheckForIllegalCrossThreadCalls = false; //设置不捕获线程异常 解决该问题
            func5();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //使用this.BeginInvoke(new EventHandler(delegate{   }));执行异步访问ui线程。使用this.BeginInvoke(mi执行异步过程中不能拖动窗体
            func6();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //使用System.Windows.Forms.Timer();;实现异步访问ui
            func7();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //使用Control.CheckForIllegalCrossThreadCalls = false;  再开启任务访问ui控件实现异步，异步执行过程中拖动窗体
            func5();
            func2();
        }
   
        private void button7_Click(object sender, EventArgs e)
        {
            // this.BeginInvoke(mi)在创建控件的基础句柄所在线程上异步执行指定委托func6();和其他任务func2();实现异步。使用this.BeginInvoke(mi执行异步过程中不能拖动窗体
            func6();
            func2();
        }






        private void func1()
        {
            Task.Factory.StartNew(() => {
                for (int i = 0; i < 5; i++)
                {
                    Debug.WriteLine(i);
                    System.Threading.Thread.Sleep(1000);
                }
            });
        }

        private void func2()
        {
            //开启任务并执行
            Task.Factory.StartNew(() => {
                for (int i = 100; i < 105; i++)
                {
                    Debug.WriteLine(i);
                    System.Threading.Thread.Sleep(500);
                }
            });
        }
        private void func3()
        {
            //开启任务并执行
            Task.Factory.StartNew(() => {
                System.Threading.Thread.Sleep(5000);
                Debug.WriteLine(5000);
            });

        }

        //阻塞UI线程
        private void func4()
        {
            int i = 0;
            while (++i < 100)
            {
                System.Threading.Thread.Sleep(30);//模拟耗时操作
                progressBar1.Value = i;
            }
        }

        #region 异步访问UI控件
        //使用线程访问ui控件时报错：System.InvalidOperationException:“线程间操作无效: 从不是创建控件“progressBar1”的线程访问它。”
        //可以在程序入口添加 Control.CheckForIllegalCrossThreadCalls = false; //设置不捕获线程异常 解决该问题
        private void func5()
        {
            progressBar1.Value = 0;
            //开启任务
            Task task = new Task(() =>
            {
                int i = 0;
                while (++i < 100)
                {
                    System.Threading.Thread.Sleep(30);//模拟耗时操作
                    progressBar1.Value = i;
                }
            });
            task.Start();//执行任务
        }

        //使用MethodInvoker mi; this.BeginInvoke(mi)在创建控件的基础句柄所在线程上异步执行指定委托。
        //解决：System.InvalidOperationException:“线程间操作无效: 从不是创建控件“progressBar1”的线程访问它。”问题
        private void func6()
        {
            progressBar1.Value = 0;

            #region 使用BeginInvoke虽然解决了跨UI线程访问控件的问题，实现异步，但是涉及到控件访问的过程中，不能拖动窗体。使用 Task.Factory.StartNew()包多一层还是不能拖动窗体。。。。。
            //Task.Factory.StartNew(() =>
            //{
            //    //MethodInvoker mi = new MethodInvoker(() =>
            //    //{
            //    //    int i = 0;
            //    //    while (++i < 100)
            //    //    {
            //    //        System.Threading.Thread.Sleep(30);//模拟耗时操作
            //    //        progressBar1.Value = i;
            //    //    }
            //    //});
            //    //this.BeginInvoke(mi);

            //    this.BeginInvoke(new EventHandler(delegate
            //    {
            //        int i = 0;
            //        while (++i < 100)
            //        {
            //            System.Threading.Thread.Sleep(30);//模拟耗时操作
            //            progressBar1.Value = i;
            //        }
            //    }));
            //});
            #endregion

            this.BeginInvoke(new EventHandler(delegate
            {
                int i = 0;
                while (++i < 100)
                {
                    System.Threading.Thread.Sleep(50);//模拟耗时操作
                    progressBar1.Value = i;
                }
            }));
        }
        #endregion

        #region 使用 System.Windows.Forms.Timer只执行一次实现异步
        System.Windows.Forms.Timer t;  
        private void func7()
        {
            t = new System.Windows.Forms.Timer();
            t.Tick += new EventHandler(TimerTick);
            //t.Interval = 30;//默认100
            t.Enabled = true;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            t.Stop();
            t.Dispose();
            int i = 0;
            while (++i < 100)
            {
                System.Threading.Thread.Sleep(50);//模拟耗时操作
                progressBar1.Value = i;
            }
        }
        #endregion


    }
}
