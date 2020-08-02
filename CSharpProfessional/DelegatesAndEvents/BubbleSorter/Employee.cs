using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSorter
{
    class Employee
    {
        public Employee(string name, decimal salary)
        {
            this.Name = name;
            this.Salary = salary;
        }

        public string Name { get; private set; }
        public decimal Salary { get; private set; }

        public override string ToString()
        {
            return string.Format("{0}, {1:C}", Name, Salary);
        }

        public static bool CompareSalary(Employee e1, Employee e2)//定义Employee类型对比方法
        {
            return e1.Salary < e2.Salary;
        }
    }
}
