using Lab5MKBookAuthorApp.Models.Entities;

namespace Lab5MKBookAuthorApp.Services;

public class DbAuthorRepository : IAuthorRepository
{
    private readonly ApplicationDbContext _db;

    public DbAuthorRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Book?> ReadAsync(int id)
    {
        return await _db.Books.FindAsync(id);
    }
    public async Task<Author> CreateAsync(int id, Author author)
    {
        Book? book = await ReadAsync(id);
        if (book != null)
        {
            author.Book = book;
            await _db.Authors.AddAsync(author);
            await _db.SaveChangesAsync();
        }
        return author;
    }
}