using Microsoft.EntityFrameworkCore;
using WebAPI.Models.Entities;

namespace WebAPI.Services;

public class ApplicationDbContext : DbContext {
    public ApplicationDbContext(DbContextOptions options) : base(options) {
    }

    public DbSet<Pet> Pets => Set<Pet>(); // interface into database, table of pets
}