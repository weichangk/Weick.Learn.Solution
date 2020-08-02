using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulticastDelegateWithIteration
{
    class Program
    {
        static void One()
        {
            Console.WriteLine("One");
            throw new Exception("Error in one");
        }

        static void Two()
        {
            Console.WriteLine("Two");
        }


        static void Main()
        {
            //Action d1 = One;
            //d1 += Two;

            //try
            //{
            //    d1();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Exception caught  " + ex.Message);
            //}



            Action d1 = One;
            d1 += Two;

            Delegate[] delegates = d1.GetInvocationList();//返回多播委托的调用方法列表数组集合；遍历调用方法；避免通过多播委托调用的其中一个方法抛出一个异常,整个迭代就会停止。
            foreach (Action d in delegates)
            {
                try
                {
                    d();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception caught  " + ex.Message);
                }
            }


            Console.ReadKey();
        }
    }
}
