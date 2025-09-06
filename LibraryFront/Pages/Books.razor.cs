using Microsoft.AspNetCore.Components;
using LibraryCommon;

namespace LibraryFront.Pages;

public partial class Books : ComponentBase
{
    private Book?[] books = Array.Empty<Book>();

    protected override async Task OnInitializedAsync()
    {
        // Получаем книги с сервера
        books = await GetBooksFromServer();
    }

    private async Task<Book[]?> GetBooksFromServer()
    {
        var response = await client.GetAsync("api/books");
        if (response.IsSuccessStatusCode)
        {
            var books = await response.Content.ReadFromJsonAsync<Book[]>();
            return books;
        }
        return null;
    }

    // Пока у меня нет сервера, я буду использовать этот метод для получения книг
    // TODO: Если я захочу дальше апгрейдить этот проект надо будет добавить делегат для возможности различных способов получения книг
    internal Book[] GetBooksForTest()
    {
        return new Book[]
        {
            new Book { Title = "Братья Карамазовы", Author = "Федор Достоевский",
                Description  = "Роман о нравственном выборе, свободе и ответственности"},
            new Book { Title = "1984", Author = "Джордж Оруэлл",
                Description = "Антиутопический роман о тоталитарном обществе"},
            new Book { Title = "Убить пересмешника", Author = "Харпер Ли",
                Description = "Роман о расовых предрассудках и справедливости в американском юге"}
        };
    }

}