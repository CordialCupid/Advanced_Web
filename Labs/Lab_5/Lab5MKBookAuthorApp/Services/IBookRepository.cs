using Lab5MKBookAuthorApp.Models.Entities;

namespace Lab5MKBookAuthorApp.Services;

public interface IBookRepository
{
    Task<ICollection<Book>> ReadAllAsync();
    Task<Book?> ReadAsync(int id);
}