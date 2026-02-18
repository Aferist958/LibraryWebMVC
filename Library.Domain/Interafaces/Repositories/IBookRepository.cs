using Library.Domain.Entities;

namespace Library.Domain.Interafaces.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> GetBooksByIds(IEnumerable<Guid> ids);
        Book? GetBook(Guid id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Guid id);
    }
}
