//using Microsoft.AspNet.SignalR.Client;
//using System.Threading;

//namespace Learun.Util
//{
//    /// <summary>
//    /// 发送消息给SignalR集结器
//    /// </summary>
//    public static class SendHubs
//    {
//        /// <summary>
//        /// 调用hub方法
//        /// </summary>
//        /// <param name="methodName"></param>
//        public static void callMethod(string methodName, params object[] args)
//        {
//            var hubConnection = new HubConnection(Config.GetValue("IMUrl"));
//            IHubProxy ChatsHub = hubConnection.CreateHubProxy("ChatsHub");
//            bool done = false;
//            hubConnection.Start().ContinueWith(task =>
//            {
//                //连接成功调用服务端方法
//                if (!task.IsFaulted)
//                {
//                    ChatsHub.Invoke(methodName, args);
//                    done = true;
//                }
//                else {
//                    done = true;
//                }
//            });
//            while (!done)
//            {
//                Thread.Sleep(100);
//            }
//            //结束连接
//            hubConnection.Stop();
//        }
//    }
//}
