using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using WebLibrary.Shared.DTOs;


namespace WebLibrary.Front.Pages.Books;

public partial class Books : ComponentBase
{
    private BookDto?[] books = Array.Empty<BookDto>();

    protected override async Task OnInitializedAsync()
    {
        // Получаем книги с сервера
        books = await GetBookDtosFromServer();
    }

    private async Task<BookDto[]?> GetBookDtosFromServer()
    {
        var response = await client.GetAsync("api/books");
        if (response.IsSuccessStatusCode)
        {
            var book = await response.Content.ReadFromJsonAsync<BookDto[]>();
            return book;
        }
        return null;
    }

    // Пока у меня нет сервера, я буду использовать этот метод для получения книг
    // TODO: Если я захочу дальше апгрейдить этот проект надо будет добавить делегат для возможности различных способов получения книг
    internal BookDto[] GetBookDtosForTest()
    {
        return new BookDto[]
        {
            new BookDto { Title = "Братья Карамазовы", Author = "Федор Достоевский",
                Description  = "Роман о нравственном выборе, свободе и ответственности"},
            new BookDto { Title = "1984", Author = "Джордж Оруэлл",
                Description = "Антиутопический роман о тоталитарном обществе"},
            new BookDto { Title = "Убить пересмешника", Author = "Харпер Ли",
                Description = "Роман о расовых предрассудках и справедливости в американском юге"}
        };
    }

}