using Lab5MKBookAuthorApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab5MKBookAuthorApp.Services;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Book> Books => Set<Book>();
    public DbSet<Author> Authors => Set<Author>();
}