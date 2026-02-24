using AutoMapper;
using Library.Application.Authors.Commands.UpdateAuthor;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;

namespace Library.Application.Resolvers
{
    public class UpdateBooksIdToBooksResolver(IBookRepository bookRepository)
        : IValueResolver<UpdateAuthorCommand, Author, List<Book>>
    {
        private readonly IBookRepository _bookRepository = bookRepository;

        public List<Book> Resolve(
            UpdateAuthorCommand source,
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
