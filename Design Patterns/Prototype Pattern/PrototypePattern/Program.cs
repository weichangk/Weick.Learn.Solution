using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //原型模式；浅克隆，深克隆
            Console.WriteLine("*****************浅克隆： MemberwiseClone创建当前object的浅表副本*****************");
            {
                //拷贝对象实例
                StudentPrototype student1 = StudentPrototype.CreateInstance();
                StudentPrototype student2 = StudentPrototype.CreateInstance();

                student1.Id = 387;
                student1.Name = "天道无情";
                //修改拷贝对象实例值类型不会相互影响，不同的结果。
                Console.WriteLine("Id {0} Name {1}", student1.Id, student1.Name);
                Console.WriteLine("Id {0} Name {1}", student2.Id, student2.Name);

                //修改拷贝对象实例引用类型中的值类型会相互影响，因为拷贝的地址是相同的，通过相同的地址去修改同一块内存内容。相同的结果。
                student1.Class.Num = 2;
                student1.Class.Remark = "特训班";
                Console.WriteLine("Class.Num {0} Class.Remark {1}", student1.Class.Num, student1.Class.Remark);
                Console.WriteLine("Class.Num {0} Class.Remark {1}", student2.Class.Num, student2.Class.Remark);
            }

            Console.WriteLine("****************通过序列化反序列话实现对象深克隆******************");
            {
                StudentPrototype student1 = StudentPrototype.CreateInstanceSerialize();
                StudentPrototype student2 = StudentPrototype.CreateInstanceSerialize();

                student1.Id = 387;
                student1.Name = "天道无情";
                Console.WriteLine("Id {0} Name {1}", student1.Id, student1.Name);
                Console.WriteLine("Id {0} Name {1}", student2.Id, student2.Name);

                //两个互不相关的对象
                student1.Class.Num = 3;
                student1.Class.Remark = "特训班3";
                Console.WriteLine("Class.Num {0} Class.Remark {1}", student1.Class.Num, student1.Class.Remark);
                Console.WriteLine("Class.Num {0} Class.Remark {1}", student2.Class.Num, student2.Class.Remark);
            }
            Console.ReadLine();
        }
    }
}
