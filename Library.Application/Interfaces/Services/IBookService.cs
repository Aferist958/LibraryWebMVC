using Library.Domain.Entities;
using Library.Application.DTOs;

namespace Library.Application.Interfaces.Services
{
    public interface IBookService
    {
        Task<List<BookWithAuthorsDto>> SearchBooksService(string search, IEnumerable<BookWithAuthorsDto> books);
        Task IssueBook(BookDto book);
        Task ReturnBook(BookDto book);
    }
}
