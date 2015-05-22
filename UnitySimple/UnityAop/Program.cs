using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace UnityAop
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //var s = Assembly.LoadFile(@"C:\Users\Administrator\Desktop\za\ExpressionTree\UnityAop\bin\Debug\Microsoft.Practices.Unity.Interception.Configuration.dll");
                //var sy=s.GetType("Microsoft.Practices.Unity.InterceptionExtension.Configuration.InterceptionConfigurationExtension");
                //string typs = "Microsoft.Practices.Unity.InterceptionExtension.Configuration.InterceptionConfigurationExtension,Microsoft.Practices.Unity.Interception.Configuration";
                //Type t = Type.GetType(typs);
                //object o = Activator.CreateInstance(t);
                ITalk talk = ServiceLocator.Instance.GetService<ITalk>();
                talk.Speak("Hello");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.ReadKey();
        }
    }
}
