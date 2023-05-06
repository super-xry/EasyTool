using AspectCore.Configuration;
using AspectCore.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace EasyTool.AspectCoreExtension.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void UseProxyServiceProvider(this IServiceCollection services)
        {
            var proxyServiceProvider = services.BuildDynamicProxyProvider();
            services.AddSingleton<IServiceProvider>(proxyServiceProvider);
        }

        public static void UseInterceptor(this IServiceCollection services, Type attributeType)
        {
            services.ConfigureDynamicProxy(config => config.Interceptors.AddTyped(attributeType));
        }
    }
}
