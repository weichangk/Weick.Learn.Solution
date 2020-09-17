using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class ComputerBuilder
    {
        private  String cpu;//必须
        private  String ram;//必须
        private  int usbCount;//可选
        private  String keyboard;//可选
        private  String display;//可选

        private ComputerBuilder(Builder builder)
        {
            this.cpu = builder.cpu;
            this.ram = builder.ram;
            this.usbCount = builder.usbCount;
            this.keyboard = builder.keyboard;
            this.display = builder.display;
        }

        public override string ToString()
        {
            return $"this ComputerBuilder cpu:{this.cpu} ram:{this.ram} usbCount:{this.usbCount} keyboard:{this.keyboard} display:{this.display}";
        }


        //在ComputerBuilder中创建一个静态内部类Builder，然后将ComputerBuilder中的参数都复制到Builder类中。
        //在ComputerBuilder中创建一个private的构造函数，参数为Builder类型
        //在Builder中创建一个public的构造函数，参数为ComputerBuilder中必填的那些参数，cpu 和ram。
        //在Builder中创建设置函数，对ComputerBuilder中那些可选参数进行赋值，返回值为Builder类型的实例
        //在Builder中创建一个build()方法，在其中构建ComputerBuilder的实例并返回
        public class Builder
        {
            private String _cpu;//必须
            private String _ram;//必须
            private int _usbCount;//可选
            private String _keyboard;//可选
            private String _display;//可选
            public String cpu 
            {
                get 
                { 
                    return _cpu;
                }
            }
            public String ram 
            { 
                get { return _ram; } 
            }
            public int usbCount
            {
                get
                {
                    return _usbCount;
                }
            }
            public String keyboard
            {
                get
                {
                    return _keyboard;
                }
            }
            public String display
            {
                get
                {
                    return _display;
                }
            }


            public Builder(String cup, String ram)
            {
                this._cpu = cup;
                this._ram = ram;
            }

            public Builder setUsbCount(int usbCount)
            {
                this._usbCount = usbCount;
                return this;
            }
            public Builder setKeyboard(String keyboard)
            {
                this._keyboard = keyboard;
                return this;
            }
            public Builder setDisplay(String display)
            {
                this._display = display;
                return this;
            }
            public ComputerBuilder build()
            {
                return new ComputerBuilder(this);
            }
        }
    }
}
