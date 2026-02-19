using AutoMapper;
using Library.Application.DTOs;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;

namespace Library.Application.Resolvers
{
    public class AuthorsIdToAuthorsResolver
        : IValueResolver<BookDto, Book, List<Author>>
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorsIdToAuthorsResolver(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public List<Author> Resolve(
            BookDto source,
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
