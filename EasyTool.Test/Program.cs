using EasyTool.AspectCoreExtension;
using EasyTool.AspectCoreExtension.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace EasyTool.Test
{
    public class Program
    {
        private static void Main()
        {
            var services = new ServiceCollection();
            services.AddScoped<ITest, Test>();
            services.UseProxyServiceProvider();
            var test = ServiceProxy.GetService<ITest>();
            test.Create();
        }
    }

    public interface ITest
    {
        void Create();
    }

    public class Test : ITest
    {
        [TimeMonitor]
        public void Create()
        {
            // Do something here...
        }
    }
}