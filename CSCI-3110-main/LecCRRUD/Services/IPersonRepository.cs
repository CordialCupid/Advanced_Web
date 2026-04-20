using LecCRRUD.Models.Entities;

namespace LecCRRUD.Services;

public interface IPersonRepository
{
    Task<ICollection<Person>> ReadAllAsync();

    Task<Person> CreateAsync(Person newPerson);

    Task<Person?> ReadAsync(int id); // nullable because entered id could not exist

    Task UpdateAsync(int oldId, Person person); // this one doesnt return anything

    Task DeleteAsync(int id); 
}