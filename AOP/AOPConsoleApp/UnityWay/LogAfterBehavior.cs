using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace AOPConsoleApp.UnityWay
{
    public class LogAfterBehavior : IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            IMethodReturn methodReturn = getNext()(input, getNext);//执行后面的全部动作

            Console.WriteLine("LogAfterBehavior");
            //Console.WriteLine(input.MethodBase.Name);
            //foreach (var item in input.Inputs)
            //{
            //    Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(item));
            //}
            //Console.WriteLine("LogAfterBehavior" + methodReturn.ReturnValue);
            return methodReturn;
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }
}
