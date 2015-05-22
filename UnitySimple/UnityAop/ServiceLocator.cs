using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity;

namespace UnityAop
{
    public sealed class ServiceLocator
    {
        private readonly IUnityContainer container;

        private static readonly ServiceLocator instance = new ServiceLocator();

        private ServiceLocator()
        {
            container = new UnityContainer();
            UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            section.Configure(container);
            //container.RegisterType<IEnumerable<int>, List<int>>();
        }

        public static ServiceLocator Instance
        {
            get { return instance; }
        }

        private IEnumerable<ParameterOverride> GetPararmeterOverrides(object overrideArguments)
        {
            List<ParameterOverride> overrides = new List<ParameterOverride>();
            Type argummentsType = overrideArguments.GetType();
            argummentsType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .ToList().ForEach(property => {
                    var propertyValue = property.GetValue(overrideArguments, null);
                    var propertyName = property.Name;
                    overrides.Add(new ParameterOverride(propertyName, propertyValue));
                });
            return overrides;
        }

        public T GetService<T>(object overrideArguments)
        {
            var overrides = GetPararmeterOverrides(overrideArguments);
            return container.Resolve<T>(overrides.ToArray());
        }
        public T GetService<T>()
        {
            return container.Resolve<T>();
        }

        public object GetService(Type serviceType, object overrideArguments)
        {
            var overrides = GetPararmeterOverrides(overrideArguments);
            return container.Resolve(serviceType, overrides.ToArray());
        }


        public object GetService(Type serviceType)
        {
            return container.Resolve(serviceType);
        }
    }
}
