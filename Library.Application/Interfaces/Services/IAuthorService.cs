using Library.Domain.Entities;
using Library.Application.DTOs;

namespace Library.Application.Interfaces.Services
{
    public interface IAuthorService
    {
        Task<List<AuthorWithBooksDto>> SearchAuthorsService(string search, IEnumerable<AuthorWithBooksDto> authors);
    }
}
