using System.ComponentModel.DataAnnotations;
namespace SecurityConcerns.Models.ViewModels;

public class CreatePersonVM {
    public string FirstName {get; set;} = string.Empty;
    public string? MiddleName {get; set;}
    public string LastName {get; set;} = string.Empty;
    [DataType(DataType.Date)]
    public DateTime DateOfBirth {get;set;}

    // factory method for copying data in vm over to other person model for submission to DB
    public Person GetPersonInstance() {
        return new Person{
            Id = 0,
            FirstName = this.FirstName,
            MiddleName = this.MiddleName,
            LastName = this.LastName,
            DateOfBirth = this.DateOfBirth
        };
    }
}