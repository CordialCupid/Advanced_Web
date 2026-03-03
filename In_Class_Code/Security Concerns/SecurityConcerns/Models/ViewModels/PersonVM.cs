using System.ComponentModel.DataAnnotations;
namespace SecurityConcerns.Models.ViewModels;

public class PersonVM {
    [Required(ErrorMessage = "The name cannot be blank!")]
    public string Name {get; set;} = string.Empty;
    
    [StringLength(20, MinimumLength=3, ErrorMessage="Must be at least 3 and at most 20 characters!")]
    public string Occupation {get;set;} = string.Empty;
    
    [Range(18,100)]
    public int Age {get; set;}
    
    [RegularExpression(@"((\(\d{3}\)?)|(\d{3}-))?\d{3}-\d{4}", ErrorMessage="")] // use regex 101 to test regular expression
    public string Phone {get; set;} = string.Empty;
    
    [NotInFutureDate]
    [Display(Name="Date of Birth")] // Used to set the label for the input element in the generated view, by default they are the saem as the property name but this is used to change it to a custom
    [DataType(DataType.Date)] // Helps with generated view form to select correct input type
    public DateTime DateOfBirth {get; set;}
    
    [DataType(DataType.Currency)]
    public decimal PayPerHour {get; set;}
    
    [EmailAddress(ErrorMessage="Invalid Email!")]
    public string Email {get; set;} = string.Empty;
}