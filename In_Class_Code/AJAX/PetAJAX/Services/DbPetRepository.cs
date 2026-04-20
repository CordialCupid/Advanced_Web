using PetAJAX.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace PetAJAX.Services;

public class DbPetRepository : IPetRepository
{
    private readonly ApplicationDbContext _db;

    public DbPetRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<ICollection<Pet>> ReadAllAsync()
    {
        return await _db.Pets.ToListAsync();
    }

    public async Task<Pet?> ReadAsync(int id)
    {
        return await _db.Pets.FindAsync(id);
    }

    public async Task<Pet> CreateAsync(Pet newPet)
    {
        await _db.Pets.AddAsync(newPet);
        await _db.SaveChangesAsync();
        return newPet;
    }

    public async Task UpdateAsync(int oldId, Pet updatedPet)
    {
        var petToUpdate = await ReadAsync(oldId);
        if (petToUpdate != null)
        {
            petToUpdate.Name = updatedPet.Name;
            petToUpdate.Weight = updatedPet.Weight;
            await _db.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var petToDelete = await ReadAsync(id);
        if (petToDelete != null)
        {
            _db.Pets.Remove(petToDelete);
            await _db.SaveChangesAsync();
        }
    }
}
