using Microsoft.AspNetCore.Mvc;
using LibraryFront.Components.Models;
using LibraryBack.DataBase;
using Microsoft.EntityFrameworkCore;

[Route("/api/books")]
public class BooksController : Controller
{
    private LibraryContext context = new();

    //TODO: Добавить класс Author для реализации лучшего поиска авторов, а не для полного сравнения введенного названия с автором, который в бд лежит
    [HttpGet("{author}/{title}")]
    public async Task<List<Book>> GetBook(string author, string title)
    {
        return await context.Books.Where(b => b.Author == author && b.Title == title).ToListAsync();
    }

    [HttpGet]
    public async Task<List<Book>> GetBooks()
    {
        return await context.Books.ToListAsync();
    }
    [HttpPost]
    public async Task<ActionResult<Book>> CreateBook([FromBody] Book book)
    {
        await context.Books.AddAsync(book);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetBook), new { author = book.Author, title = book.Title }, book);
    }
}