using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RedisConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {

            try
            {
                {
                    //OversellTest.Show();
                }
                {
                    //SellAsyncTest.Show();
                }

                {
                    //Console.WriteLine("****************ServiceStackTest***************");
                    //ServiceStackTest.Show();
                }
                {
                    Console.WriteLine("****************StackExchangeTest***************");
                    StackExchangeTest.Show();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
