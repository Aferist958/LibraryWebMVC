using AutoMapper;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using Library.Application.Books.Commands.CreateBook;

namespace Library.Application.Resolvers
{
    public class CreateAuthorsIdToAuthorsResolver(IAuthorRepository authorRepository)
        : IValueResolver<CreateBookCommand, Book, List<Author>>
    {
        private readonly IAuthorRepository _authorRepository = authorRepository;

        public List<Author> Resolve(
            CreateBookCommand source,
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
