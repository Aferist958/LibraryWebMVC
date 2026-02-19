using Library.Domain.Entities;

namespace Library.Domain.Interfaces.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<IEnumerable<Book>> GetBooksByIds(IEnumerable<Guid> ids);
        Task<Book?> GetBook(Guid id);
        Task AddBook(Book book);
        Task UpdateBook(Book book);
        Task DeleteBook(Guid id);
    }
}
