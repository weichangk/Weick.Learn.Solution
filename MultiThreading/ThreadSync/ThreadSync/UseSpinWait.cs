using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSync
{
	public class UseSpinWait
    {
		public static void Show()
		{
			var t1 = new Thread(UserModeWait);
			var t2 = new Thread(HybridSpinWait);

			Console.WriteLine("Running user mode waiting");
			t1.Start();
			Thread.Sleep(5000);
			_isCompleted = true;
			Thread.Sleep(TimeSpan.FromSeconds(1));
			_isCompleted = false;
			Console.WriteLine("Running hybrid SpinWait construct waiting");
			t2.Start();
			Thread.Sleep(5);
			_isCompleted = true;
			Thread.Sleep(10000);
			Console.ReadLine();
		}

		static volatile bool _isCompleted = false;

		static void UserModeWait()
		{
			while (!_isCompleted)
			{
				Console.Write(".");
				Thread.Sleep(1000);
			}
			Console.WriteLine();
			Console.WriteLine("Waiting is complete");
		}

		static void HybridSpinWait()
		{
			var w = new SpinWait();
			while (!_isCompleted)
			{
				w.SpinOnce();
				Console.WriteLine(w.NextSpinWillYield);
				//Thread.Sleep(1000);
			}
			Console.WriteLine("Waiting is complete");
		}
	}
}
