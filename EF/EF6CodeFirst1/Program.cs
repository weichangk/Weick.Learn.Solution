using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6CodeFirst1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Data.Entity.Database.SetInitializer(new EF6CodeFirst1.Models.SampleData());

            //EFTest.Show

            EFTest1.Show();

            Console.ReadLine();
        }
    }
}
