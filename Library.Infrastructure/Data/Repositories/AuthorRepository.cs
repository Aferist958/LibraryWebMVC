using Library.Domain.Entities;
using Library.Domain.Interafaces.Repositories;
using Library.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Data.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private AppDbContext _dbContext;

        public AuthorRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _dbContext.Authors.Include(a => a.Books).ToList();
        }

        public IEnumerable<Author> GetAuthorsByIds(IEnumerable<Guid> ids)
        {
            if (ids == null || !ids.Any())
                return Enumerable.Empty<Author>();
            return _dbContext.Authors
                .Where(a => ids.Contains(a.Id))
                .ToList();
        }

        public Author? GetAuthor(Guid id)
        {
            return _dbContext.Authors.Include(b => b.Books).FirstOrDefault(b => b.Id == id);
        }

        public void AddAuthor(Author author)
        {
            _dbContext.Authors.Add(author);
            _dbContext.SaveChanges();
        }

        public void UpdateAuthor(Author author)
        {
            _dbContext.Authors.Update(author);
            _dbContext.SaveChanges();
        }

        public void DeleteAuthor(Guid id)
        {
            var author = _dbContext.Authors.Find(id);
            if (author != null)
            {
                _dbContext.Authors.Remove(author);
                _dbContext.SaveChanges();
            }
        }
    }
}
