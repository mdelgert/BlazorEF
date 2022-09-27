using BlazorEF.Shared;
using BlazorEF.Shared.Services;
using Microsoft.EntityFrameworkCore;

namespace BlazorEF.ConsoleApp;

public static class Startup
{
    public static IServiceCollection ConfigureServices()
    {
        var services = new ServiceCollection();

        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);

        IConfiguration configuration = builder.Build();
        
        services.AddSingleton(configuration);

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

        services.AddLogging(builder =>
        {
            builder.AddConfiguration(configuration.GetSection("Logging"));
            builder.AddConsole();
            builder.AddSerilog();
        });

        services.AddDbContext<DataContext>(options => options.UseSqlServer("Data Source=localhost;Initial Catalog=BlazorEfConsole;" +
            "Integrated Security=False;Persist Security Info=False;User ID=sa;Password=Password2022;"));
        services.AddSingleton<INoteService, NoteService>();
        services.AddSingleton<EntryPoint>();
        
        return services;
    }
}
