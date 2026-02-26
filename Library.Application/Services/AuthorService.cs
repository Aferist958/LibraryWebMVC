using AutoMapper;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using Library.Application.Interfaces.Services;
using Library.Application.DTOs;

namespace Library.Application.Services
{
    public class AuthorService(IAuthorRepository authorRepository) 
        : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository = authorRepository;

        public async Task<List<AuthorWithBooksDto>> SearchAuthorsService(string search,
            IEnumerable<AuthorWithBooksDto> authors)
        {
            List<AuthorWithBooksDto> searchResult = new List<AuthorWithBooksDto>();
            
            if (!string.IsNullOrEmpty(search))
            {
                searchResult.AddRange(authors
                    .Where(a => a.Name
                        .Contains(search, StringComparison.OrdinalIgnoreCase)));
                searchResult.AddRange(authors
                    .Where(a => a.Description
                        .Contains(search, StringComparison.OrdinalIgnoreCase)));
                searchResult.AddRange(authors
                    .Where(a => a.Books
                        .Any(b => b.Title
                            .Contains(search))));
                if (int.TryParse(search, out int year))
                {
                    searchResult.AddRange(authors
                        .Where(a => a.Books
                            .Any(b => b.YearOfPublication == year)));
                }
                searchResult = searchResult
                    .DistinctBy(a => a.Id)
                    .ToList();
            }
            return searchResult;
        }
    }
}
