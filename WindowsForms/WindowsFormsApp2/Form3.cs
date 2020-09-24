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
    public partial class Form3 : Form
    {
        public TextBox TextBox1
        {
            get
            {
                return this.textBox1;
            }
            set
            {
                this.textBox1 = value;
            }

        }

        //Form3实例单例
        private static readonly Form3 form3 = new Form3();
        private Form3()
        {
            InitializeComponent();
        }

        public static Form3 GetForm3()
        {
            return form3;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //因为Form2已经组合了Form3，想要通过Form3中修改Form2内容，不应该在Form3中组合Form2，会导致循环引用
            //应该在Form3中直接调用Form2获取对象引用的静态方法去调用具体内容
            //在窗体间相互引用时，使用单例可以解决循环引用问题
            Form2.GetForm2().TextBox1.Text = "456";
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
