using BlazorEF.Shared;
using BlazorEF.Shared.Services;

namespace BlazorEF.Tests;

public class Startup
{
    public static void ConfigureServices(IServiceCollection services, HostBuilderContext hostBuilderContext)
    {
        var dataContext = new DataContext();
        services.AddSingleton(_ => dataContext);
        services.AddSingleton<INoteService, NoteService>();
        services.AddLogging(loggerBuilder =>
        {
            loggerBuilder.ClearProviders();
            loggerBuilder.AddConsole();
            loggerBuilder.AddFile("Serilog\\debug.log");
        });
    }
}