using Microsoft.EntityFrameworkCore;
using WebLibrary.Domain.Entities;
using WebLibrary.Domain.Interfaces;
using WebLibrary.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;

namespace WebLibrary.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<BookRepository> _logger;

    public BookRepository(ApplicationDbContext context, ILogger<BookRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task AddAsync(Book book, CancellationToken cancellationToken = default)
    {
        await _context.Books.AddAsync(book);
        _logger.LogInformation("Book added");
        await _context.SaveChangesAsync(cancellationToken);
        _logger.LogInformation("Book saved");
    }


    public async Task DeleteAsync(Book book, CancellationToken cancellationToken = default)
    {
        _context.Books.Remove(book);
        _logger.LogInformation("Book deleted");

        await _context.SaveChangesAsync(cancellationToken);
        _logger.LogInformation("Changes saved");
    }

    public async Task<List<Book>> GetAllBooksAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<Book?> GetByIdAsync(Guid id)
    {
        _logger.LogInformation($"Get book by id = {id}");
        return await _context.Books.FindAsync(id);
    }

    public async Task<List<Book>> GetByAuthorAndTitleAsync(string author, string title)
    {
        _logger.LogInformation($"Get book by author = {author} and title = {title}");
        return await _context.Books.Where
        (b => b.Author!.Contains(author) && b.Title!.Contains(title)).ToListAsync()
        ?? throw new InvalidOperationException("Book not found");
    }

}