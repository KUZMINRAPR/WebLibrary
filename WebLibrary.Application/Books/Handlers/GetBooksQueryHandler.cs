using MediatR;
using WebLibrary.Shared.DTOs;
using WebLibrary.Domain.Interfaces;

namespace WebLibrary.Application.Books.Handlers;
public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, List<BookDto>>
{
    private readonly IBookRepository _bookRepository;

    public GetBooksQueryHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<List<BookDto>> Handle(
        GetBooksQuery request,
        CancellationToken cancellationToken
    )
    {
        return (await _bookRepository.GetAllBooksAsync())
            .Select(b => b.ToDto()).ToList();
    }
}