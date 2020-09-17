using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    //Director: 决定如何构建最终产品的算法，其会包含一个负责组装的方法如：public Car GetCar()获得最终的产品。
    public class Director
    {
        private AbstractBuilder _AbstractBuilder = null;
        public Director(AbstractBuilder builder)
        {
            this._AbstractBuilder = builder;
        }

        public Car GetCar()
        {
            //对象建造逻辑是固定的
            this._AbstractBuilder.Engine();
            this._AbstractBuilder.Wheels();
            this._AbstractBuilder.Light();

            return this._AbstractBuilder.Car();
        }
    }
}
