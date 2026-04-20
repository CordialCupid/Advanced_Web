using CSCI3110MKLAB2CRRUD.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSCI3110MKLAB2CRRUD.Services;

public class DbProductRepository : IProductRepository {
    private readonly ApplicationDbContext _db;

    public DbProductRepository(ApplicationDbContext db) {
        _db = db;
    }

    public async Task<ICollection<Product>> ReadAllAsync() {
        return await _db.Product.ToListAsync();
    }

    public async Task<Product> CreateAsync(Product newProduct) {
        await _db.Product.AddAsync(newProduct);
        await _db.SaveChangesAsync();
        return newProduct;
    }

    public async Task<Product?> ReadAsync(int id)
    {
        return await _db.Product.FindAsync(id);
    }

    public async Task UpdateAsync(int id, Product product)
    {
        var productToUpdate = await ReadAsync(id);

        if (productToUpdate != null)
        {
            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;
            productToUpdate.WeightInPounds = product.WeightInPounds;
            productToUpdate.ManufactureDate = product.ManufactureDate;
            productToUpdate.InStock = product.InStock;
            productToUpdate.ImageData = product.ImageData;
            productToUpdate.ImageMIMEType = product.ImageMIMEType;
            await _db.SaveChangesAsync();
        }
    }
    public async Task DeleteAsync(int id)
    {
        var productToDelete = await ReadAsync(id);

        if (productToDelete != null)
        {
            _db.Product.Remove(productToDelete);
            await _db.SaveChangesAsync();
        }
    }
}