using AspectCore.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace EasyTool.AspectCoreExtension
{
    public static class ServiceProxy
    {
        private static IServiceProvider _serviceProvider = null!;

        public static void UseProxyServiceProvider(this IServiceCollection services)
        {
            _serviceProvider = services.BuildDynamicProxyProvider();
        }

        public static T GetService<T>() where T : class
        {
            if (_serviceProvider == null)
            {
                throw new NullReferenceException(nameof(IServiceProvider));
            }

            return _serviceProvider.GetRequiredService<T>();
        }
    }
}
