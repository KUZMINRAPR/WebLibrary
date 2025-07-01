using LibraryFront.Components.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryBack.DataBase;

class LibraryContext : DbContext
{
    public DbSet<Book>? Books => Set<Book>();

    public LibraryContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=library.db");
    }
}