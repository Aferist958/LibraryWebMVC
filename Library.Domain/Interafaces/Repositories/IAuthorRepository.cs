using Library.Domain.Entities;

namespace Library.Domain.Interafaces.Repositories
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAllAuthors();
        IEnumerable<Author> GetAuthorsByIds(IEnumerable<Guid> ids);
        Author? GetAuthor(Guid id);
        void AddAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(Guid id);
    }
}
