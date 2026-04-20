using CSCI3110MKLAB2CRRUD.Models.Entities;

namespace CSCI3110MKLAB2CRRUD.Services;

public interface IProductRepository {
    Task<ICollection<Product>> ReadAllAsync();

    Task<Product> CreateAsync(Product newProduct);

    Task<Product?> ReadAsync(int id);

    Task UpdateAsync(int id, Product product);

    Task DeleteAsync(int id);
}