﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InsertSort
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private int[] G_int_value;//定义数组字段

        private Random G_Random = new Random();//创建随机数对象

        private void btn_sort_Click(object sender, EventArgs e)
        {
            if (G_int_value != null)
            {
                for (int i = 0; i < G_int_value.Length; ++i)//循环访问数组中的元素
                {
                    int temp = G_int_value[i];//定义一个int变量，并使用获得的数组元素值赋值
                    int j = i;
                    while ((j > 0) && (G_int_value[j - 1] > temp))//判断数组中的元素是否大于获得的值
                    {
                        G_int_value[j] = G_int_value[j - 1];//如果是，则将后一个元素的值提前
                        --j;
                    }
                    G_int_value[j] = temp;//最后将int变量存储的值赋值给最后一个元素
                }
                txt_str2.Clear();//清空控件内字符串
                foreach (int i in G_int_value)//遍历字符串集合
                {
                    txt_str2.Text += i.ToString() + ", ";//向控件内添加字符串
                }
            }
            else
            {
                MessageBox.Show("首先应当生成数组，然后再进行排序。", "提示！");
            }
        }

        private void btn_Generate_Click(object sender, EventArgs e)
        {
            G_int_value = new int[G_Random.Next(10, 20)];//生成随机长度数组
            for (int i = 0; i < G_int_value.Length; i++)//遍历数组
            {
                G_int_value[i] = G_Random.Next(0, 100);//为数组赋随机数值
            }
            txt_str.Clear();//清空控件内字符串
            foreach (int i in G_int_value)//遍历字符串集合
            {
                txt_str.Text += i.ToString() + ", ";//向控件内添加字符串

            }
        }
    }
}
