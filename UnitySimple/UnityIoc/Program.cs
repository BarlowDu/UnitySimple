using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace UnityIoc
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            section.Configure(container);
            IDBOperator sqlserver1 = container.Resolve<IDBOperator>("sqlserver");
            IDBOperator sqlserver2 = container.Resolve<IDBOperator>("sqlserver");
            Console.WriteLine(sqlserver1.GetHashCode());
            Console.WriteLine(sqlserver2.GetHashCode());

            IDBOperator oracle1 = container.Resolve<IDBOperator>("oracle");
            IDBOperator oracle2 = container.Resolve<IDBOperator>("oracle");
            Console.WriteLine(oracle1.GetHashCode());
            Console.WriteLine(oracle2.GetHashCode());
            Console.ReadKey();
        }
    }
}
