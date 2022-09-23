using BlazorEF.Shared;
using BlazorEF.Shared.Services;
using Microsoft.EntityFrameworkCore;

namespace BlazorEF.Tests;

public class Startup
{
    public static void ConfigureServices(IServiceCollection services, HostBuilderContext hostBuilderContext)
    {
        //var dataContext = new DataContext();
        //services.AddSingleton(_ => dataContext);

        services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(
                "Data Source=localhost;Initial Catalog=BlazorEF;Integrated Security=False;Persist Security Info=False;User ID=sa;Password=Password2022;"));
        
        services.AddSingleton<INoteService, NoteService>();
        
        services.AddLogging(loggerBuilder =>
        {
            loggerBuilder.ClearProviders();
            loggerBuilder.AddConsole();
            loggerBuilder.AddFile("Serilog\\debug.log");
        });
    }
}