using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompsitePattern
{
    /// <summary>
    /// 机构/个人
    /// </summary>
    public class Domain : AbstractDomain
    {
        //组合模式（Composite Pattern） 也称为 整体-部分（Part-Whole）模式，它的宗旨是通过将单个对象（叶子节点）和组合对象（树枝节点）用相同的接口进行表示，使得客户对单个对象和组合对象的使用具有一致性。
        //组合模式 一般用来描述 整体 与 部分 的关系，它将对象组织到树形结构中，最顶层的节点称为 根节点，根节点下面可以包含 树枝节点 和 叶子节点，树枝节点下面又可以包含 树枝节点 和 叶子节点。
        //树枝内部组合该接口，并且含有内部属性 List，里面放相同对象组成树形结构。
        private List<Domain> DomainChildList = new List<Domain>();


        //组合模式 核心：借助同一接口，使叶子节点和树枝节点的操作具备一致性。
        public void AddChild(Domain domainChild)
        {
            this.DomainChildList.Add(domainChild);
        }


        //递归组合模式树形结构
        public override void Commission(double total)
        {
            double result = total * this.Percent / 100;
            Console.WriteLine("this {0} 提成 {1}", this.Name, result);

            foreach (var domainChild in DomainChildList)
            {
                domainChild.Commission(result);
            }

        }

    }
}
