using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyDown
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //获取或设置一个值，该值指示在将键事件传递到具有焦点的控件前，窗体是否将接收此键事件。
            //使用按键事件需要设置该属性
            this.KeyPreview = true;


            //另外的，与窗体的AcceptButton属性相关联的按钮，将与键盘上的Enter键对应；与窗体的CancelButton属性相关联的按钮，将与键盘上的Ecs键对应。
            this.AcceptButton = this.button1;
            this.CancelButton = this.button2;
        }


        /// <summary>
        /// 按键事件函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // 组合键
            if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Control)     //Ctrl+F1
            {
                MessageBox.Show("Ctrl+F1");
            }
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)     //Ctrl+F1
            {
                MessageBox.Show("Ctrl+C");
            }
            if ((int)e.Modifiers == ((int)Keys.Control + (int)Keys.Alt) && e.KeyCode == Keys.D0)  //Ctrl + Alt + 数字0
            {
                MessageBox.Show("按下了Control + Alt + 0");
            }



            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show(e.KeyCode.ToString());
            }
            else if (e.KeyCode == Keys.F2)
            {
                MessageBox.Show(e.KeyCode.ToString());
            }

            else if (e.KeyCode == Keys.F8)//奇怪！台式机F8按键和有道词典有热键冲突，笔记本键盘就没有。。。
            {
                MessageBox.Show(e.KeyCode.ToString());
            }

            else if (e.KeyCode == Keys.LWin)
            {
                MessageBox.Show(e.KeyCode.ToString());
            }

            //查看热键冲突被占用方法：百度下载安装WindowsHotkeyExplorer可查看系统热键快捷键和运行的软件热键快捷键
        }




        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enter");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cancel");
        }

        //每当窗体被激活时发生
        private void Form1_Activated(object sender, EventArgs e)
        {
            //Id号可任意设置，但要保证不被重复

            //注册热键Shift+S，Id号为100。HotKey.KeyModifiers.Shift也可以直接使用数字4来表示。
            HotKey.RegisterHotKey(Handle, 100, HotKey.KeyModifiers.Shift, Keys.S);
            //注册热键Ctrl+C，Id号为101。HotKey.KeyModifiers.Ctrl也可以直接使用数字2来表示。
            HotKey.RegisterHotKey(Handle, 101, HotKey.KeyModifiers.Ctrl, Keys.C);
            //注册热键Alt+D，Id号为102。HotKey.KeyModifiers.Alt也可以直接使用数字1来表示。
            HotKey.RegisterHotKey(Handle, 102, HotKey.KeyModifiers.Alt, Keys.D);
        }

        //当控件不再是窗体的活动控件时发生
        private void Form1_Leave(object sender, EventArgs e)
        {
            //注销Id号为100的热键设定
            HotKey.UnregisterHotKey(Handle, 100);
            //注销Id号为101的热键设定
            HotKey.UnregisterHotKey(Handle, 101);
            //注销Id号为102的热键设定
            HotKey.UnregisterHotKey(Handle, 102);
        }


        /// 监视Windows消息
        /// 重载WndProc方法，用于实现热键响应
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            //按快捷键 
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    switch (m.WParam.ToInt32())
                    {
                        case 100:  //按下的是Shift+S
                                   //此处填写快捷键响应代码     
                            MessageBox.Show("WndProc Shift+S");
                            break;
                        case 101:  //按下的是Ctrl+C
                                   //此处填写快捷键响应代码
                            MessageBox.Show("WndProc Ctrl+C");
                            break;
                        case 102:  //按下的是Alt+D
                                   //此处填写快捷键响应代码
                            MessageBox.Show("WndProc Alt+D");
                            break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }
    }

    /*
    在应用中，我们可能会需要实现像Ctrl+C复制、Ctrl+V粘贴这样的快捷键， 这就会造成热键冲突，下面实现怎么解决热键冲突，实现快捷键(系统热键)响应本。

    public static extern bool RegisterHotKey()这个函数用于注册热键。由于这个函数需要引用user32.dll动态链接库后才能使用，并且
    user32.dll是非托管代码，不能用命名空间的方式直接引用，所以需要用DllImport进行引入后才能使用。于是在函数前面需要加上[DllImport("user32.dll", SetLastError = true)]这行语句。
    public static extern bool UnregisterHotKey()这个函数用于注销热键，同理也需要用DllImport引用user32.dll后才能使用。
    public enum KeyModifiers { }定义了一组枚举，将辅助键的数字代码直接表示为文字，以方便使用。这样在调用时我们不必记住每一个辅助键的代码而只需直接选择其名称即可。
    */
    class HotKey
    {
        //如果函数执行成功，返回值不为0。
        //如果函数执行失败，返回值为0。要得到扩展错误信息，调用GetLastError。
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(
          IntPtr hWnd,        //要定义热键的窗口的句柄
          int id,           //定义热键ID（不能与其它ID重复）      
          KeyModifiers fsModifiers,  //标识热键是否在按Alt、Ctrl、Shift、Windows等键时才会生效
          Keys vk           //定义热键的内容
          );
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(
          IntPtr hWnd,        //要取消热键的窗口的句柄
          int id           //要取消热键的ID
          );
        //定义了辅助键的名称（将数字转变为字符以便于记忆，也可去除此枚举而直接使用数值）
        [Flags()]
        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Ctrl = 2,
            Shift = 4,
            WindowsKey = 8
        }
    }



}
