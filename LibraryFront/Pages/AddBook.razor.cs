using Microsoft.AspNetCore.Components;
using LibraryCommon;

namespace LibraryFront.Pages;

public partial class AddBook : ComponentBase
{
    private Book newBook = new Book();

    private async Task AddBookToServer()
    {
        var response = await client.PostAsJsonAsync($"/api/books", newBook);
        Console.WriteLine($"Content {response.Content}");
        // TODO: Че-то странно обработана ошибка, не лучше ли использовать try-catch или using?
        if (response.IsSuccessStatusCode)
        {
            newBook = new Book(); // Сбросить форму после добавления
        }
        else
        {
            var errorMessage = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Ошибка при добавлении книги: {errorMessage}");
        }

    }
}