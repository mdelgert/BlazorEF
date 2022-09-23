using BlazorEF.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorEF.Shared;

public class DataContext: DbContext
{
    public DbSet<NoteModel> Notes { get; set; }

    public DataContext()
    {
        //SQLitePCL.Batteries_V2.Init();
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // var dbPath = Path.Combine(FileSystem.AppDataDirectory, "BlazorEF.db3");
        
        // optionsBuilder
        //     .UseSqlite($"Filename={dbPath}");
        
        optionsBuilder
            .UseSqlServer("Data Source=localhost;Initial Catalog=BlazorEF;Integrated Security=False;Persist Security Info=False;User ID=sa;Password=Password2022;");
        
        // optionsBuilder
        //     .UseCosmos(
        //         "https://localhost:8081",
        //         "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
        //         databaseName: "BlazorEF");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<NoteModel>().ToContainer("Notes");
    }
}
