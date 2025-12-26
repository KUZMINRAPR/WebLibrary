using WebLibrary.Domain.Entities;

namespace WebLibrary.Domain.Interfaces;
public interface IBookRepository : IGetBookByAuthorAndTitle
{
    Task<Book?> GetByIdAsync(Guid id);
    Task<List<Book>> GetAllBooksAsync();
    Task AddAsync(Book book, CancellationToken cancellationToken = default);
    Task DeleteAsync(Book book, CancellationToken cancellationToken = default);
}