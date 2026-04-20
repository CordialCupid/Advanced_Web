using Lab5MKBookAuthorApp.Models.Entities;

namespace Lab5MKBookAuthorApp.Services;

public class Initializer
{
    private readonly ApplicationDbContext _db;
    public Initializer(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task SeedDatabaseAsync()
    {
        _db.Database.EnsureCreated();

        if (_db.Books.Any()) return;

        var books = new List<Book>
        {
            new() {Title = "The Midnigh Library", PublicationYear = 2020},
            new() { Title = "Project Hail Mary", PublicationYear = 2021},
            new() { Title = "Tomorrow, and Tomorrow, and Tomorrow", PublicationYear = 2022},
            new() { Title = "The Woman in Me", PublicationYear = 2023},
            new() { Title = "The Housemaid ", PublicationYear = 2022}
        };

        await _db.Books.AddRangeAsync(books);
        await _db.SaveChangesAsync();
    }
}