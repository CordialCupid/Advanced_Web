using Lab5MKBookAuthorApp.Models.Entities;

namespace Lab5MKBookAuthorApp.Services;

public interface IAuthorRepository
{
    Task<Book?> ReadAsync(int id);
    Task<Author> CreateAsync(int id, Author author);
}