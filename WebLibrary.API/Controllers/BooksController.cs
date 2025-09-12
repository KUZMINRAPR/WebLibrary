using Microsoft.AspNetCore.Mvc;
using MediatR;
using WebLibrary.Application.Books.DTOs;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

[Route("/api/books")]
public class BooksController : Controller
{
    private readonly IMediator _mediator;
    private readonly ILogger<BooksController> _logger;

    public BooksController(IMediator mediator, ILogger<BooksController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    //TODO: Добавить GetBookByAuthorAndTitleQuery и использовать его здесь
    [HttpGet("{author}/{title}")]
    public async Task<IActionResult> GetBook(string author, string title)
    {
        _logger.LogInformation($"GetBook вызван с параметрами: {author}, {title}");
        var book = await _mediator.Send(new GetBookByAuthorAndTitleQuery(author, title));
        if (book == null)
        {
            _logger.LogWarning($"Книга не найдена: {author}, {title}");
            return NotFound();
        }
        return Ok(book);
    }

    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        var books = await _mediator.Send(new GetBooksQuery());
        if (books == null || !books.Any())
        {
            _logger.LogWarning("Список книг пуст или не найден");
            return NotFound();
        }
        return Ok(books);
    }
    [HttpPost]
    public async Task<IActionResult> AddBook([FromBody] BookDto book)
    {
        await _mediator.Send(new AddBookCommand(book));
        return Ok();
    }
}