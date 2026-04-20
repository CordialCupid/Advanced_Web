using System;
using Microsoft.EntityFrameworkCore;
using CSCI3110MKLAB2CRRUD.Models.Entities;

namespace CSCI3110MKLAB2CRRUD.Services;

public class ApplicationDbContext : DbContext {
    public ApplicationDbContext(DbContextOptions options) : base(options) {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Product>().HasData(
            new Product {Id=1, Name="Shirt", Price=21.99M, WeightInPounds=1.1, 
            ManufactureDate=DateTime.Parse("2/19/2026"), InStock=true}
        );
    }

    public DbSet<Product> Product => Set<Product>();
}