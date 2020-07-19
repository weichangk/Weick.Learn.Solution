using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace AOPConsoleApp.UnityWay
{
    public class LogBeforeBehavior : IInterceptionBehavior
    {
        //public bool WillExecute => throw new NotImplementedException();
        public bool WillExecute
        {
            get { return true; }
        }
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Console.WriteLine("LogBeforeBehavior");
            //Console.WriteLine(input.MethodBase.Name);
            //foreach (var item in input.Inputs)
            //{
            //    Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(item));
            //}
            return getNext().Invoke(input, getNext);
        }
    }
}
