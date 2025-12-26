using MediatR;
using WebLibrary.Shared.DTOs;

public record GetBookByAuthorAndTitleQuery(string Author, string Title) : IRequest<List<BookDto>>;