using WebAPI.Models.Entities;

namespace WebAPI.Services;

public interface IPetRepository {
    Task<ICollection<Pet>> ReadAllAsync();
    Task<Pet> CreateAsync(Pet newPet);
    Task<Pet?> ReadAsync(int id);
    Task UpdateAsync(int oldId, Pet updatedPet);
    Task DeleteAsync(int id);
}