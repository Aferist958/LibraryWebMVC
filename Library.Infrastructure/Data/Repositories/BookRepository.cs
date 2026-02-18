using Library.Domain.Entities;
using Library.Domain.Interafaces.Repositories;
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

        public IEnumerable<Book> GetAllBooks()
        {
            return _dbContext.Books.Include(b => b.Authors).ToList();
        }

        public IEnumerable<Book> GetBooksByIds(IEnumerable<Guid> ids)
        {
            if (ids == null || !ids.Any())
                return Enumerable.Empty<Book>();
            return _dbContext.Books
                .Where(a => ids.Contains(a.Id))
                .ToList();
        }

        public Book? GetBook(Guid id)
        {
            return _dbContext.Books.Include(b => b.Authors).FirstOrDefault(b => b.Id == id);
        }

        public void AddBook(Book book)
        {
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            _dbContext.Books.Update(book);
            _dbContext.SaveChanges();
        }

        public void DeleteBook(Guid id)
        {
            var book = _dbContext.Books.Find(id);
            if (book != null)
            {
                _dbContext.Books.Remove(book);
                _dbContext.SaveChanges();
            }
        }
    }
}
