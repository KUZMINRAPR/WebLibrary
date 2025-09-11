using Microsoft.AspNetCore.Mvc;
using WebLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WebLibrary.Domain.Interfaces;
using MediatR;
using WebLibrary.Application.Books.DTOs;

[Route("/api/books")]
public class BooksController : Controller
{
    private readonly IMediator _mediator;

    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    //TODO: Добавить GetBookByAuthorAndTitleQuery и использовать его здесь
    [HttpGet("{author}/{title}")]
    public async Task<IActionResult> GetBook(string author, string title)
    {
        var book = await _mediator.Send(new GetBookByAuthorAndTitleQuery(author, title));
        return Ok(book);
    }

    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        var books = await _mediator.Send(new GetBooksQuery());
        return Ok(books);
    }
    [HttpPost]
    public async Task<IActionResult> AddBook([FromBody] BookDto book)
    {
        await _mediator.Send(new AddBookCommand(book));
        return Ok();
    }
}