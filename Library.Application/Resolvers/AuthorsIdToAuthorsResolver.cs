using AutoMapper;
using Library.Application.Books.Commands.UpdateBook;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;

namespace Library.Application.Resolvers
{
    public class AuthorsIdToAuthorsResolver(IAuthorRepository authorRepository)
        : IValueResolver<UpdateBookCommand, Book, List<Author>>
    {
        private readonly IAuthorRepository _authorRepository = authorRepository;

        public List<Author> Resolve(
            UpdateBookCommand source,
            Book destination,
            List<Author> destMember,
            ResolutionContext context)
        {
            if (source.AuthorsId == null || !source.AuthorsId.Any())
                return new List<Author>();

            return _authorRepository
                .GetAuthorsByIds(source.AuthorsId)
                .ToList();
        }
    }
}
