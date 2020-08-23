using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadBased
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //ThreadCreate.Show();
                //ThreadSleep.Show();
                //ThreadJoin.Show();
                //ThreadAbort.Show();
                //ThreadState.Show();
                //ThreadPriority.Show();
                //ThreadBackground.Show();
                //ThreadParam.Show();
                //ThreadLock.Show();
                //ThreadMonitor.MonitorlockShow();
                ThreadException.BadFaultyShow();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
