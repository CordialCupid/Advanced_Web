using Microsoft.EntityFrameworkCore;
using PetAJAX.Models.Entities;

namespace PetAJAX.Services;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Pet> Pets => Set<Pet>();
}
