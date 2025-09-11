using MediatR;

public record GetBooksQuery : IRequest<List<WebLibrary.Application.Books.DTOs.BookDto>>;