public class Book {
    public string Title {get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public short PublicationYear { get; set; } = 1000;

    public Book(string title, string author, short publicationYear) {
        Title = title;
        Author = author;
        PublicationYear = publicationYear;
    }
}