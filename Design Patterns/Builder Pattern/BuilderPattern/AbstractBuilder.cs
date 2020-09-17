using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    //构建者的抽象基类（有时会使用接口代替）。其定义了构建产品的抽象步骤，其实体类需要实现这些步骤。其会包含一个用来返回最终产品的方法，如：public abstract Car Car();
    public abstract class AbstractBuilder
    {

        public abstract void Engine();

        public abstract void Wheels();

        public abstract void Light();

        public abstract Car Car();
    }
}
