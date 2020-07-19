using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisBackServiceConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ServiceStackProcessor.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.Read();
            }
        }
    }
}
