using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadCsharp5._0
{
    class Program
    {
        static void Main(string[] args)
        {
			try
			{
				//UseAwaitGetAsyncResult.Show();
				UseAwaitOnLambda.Show();

				Console.ReadKey();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
        }
    }
}
