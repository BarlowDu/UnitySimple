using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityAop
{
    public class CachingBehavior:IInterceptionBehavior
    {
        
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Console.WriteLine("CachingBehavior");
            IMethodReturn result = getNext().Invoke(input, getNext);
            return result;
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }
}
