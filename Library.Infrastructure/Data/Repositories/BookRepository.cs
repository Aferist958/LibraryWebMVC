using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using Library.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;


namespace Library.Infrastructure.Data.Repositories 
{
    public class BookRepository : IBookRepository 
    {
        private readonly AppDbContext _dbContext; 

        public BookRepository(AppDbContext dbContext) 
        {
            _dbContext = dbContext; 
        } 

        public async Task<IEnumerable<Book>> GetAllBooks() 
        {
            return await _dbContext.Books
                .AsNoTracking()
                .Include(b => b.Authors)
                .ToListAsync(); 
        } 

        public async Task<IEnumerable<Book>> GetBooksByIds(IEnumerable<Guid> ids) 
        {
            if (ids == null || !ids.Any()) 
                return Enumerable.Empty<Book>(); 
            return await _dbContext.Books
                .AsNoTracking()
                .Where(a => ids.Contains(a.Id))
                .ToListAsync(); 
        }

        public async Task<Book?> GetBook(Guid id) 
        {
            return await _dbContext.Books
                .AsNoTracking()
                .Include(b => b.Authors)
                .FirstOrDefaultAsync(b => b.Id == id); 
        } 

        public async Task AddBook(Book book) 
        {
            await _dbContext.Books
                .AddAsync(book); 
            await _dbContext
                .SaveChangesAsync(); 
        } 

        public async Task UpdateBook(Book book) 
        { 
            _dbContext.Books
                .Update(book);
            await _dbContext
                .SaveChangesAsync(); 
        }

        public async Task DeleteBook(Guid id) 
        {
            await _dbContext.Books
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync(); 
        } 
    } 
}
