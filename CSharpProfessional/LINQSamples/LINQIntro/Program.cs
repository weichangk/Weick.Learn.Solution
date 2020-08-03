using DataLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQIntro
{
    class Program
    {
        static void Main()
        {
            // LINQQuery();
            // ExtensionMethods();
            DeferredQuery();
        }

        static void DeferredQuery()
        {
            var names = new List<string> { "Nino", "Alberto", "Juan", "Mike", "Phil" };

            var namesWithJ = from n in names
                             where n.StartsWith("J")
                             orderby n
                             select n;//延迟查询

            Console.WriteLine("First iteration");
            foreach (string name in namesWithJ)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            names.Add("John");
            names.Add("Jim");
            names.Add("Jack");
            names.Add("Denny");

            Console.WriteLine("Second iteration");
            foreach (string name in namesWithJ)//延迟查询；可以查询到最新数据； names.Add("John");等数据也将被查询到。查询语句中使用ToList()扩展方法立即执行查询并返回结果（存在内存中）；names.Add("John")等数据将不会被查询
            {
                Console.WriteLine(name);
            }

            Console.ReadKey();
        }

        static void ExtensionMethods()
        {
            var champions = new List<Racer>(Formula1.GetChampions());
            IEnumerable<Racer> brazilChampions =
                champions.Where(r => r.Country == "Brazil").
                        OrderByDescending(r => r.Wins).
                        Select(r => r);

            foreach (Racer r in brazilChampions)
            {
                Console.WriteLine("{0:A}", r);
            }
        }


        static void LINQQuery()
        {
            var query = from r in Formula1.GetChampions()
                        where r.Country == "Brazil"
                        orderby r.Wins descending
                        select r;

            foreach (var r in query)
            {
                Console.WriteLine("{0:A}", r);
            }

        }
    }
}
