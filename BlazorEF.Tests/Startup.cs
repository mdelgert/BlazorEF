
namespace BlazorEF.Tests;

public class Startup
{
    public static void ConfigureServices(IServiceCollection services, HostBuilderContext hostBuilderContext)
    {
        services.AddLogging(loggerBuilder =>
        {
            loggerBuilder.ClearProviders();
            loggerBuilder.AddConsole();
            loggerBuilder.AddFile("Serilog\\debug.log");
        });
    }
}