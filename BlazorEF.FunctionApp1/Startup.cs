using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using BlazorEF.FunctionApp1;
using BlazorEF.FunctionApp1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

[assembly: FunctionsStartup(typeof(Startup))]

namespace BlazorEF.FunctionApp1;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        //builder.Services.AddDbContext<EfContext>(options => options.UseSqlServer("Data Source=localhost;Initial Catalog=BlazorEfFunctionApp1;Integrated Security=False;Persist Security Info=False;User ID=sa;Password=Password2022;"));
        builder.Services.AddDbContext<EfContext>();
    }
}

//https://learn.microsoft.com/en-us/azure/azure-functions/functions-dotnet-dependency-injection