using Microsoft.EntityFrameworkCore;
using WebLibrary.Domain.Entities;

namespace WebLibrary.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

}