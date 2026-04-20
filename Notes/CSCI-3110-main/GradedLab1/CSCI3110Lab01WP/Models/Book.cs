namespace CSCI3110Lab01WP.Models;

public class Book
{
    public Book(string title, string author, long isbn)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
    }
    public string? Title { get; set; } 
    public string? Author { get; set; }
    public long? ISBN { get; set; }
}
