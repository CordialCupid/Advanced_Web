using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lab5MKBookAuthorApp.Models.Entities;

public class Author
{
    public int Id {get;set;}
    [StringLength(128)]
    public string? FirstName {get;set;}
    [StringLength(128)]
    [Required]
    public string LastName {get;set;} = String.Empty;
    [JsonIgnore]
    public Book? Book {get;set;}
}