using AutoMapper;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using Library.Application.Authors.Commands.CreateAuthor;

namespace Library.Application.Resolvers
{
    public class CreateBooksIdToBooksResolver(IBookRepository bookRepository)
        : IValueResolver<CreateAuthorCommand, Author, List<Book>>
    {
        private readonly IBookRepository _bookRepository = bookRepository;

        public List<Book> Resolve(
            CreateAuthorCommand source,
            Author destination,
            List<Book> destMember,
            ResolutionContext context)
        {
            if (source.BooksId == null || !source.BooksId.Any())
                return new List<Book>();

            return _bookRepository
                .GetBooksByIds(source.BooksId)
                .ToList();
        }
    }
}