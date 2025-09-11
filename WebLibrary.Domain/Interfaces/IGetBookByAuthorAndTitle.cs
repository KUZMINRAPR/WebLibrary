using WebLibrary.Domain.Entities;
public interface IGetBookByAuthorAndTitle
{
    Task<List<Book>> GetByAuthorAndTitleAsync(string author, string title);
}