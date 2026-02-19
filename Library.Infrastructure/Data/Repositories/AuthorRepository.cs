using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using Library.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;


namespace Library.Infrastructure.Data.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _dbContext;

        public AuthorRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await _dbContext.Authors
                .AsNoTracking()
                .Include(a => a.Books)
                .ToListAsync();
        }

        public async Task<IEnumerable<Author>> GetAuthorsByIds(IEnumerable<Guid> ids)
        {
            if (ids == null || !ids.Any())
                return Enumerable.Empty<Author>();
            return await _dbContext.Authors
                .AsNoTracking()
                .Where(a => ids.Contains(a.Id))
                .ToListAsync();
        }

        public async Task<Author?> GetAuthor(Guid id)
        {
            return await _dbContext.Authors
                .AsNoTracking()
                .Include(b => b.Books)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task AddAuthor(Author author)
        {
            await _dbContext.Authors
                .AddAsync(author);
            await _dbContext
                .SaveChangesAsync();
        }

        public async Task UpdateAuthor(Author author)
        {
            _dbContext.Authors
                .Update(author);
            await _dbContext
                .SaveChangesAsync();
        }

        public async Task DeleteAuthor(Guid id)
        {
            await _dbContext.Authors
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
