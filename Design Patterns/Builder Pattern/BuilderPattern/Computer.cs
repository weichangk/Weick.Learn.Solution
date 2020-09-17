using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class Computer
    {
        private String cpu;//必须
        private String ram;//必须
        private int usbCount;//可选
        private String keyboard;//可选
        private String display;//可选

        //当一个类的构造函数参数超过4个，而且这些参数有些是可选的时

        #region 折叠构造函数模式:构造函数重载，构造函数调用构造函数
        public Computer(String cpu, String ram) : this(cpu, ram, 4)
        {
            this.cpu = cpu;
            this.ram = ram;
        }
        public Computer(String cpu, String ram, int usbCount) : this(cpu, ram, usbCount, "罗技键盘")
        {
            this.cpu = cpu;
            this.ram = ram;
            this.usbCount = usbCount;
        }
        public Computer(String cpu, String ram, int usbCount, String keyboard) : this(cpu, ram, usbCount, keyboard, "三星显示器")
        {
            this.cpu = cpu;
            this.ram = ram;
            this.usbCount = usbCount;
            this.keyboard = keyboard;
        }

        public Computer(String cpu, String ram, int usbCount, String keyboard, String display)
        {
            this.cpu = cpu;
            this.ram = ram;
            this.usbCount = usbCount;
            this.keyboard = keyboard;
            this.display = display;
        }
        #endregion

        #region 构造函数可选参数
        //public Computer(String cpu, String ram, int usbCount = 4, String keyboard = "罗技键盘", String display = "三星显示器")
        //{
        //    this.cpu = cpu;
        //    this.ram = ram;
        //    this.usbCount = usbCount;
        //    this.keyboard = keyboard;
        //    this.display = display;
        //}
        #endregion

        public override string ToString()
        {
            return $"this Computer cpu:{this.cpu} ram:{this.ram} usbCount:{this.usbCount} keyboard:{this.keyboard} display:{this.display}";
        }

    }
}
