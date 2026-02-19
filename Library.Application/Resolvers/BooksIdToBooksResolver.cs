using AutoMapper;
using Library.Application.DTOs;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Resolvers
{
    public class BooksIdToBooksResolver : IValueResolver<AuthorDto, Author, List<Book>>
    {
        private readonly IBookRepository _bookRepository;

        public BooksIdToBooksResolver(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<Book> Resolve(
            AuthorDto source,
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
