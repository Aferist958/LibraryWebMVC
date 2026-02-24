using Library.Domain.Entities;

namespace Library.Domain.Interfaces.Repositories
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAuthorsByIds(IEnumerable<Guid> ids);
        Task<IEnumerable<Author>> GetAllAuthors();
        Task<IEnumerable<Author>> GetAuthorsByIdsAsync(IEnumerable<Guid> ids);
        Task<Author?> GetAuthor(Guid id);
        Task AddAuthor(Author author);
        Task UpdateAuthor(Author author);
        Task DeleteAuthor(Guid id);
    }
}
