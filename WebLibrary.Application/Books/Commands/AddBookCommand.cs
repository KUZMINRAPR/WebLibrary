using WebLibrary.Shared.DTOs;
using MediatR;

public record AddBookCommand(BookDto book) : IRequest<Guid>;