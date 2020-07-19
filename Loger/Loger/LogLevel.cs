using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loger
{
    /// <summary>
    /// 日志级别
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// 错误
        /// </summary>
        [Description("错误")]
        Error,
        /// <summary>
        /// 警告
        /// </summary>
        [Description("警告")]
        Warning,
        /// <summary>
        /// 信息
        /// </summary>
        [Description("信息")]
        Info,
        /// <summary>
        /// 调试
        /// </summary>
        [Description("调试")]
        Debug
    }
}
