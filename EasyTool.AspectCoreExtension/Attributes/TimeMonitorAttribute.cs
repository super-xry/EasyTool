using System.Diagnostics;
using AspectCore.DynamicProxy;

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
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Method: {context.ProxyMethod.Name}, cast: {stopWatch.ElapsedMilliseconds} ms...");
            Console.ForegroundColor = color;
        }
    }
}