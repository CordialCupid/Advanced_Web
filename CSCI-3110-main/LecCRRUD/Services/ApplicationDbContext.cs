using System;
using Microsoft.EntityFrameworkCore;
using LecCRRUD.Models.Entities;

namespace LecCRRUD.Services;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().HasData(
            new Person { Id=1, FirstName="John", LastName="Doe", 
            DateOfBirth=DateTime.Parse("1/1/1980")}
        );
    }

    public DbSet<Person> People => Set<Person>();

}