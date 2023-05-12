using AspectCore.DynamicProxy;
using System.Diagnostics;

namespace EasyTool.AspectCoreExtension.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TimeMonitorAttribute : AbstractInterceptorAttribute
    {
        public override async Task Invoke(AspectContext context, AspectDelegate next)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            await next(context);
            stopWatch.Stop();

            Console.WriteLine($"Full name: {context.ProxyMethod.GetType().FullName}, cost time: {stopWatch.ElapsedMilliseconds} ms...");
        }
    }
}