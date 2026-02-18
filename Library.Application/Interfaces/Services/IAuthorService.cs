using Library.Domain.Entities;
using Library.Application.DTOs;

namespace Library.Application.Interfaces.Services
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAllAuthors();
        AuthorDto? GetAuthor(Guid id);
        void AddAuthor(AuthorDto dto);
        void UpdateAuthor(AuthorDto dto);
        void DeleteAuthor(Guid id);
    }
}
