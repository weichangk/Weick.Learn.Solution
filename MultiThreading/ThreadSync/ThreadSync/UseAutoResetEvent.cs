﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSync
{
	public class UseAutoResetEvent
    {
		public static void Show()
		{
			var t = new Thread(() => Process(10));
			t.Start();

			Console.WriteLine("Waiting for another thread to complete work");
			_workerEvent.WaitOne();
			Console.WriteLine("First operation is completed!");
			Console.WriteLine("Performing an operation on a main thread");
			Thread.Sleep(TimeSpan.FromSeconds(5));
			_mainEvent.Set();
			Console.WriteLine("Now running the second operation on a second thread");
			_workerEvent.WaitOne();
			Console.WriteLine("Second operation is completed!");
		}

		private static AutoResetEvent _workerEvent = new AutoResetEvent(false);
		private static AutoResetEvent _mainEvent = new AutoResetEvent(false);

		static void Process(int seconds)
		{
			Console.WriteLine("Starting a long running work...");
			Thread.Sleep(TimeSpan.FromSeconds(seconds));
			Console.WriteLine("Work is done!");
			_workerEvent.Set();
			Console.WriteLine("Waiting for a main thread to complete its work");
			_mainEvent.WaitOne();
			Console.WriteLine("Starting second operation...");
			Thread.Sleep(TimeSpan.FromSeconds(seconds));
			Console.WriteLine("Work is done!");
			_workerEvent.Set();
		}
	}
}
