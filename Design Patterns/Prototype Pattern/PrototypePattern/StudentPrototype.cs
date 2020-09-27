using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    [Serializable]
    public class StudentPrototype
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Class Class { get; set; }

        private StudentPrototype()
        {
            System.Threading.Thread.Sleep(2000);
            long lResult = 0;
            for (int i = 0; i < 100000000; i++)
            {
                lResult += i;
            }
            Console.WriteLine("{0}被构造..", this.GetType().Name);
        }

        private static StudentPrototype _StudentPrototype = null;
        static StudentPrototype()
        {
            _StudentPrototype = new StudentPrototype()
            {
                Id = 337,
                Name = "歌神",
                Class = new Class()
                {
                    Num = 1,
                    Remark = "高级班"
                }
            };
        }

        //对象浅克隆
        public static StudentPrototype CreateInstance()
        {
            //MemberwiseClone创建当前object的浅表副本
            //浅克隆一个对象。对象里的值类型将被克隆一份新值，对象里的引用类型克隆的新值是相同的引用地址，两个相同的引用地址值是指向同一内存的。
            StudentPrototype studentPrototype = (StudentPrototype)_StudentPrototype.MemberwiseClone();
            //studentPrototype.Class = new Class()
            //{
            //    Num = 1,
            //    Remark = "高级班"
            //};//可以开辟内存实现深clone

            return studentPrototype;
        }


        //通过序列化反序列话实现对象深克隆
        public static StudentPrototype CreateInstanceSerialize()
        {
            return SerializeHelper.DeepClone<StudentPrototype>(_StudentPrototype);
        }
    }

    /// <summary>
    /// 班级
    /// </summary>
    [Serializable]
    public class Class
    {
        public int Num { get; set; }
        public string Remark { get; set; }
    }
}
