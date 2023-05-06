# Description
### This is a small tool, let developer can easy use some plugins

# Example: 

## Test class
```cs
public interface ITest
{
    void Create();
}

public class Test: ITest
{   
   public void Create()
   {
     // Do something here...
   }
}
```
## Use attribute
### Add '[TimeMonitor]' into Test.Create method

```cs
var services = new ServiceCollection();
services.AddScoped<ITest, Test>();
services.UseProxyServiceProvider();
var test = ServiceProxy.GetService<ITest>();
test.Create();
```
> Method: Create, cast: {real-time} ms...

## Use interceptor
```cs
var services = new ServiceCollection();
services.AddScoped<ITest, Test>();
services.UseInterceptor(typeof(TimeMonitorAttribute));
var provider = services.BuildDynamicProxyProvider();
var test = ServiceProxy.GetService<ITest>();
test.Create();
```

> Method: Create, cast: {real-time} ms...
