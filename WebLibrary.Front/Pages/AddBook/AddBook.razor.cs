using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using WebLibrary.Shared.DTOs;

namespace WebLibrary.Front.Pages.AddBook;

public partial class AddBook : ComponentBase
{
    private BookDto? newBook;

    private async Task AddBookToServer()
    {
        var response = await client.PostAsJsonAsync($"/api/books", newBook);
        Console.WriteLine($"Content {response.Content}");
        // TODO: Че-то странно обработана ошибка, не лучше ли использовать try-catch или using?
        if (response.IsSuccessStatusCode)
        {
            newBook = null; // Сбросить форму после добавления
        }
        else
        {
            var errorMessage = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Ошибка при добавлении книги: {errorMessage}");
        }

    }
}