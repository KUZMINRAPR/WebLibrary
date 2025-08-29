namespace LibraryCommon;

public class Book {

    public Guid Id { get; init; } = Guid.NewGuid();

    public string? Title { get; set; } = null;

    public string? Author { get; set; } = null;
    public string? Description {get; set;} = null;
    public string? ImageUrl { get; set; } = null;
}
