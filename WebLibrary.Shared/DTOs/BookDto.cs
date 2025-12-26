namespace WebLibrary.Shared.DTOs;
public class BookDto
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }

    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
}
