using Lab5MKBookAuthorApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab5MKBookAuthorApp.Services;

public class DbBookRepository : IBookRepository
{
    private readonly ApplicationDbContext _db;
    public DbBookRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<ICollection<Book>> ReadAllAsync()
    {
        return await _db.Books
                        .Include(b => b.Authors)
                        .ToListAsync();
    }
    public async Task<Book?> ReadAsync(int id)
    {
        return await _db.Books
                    .Include(b => b.Authors)
                    .FirstOrDefaultAsync(b => b.Id == id);
    }
}