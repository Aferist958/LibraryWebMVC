using Library.Application.Interfaces.Services;
using Library.Application.DTOs;
using Library.Domain.Entities;
using Library.Domain.Interafaces;
using Library.Domain.Interafaces.Repositories;
using Library.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Library.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            var books = _bookRepository.GetAllBooks();
            return books;
        }

        public BookDto? GetBook(Guid id)
        {
            var book = _bookRepository.GetBook(id);
            return _mapper.Map<BookDto>(book);
        }

        public void AddBook(BookDto dto)
        {
            var book = _mapper.Map<Book>(dto);
            _bookRepository.AddBook(book);
        }

        public void UpdateBook(BookDto dto)
        {
            var book = _bookRepository.GetBook(dto.Id);
            _mapper.Map(dto, book);
            _bookRepository.UpdateBook(book);
        }

        public void DeleteBook(Guid id)
        {
            _bookRepository.DeleteBook(id);
        }
    }
}
