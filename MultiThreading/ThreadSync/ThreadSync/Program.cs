using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSync
{
    class Program
    {
        static void Main(string[] args)
        {
			try
			{
				//UseInterlocked.Show();
				UseMutex.Show();
				Console.ReadLine();
			}
			catch (Exception ex)
			{

				Console.WriteLine(ex.Message);
			}

        }
    }
}
