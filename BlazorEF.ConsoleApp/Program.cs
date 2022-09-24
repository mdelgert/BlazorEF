using BlazorEF.ConsoleApp;
using Microsoft.Extensions.DependencyInjection;

var services = Startup.ConfigureServices();
var serviceProvider = services.BuildServiceProvider();

serviceProvider.GetService<EntryPoint>().Run(args);
