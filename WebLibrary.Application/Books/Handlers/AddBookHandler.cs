using MediatR;
using WebLibrary.Domain.Interfaces;
using WebLibrary.Shared.DTOs;

namespace WebLibrary.Application.Books.Handlers;
public class AddBookHandler : IRequestHandler<AddBookCommand, Guid>
{
    private readonly IBookRepository _bookRepository;

    public AddBookHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Guid> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        await _bookRepository.AddAsync(request.book.ToBook());
        return request.book.Id;
    }

}