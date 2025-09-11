using MediatR;
using WebLibrary.Application.Books.DTOs;
using WebLibrary.Domain.Interfaces;

namespace WebLibrary.Application.Books.Handlers;
public class GetBookByAuthorAndTitleHandler : IRequestHandler<GetBookByAuthorAndTitleQuery, List<BookDto>>
{
    private readonly IBookRepository _bookRepository;

    public GetBookByAuthorAndTitleHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<List<BookDto>> Handle(GetBookByAuthorAndTitleQuery request, CancellationToken cancellationToken)
    {
        var books = (await _bookRepository.GetByAuthorAndTitleAsync(request.Author, request.Title)).Select(b => b.ToDto()).ToList();
        return books;
    }
}