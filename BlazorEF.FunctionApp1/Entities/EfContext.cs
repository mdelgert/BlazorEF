using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BlazorEF.FunctionApp1.Entities;

public class EfContext : DbContext
{
    public DbSet<Note> Notes { get; set; }

    public DbSet<WeatherForecast> WeatherForecasts { get; set; }

    //private readonly IConfiguration _configuration;

    //public EfContext(IConfiguration configuration)
    //{
    //    _configuration = configuration;
    //}

    public EfContext(DbContextOptions<EfContext> options) 
        : base(options)
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Does not work right now
        //var settings = _configuration.GetRequiredSection("Settings").Get<Settings>();
        optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=BlazorEfFunctionApp1;Integrated Security=False;Persist Security Info=False;User ID=sa;Password=Password2022;");
    }
}
