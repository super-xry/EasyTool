using AspectCore.Configuration;
using AspectCore.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace EasyTool.AspectCoreExtension.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void UseInterceptor(this IServiceCollection services, Type attributeType)
        {
            services.ConfigureDynamicProxy(config => config.Interceptors.AddTyped(attributeType));
        }
    }
}
