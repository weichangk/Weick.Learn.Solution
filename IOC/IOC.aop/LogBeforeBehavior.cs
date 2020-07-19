using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace IOC.aop
{
    public class LogBeforeBehavior : IInterceptionBehavior
    {
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
            return getNext().Invoke(input, getNext);
        }
    }
}
