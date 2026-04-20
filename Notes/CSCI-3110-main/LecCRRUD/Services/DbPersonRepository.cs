using LecCRRUD.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LecCRRUD.Services;

public class DbPersonRepository : IPersonRepository {
    private readonly ApplicationDbContext _db;

// inject applicationdbcontext into the repo (this is probably going to be an exam question!)
    public DbPersonRepository(ApplicationDbContext db) 
    {
        _db = db;
    }

    public async Task<ICollection<Person>> ReadAllAsync()
    {
        return await _db.People.ToListAsync();
    }

    public async Task<Person> CreateAsync(Person newPerson) {
        await _db.People.AddAsync(newPerson);
        await _db.SaveChangesAsync(); // commit transaction to database
        return newPerson;
    }

    public async Task<Person?> ReadAsync(int id) {
        return await _db.People.FindAsync(id); // faster, but uses primary key only to search; if i were searching by name, I would need to use alternative method
        // Alternative:
        // return await _db.People.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task UpdateAsync(int oldId, Person person) {
        var personToUpdate = await ReadAsync(oldId);

        if (personToUpdate != null) {
            personToUpdate.FirstName = person.FirstName;
            personToUpdate.MiddleName = person.MiddleName;
            personToUpdate.LastName = person.LastName;
            personToUpdate.DateOfBirth = person.DateOfBirth;
            await _db.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id) {
        var personToDelete = await ReadAsync(id);

        if (personToDelete != null) {
            _db.People.Remove(personToDelete);
            await _db.SaveChangesAsync();
        }
    }
}