namespace WebLibrary.Domain.Entities;

public class Book
{

    public Guid Id { get; init; } = Guid.NewGuid();

    public string? Title { get; set; } = null;

    public string? Author { get; set; } = null;
    public string? Description { get; set; } = null;
    public string? ImageUrl { get; set; } = null;

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }

    public Book(string title, string author, string description) : this(title, author)
    {
        Description = description;
    }

    public Book(string title, string author, string description, string imageUrl) : this(title, author)
    {
        Description = description;
        ImageUrl = imageUrl;
    }
}
