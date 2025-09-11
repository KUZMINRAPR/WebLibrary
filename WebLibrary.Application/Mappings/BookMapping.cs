using WebLibrary.Application.Books.DTOs;
using WebLibrary.Domain.Entities;

public static class BookMapping
{
    public static BookDto ToDto(this Book book) =>
        new BookDto
        {
            Id = book.Id,
            Author = book.Author,
            Title = book.Title,
            Description = book.Description,
            ImageUrl = book.ImageUrl
        };
    
    public static Book ToBook(this BookDto bookDto) =>
        new Book(bookDto.Title, bookDto.Author, bookDto.Description, bookDto.ImageUrl)
        {
            Id = bookDto.Id
        };
}