using System.ComponentModel.DataAnnotations;

namespace LibraryFront.Components.Models;

public class Book {

    public Guid Id { get; init; } = Guid.NewGuid();

    [Required(ErrorMessage = "Название обязательно")]
    public string? Title { get; set; } = null;

    [Required(ErrorMessage = "Автор обязателен")]
    public string? Author { get; set; } = null;
    public string? Description {get; set;} = null;
    public string? ImageUrl { get; set; } = null;
}