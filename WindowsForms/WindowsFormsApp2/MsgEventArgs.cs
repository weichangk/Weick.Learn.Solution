using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class MsgEventArgs : EventArgs//自定义事件类；无参数时可以直接用EventArgs
    {
        public string Msg { get; private set; }
        public MsgEventArgs(string msg)
        {
            this.Msg = msg;
        }
    }
}
