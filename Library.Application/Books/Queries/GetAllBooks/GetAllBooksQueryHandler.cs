using AutoMapper;
using MediatR;
using Library.Domain.Interfaces.Repositories;
using Library.Application.DTOs;

namespace Library.Application.Books.Queries.GetAllBooks
{
    public class GetAllBooksQueryHandler(IBookRepository bookRepository, IMapper mapper)
        : IRequestHandler<GetAllBooksQuery, IEnumerable<BookWithAuthorsDto>>
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<BookWithAuthorsDto>> Handle(GetAllBooksQuery request,
            CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetAllBooks();
            return _mapper.Map<IEnumerable<BookWithAuthorsDto>>(book);
        }
    }
}