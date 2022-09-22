using BlazorEF.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorEF.Shared;

public class DataContext: DbContext
{
    public DbSet<NoteModel> Notes { get; set; }

    public DataContext()
    {
        //Database.EnsureDeleted();
        //Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer("Data Source=localhost;Initial Catalog=BlazorEF;Integrated Security=False;Persist Security Info=False;User ID=sa;Password=Password2022;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<NoteModel>().ToContainer("Notes");
    }
}
