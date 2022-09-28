using Microsoft.EntityFrameworkCore;

namespace BlazorEF.FunctionApp1.Entities;

public class EfContext : DbContext
{
    public DbSet<Note> Notes { get; set; }

    public DbSet<WeatherForecast> WeatherForecasts { get; set; }

    public EfContext(DbContextOptions<EfContext> options) : base(options)
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=BlazorEfFunctionApp1;Integrated Security=False;" +
    //        "Persist Security Info=False;User ID=sa;Password=Password2022;");
    //}
}
