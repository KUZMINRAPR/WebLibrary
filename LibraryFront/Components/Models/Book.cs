namespace LibraryFront.Components.Models;

public class Book {

    public Guid Id { get; init; } = Guid.NewGuid();
    public string Title { get; set; } = "Базовое название книги";
    public string Author { get; set; } = "Автор книги";
    public string? Description {get; set;} = null;
    public string? ImageUrl { get; set; } = null;
}