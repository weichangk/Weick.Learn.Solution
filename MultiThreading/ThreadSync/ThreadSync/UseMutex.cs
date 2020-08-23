using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSync
{
    public class UseMutex
    {
		public static void Show()
		{
			const string MutexName = "CSharpThreadingCookbook";

			using (var m = new Mutex(false, MutexName))
			{
				if (!m.WaitOne(TimeSpan.FromSeconds(5), false))
				{
					Console.WriteLine("Second instance is running!");
				}
				else
				{
					Console.WriteLine("Running!");
					Console.ReadLine();
					m.ReleaseMutex();
				}
			}
		}
	}
}
