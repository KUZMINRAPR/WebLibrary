using MediatR;

public record GetBookByAuthorAndTitleQuery(string Author, string Title) : IRequest<List<WebLibrary.Application.Books.DTOs.BookDto>>;