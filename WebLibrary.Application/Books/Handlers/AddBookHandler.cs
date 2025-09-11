using MediatR;
using WebLibrary.Application.Books.DTOs;
using WebLibrary.Domain.Interfaces;

namespace WebLibrary.Application.Books.Handlers;
public class AddBookHandler : IRequestHandler<AddBookCommand>
{
    private readonly IBookRepository _bookRepository;

    public AddBookHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        await _bookRepository.AddAsync(request.book.ToBook());
    }
}