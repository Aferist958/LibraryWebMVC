using MediatR;
using AutoMapper;
using Library.Domain.Interfaces.Repositories;
using Library.Application.Books.Commands.UpdateBook;
using Library.Application.Interfaces.Services;
using Library.Application.DTOs;

namespace Library.Application.Services
{
    public class BookService(IBookRepository bookRepository,  IMapper mapper, IMediator mediator)
        : IBookService
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IMediator _mediator = mediator;

        public async Task<List<BookWithAuthorsDto>> SearchBooksService(string search,
            IEnumerable<BookWithAuthorsDto> books)
        {
            List<BookWithAuthorsDto> searchResult = new List<BookWithAuthorsDto>();
            
            if (!string.IsNullOrEmpty(search))
            {
                searchResult.AddRange(books
                    .Where(b => b.Title
                        .Contains(search, StringComparison.OrdinalIgnoreCase)));
                searchResult.AddRange(books
                    .Where(b => b.Authors
                        .Any(a => a.Name
                            .Contains(search))));
                if (int.TryParse(search, out int year))
                {
                    searchResult.AddRange(books
                        .Where(b => b.YearOfPublication == year));
                }
                searchResult = searchResult
                    .DistinctBy(b => b.Id)
                    .ToList();
            }
            
            return searchResult;
        }

        public async Task IssueBook(BookDto book)
        {
            if (book.Quantity > 0)
            {
                book.Quantity--;
                UpdateBookCommand updateBookCommand = _mapper.Map<UpdateBookCommand>(book);
                await _mediator.Send(updateBookCommand);
            }
        }

        public async Task ReturnBook(BookDto book)
        {
            book.Quantity++;
            UpdateBookCommand updateBookCommand = _mapper.Map<UpdateBookCommand>(book);
            await _mediator.Send(updateBookCommand);
        }
    }
}
