using Library.Domain.Entities;
using Library.Application.DTOs;

namespace Library.Application.Interfaces.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        BookDto? GetBook(Guid id);
        void AddBook(BookDto dto);
        void UpdateBook(BookDto dto);
        void DeleteBook(Guid id);
    }
}
