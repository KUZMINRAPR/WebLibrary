using MediatR;
using WebLibrary.Application.Books.DTOs;
using WebLibrary.Domain.Entities;

public record AddBookCommand(BookDto book) : IRequest<BookDto>;