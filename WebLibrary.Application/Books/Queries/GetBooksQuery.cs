using MediatR;
using WebLibrary.Shared.DTOs;

public record GetBooksQuery : IRequest<List<BookDto>>;