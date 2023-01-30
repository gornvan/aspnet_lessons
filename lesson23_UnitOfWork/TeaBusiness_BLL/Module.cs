using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeaBusiness_BLL.Services;
using System.Linq;

namespace TeaBusiness_BLL
{
    public static class Module
    {
        public static void RegisterServices(IServiceCollection servicesContainer, IConfiguration configuration)
        {
            var interfacesToServies = FindServicesImplementations(typeof(TransientServiceBase));

            foreach (var kvp in interfacesToServies)
            {
                servicesContainer.AddTransient(kvp.Key, kvp.Value);
            }
        }

        public static Dictionary<Type, Type> FindServicesImplementations(Type serviceParentType)
        {
            var thisAssembly = serviceParentType.Assembly;

            Dictionary<Type, Type> interfacesToServies = thisAssembly.GetExportedTypes()
                .Where(t => t.IsAssignableTo(serviceParentType) && t != serviceParentType)
                .ToList()
                .ToDictionary(
                    st => // key selector
                    {
                        var interfaces = st.GetInterfaces();
                        if (interfaces == null || interfaces.Length != 1)
                        {
                            throw new SystemException($@"Could not find the interface which is implemented by {st.FullName}");
                        }
                        return interfaces[0];
                    },
                    st => st // value selector
                );

            return interfacesToServies;
        }
    }
}
