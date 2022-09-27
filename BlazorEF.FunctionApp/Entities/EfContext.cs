using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEF.FunctionApp.Entities;

public class EfContext : DbContext
{
    public DbSet<Note> Notes { get; set; }

    public DbSet<WeatherForecast> WeatherForecasts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=BlazorEfFunction;Integrated Security=False;Persist Security Info=False;User ID=sa;Password=Password2022;");
    }
}