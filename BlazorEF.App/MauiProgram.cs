using BlazorEF.App.Data;
using BlazorEF.Shared;
using BlazorEF.Shared.Services;
using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace BlazorEF.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            //https://montemagno.com/dotnet-maui-appsettings-json-configuration/
            //https://github.com/shinyorg/configurationextensions?WT.mc_id=friends-0000-jamont

            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif
            //builder.Services.AddDbContext<DataContext>();
            //https://learn.microsoft.com/en-us/training/modules/store-local-data/2-compare-storage-options

            //var dbPath = Path.Combine(FileSystem.AppDataDirectory, "BlazorEF.db3");
            //builder.Services.AddDbContext<DataContext>(options => options.UseSqlite($"Filename={dbPath}"));

            builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer("Data Source=localhost;Initial Catalog=BlazorEfApp;" +
            "Integrated Security=False;Persist Security Info=False;User ID=sa;Password=Password2022;"));

            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddTransient<INoteService, NoteService>();

            return builder.Build();
        }
    }
}