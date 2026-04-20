using System.ComponentModel.DataAnnotations;
namespace LecCRRUD.Models.Entities;

public class Person
{
    public int Id { get; set; } // this will become the primary key with auto increment
    public string FirstName { get; set; } = String.Empty;
    public string? MiddleName { get; set; } // nullable so no need to initialize the value
    public string LastName { get; set; } = String.Empty;
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }
}