using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace UnityAop
{
    public class ExceptionLoggingBehavior : IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            IMethodReturn result = getNext().Invoke(input, getNext);
            Console.WriteLine("ExceptionLoggingBehavior");
            return result;
        }

        public bool WillExecute
        {
            get { return true ; }
        }
    }
}
