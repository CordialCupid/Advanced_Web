using System.ComponentModel.DataAnnotations;
namespace SecurityConcerns.Models;

public class Person {
    public int Id {get; set;}
    public string FirstName {get; set;} = string.Empty;
    public string? MiddleName {get; set;}
    public string LastName {get; set;} = string.Empty;
    [DataType(DataType.Date)]
    public DateTime DateOfBirth {get;set;}
}