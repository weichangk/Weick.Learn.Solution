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
    public partial class Form2 : Form
    {
        //窗体组合经常会使用到，但是要避免循环引用的问题。
        //窗体对象相互引用的可以使用单例模式，用窗体类静态方法获取实例对象再去调用具体内容。在窗体间相互引用时，使用单例可以解决循环引用问题。

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
        //在Form2中添加Form3实例引用，组合
        private static readonly Form3 form3 = Form3.GetForm3();


        //Form2实例单例
        private static readonly Form2 form2 = new Form2();

        private Form2()
        {
            InitializeComponent();
        }

        //获取Form2单例实例
        public static Form2 GetForm2()
        {
            return form2;
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            banding(form3, panel1);
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


        private void button1_Click(object sender, EventArgs e)
        {
            //在Form2中通过form3引用修改Form3内容
            form3.TextBox1.Text = "123";
        }
        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }
    }
}
