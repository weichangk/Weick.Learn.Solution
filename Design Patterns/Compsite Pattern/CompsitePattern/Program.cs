using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompsitePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //递归获取文件夹个数
                //var list = Recursion.GetDirectoryList(@"E:\practice\Weick.Learn.Solution");
                //Console.WriteLine(list.Count());


                //利用组合模式计算公司员工提成
                double total = 1000000;
                Domain domain = BuildTree();

                domain.Commission(total);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }


        //建立组合模式树形结构对象
        private static Domain BuildTree()
        {

            Domain domain = new Domain()
            {
                Name = "能有的提成收入",
                Percent = 10
            };

            #region
            Domain domain1 = new Domain()
            {
                Name = "CEO",
                Percent = 30
            };
            Domain domain2 = new Domain()
            {
                Name = "各部门共有",
                Percent = 70
            };

            Domain domain21 = new Domain()
            {
                Name = "实施",
                Percent = 20
            };
            Domain domain22 = new Domain()
            {
                Name = "测试",
                Percent = 10
            };
            Domain domain23 = new Domain()
            {
                Name = "销售",
                Percent = 30
            };
            Domain domain24 = new Domain()
            {
                Name = "开发",
                Percent = 40
            };
            Domain domain241 = new Domain()
            {
                Name = "经理",
                Percent = 20
            };
            Domain domain242 = new Domain()
            {
                Name = "主管",
                Percent = 15
            };
            Domain domain243 = new Domain()
            {
                Name = "开发团队",
                Percent = 65
            };
            Domain domain2431 = new Domain()
            {
                Name = "项目组1",
                Percent = 50
            };
            Domain domain2432 = new Domain()
            {
                Name = "项目组2",
                Percent = 50
            };
            Domain domain24321 = new Domain()
            {
                Name = "项目经理",
                Percent = 20
            };
            Domain domain24322 = new Domain()
            {
                Name = "开发人员",
                Percent = 80
            };
            Domain domain243221 = new Domain()
            {
                Name = "高级开发人员",
                Percent = 40
            };
            Domain domain243222 = new Domain()
            {
                Name = "中级开发人员",
                Percent = 30
            };
            Domain domain243223 = new Domain()
            {
                Name = "初级开发人员",
                Percent = 20
            };
            Domain domain243224 = new Domain()
            {
                Name = "实习生",
                Percent = 10
            };
            Domain domain2432241 = new Domain()
            {
                Name = "实习生1",
                Percent = 25
            };
            Domain domain2432242 = new Domain()
            {
                Name = "实习生2",
                Percent = 25
            };
            Domain domain2432243 = new Domain()
            {
                Name = "实习生3",
                Percent = 25
            };
            Domain domain2432244 = new Domain()
            {
                Name = "实习生4",
                Percent = 25
            };
            domain243224.AddChild(domain2432241);
            domain243224.AddChild(domain2432242);
            domain243224.AddChild(domain2432243);
            domain243224.AddChild(domain2432244);

            domain24322.AddChild(domain243221);
            domain24322.AddChild(domain243222);
            domain24322.AddChild(domain243223);
            domain24322.AddChild(domain243224);

            domain2432.AddChild(domain24321);
            domain2432.AddChild(domain24322);

            domain243.AddChild(domain2431);
            domain243.AddChild(domain2432);

            domain24.AddChild(domain241);
            domain24.AddChild(domain242);
            domain24.AddChild(domain243);

            domain2.AddChild(domain21);
            domain2.AddChild(domain22);
            domain2.AddChild(domain23);
            domain2.AddChild(domain24);

            domain.AddChild(domain1);
            domain.AddChild(domain2);
            #endregion

            return domain;
        }
    }
}
