using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loger
{
    /// <summary>
    /// 日志
    /// </summary>
    public class Log
    {
        /// <summary>
        /// 日志实体类
        /// </summary>
        private ILog logger;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="log">日志操作对象</param>
        public Log(ILog log)
        {
            this.logger = log;
        }
        /// <summary>
        /// 调试日志
        /// </summary>
        /// <param name="message">消息</param>
        public void Debug(object message)
        {
            this.logger.Debug(message);
        }
        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="message">消息</param>
        public void Error(object message)
        {
            this.logger.Error(message);
        }
        /// <summary>
        /// 信息日志
        /// </summary>
        /// <param name="message">消息</param>
        public void Info(object message)
        {
            this.logger.Info(message);
        }
        /// <summary>
        /// 警告日志
        /// </summary>
        /// <param name="message">消息</param>
        public void Warn(object message)
        {
            this.logger.Warn(message);
        }
    }
}
