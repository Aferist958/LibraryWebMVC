using MediatR;
using AutoMapper;
using Library.Application.DTOs;
using Library.Domain.Interfaces.Repositories;

namespace Library.Application.Books.Queries.GetBook
{
    public class GetBookQueryHandler(IBookRepository bookRepository, IMapper mapper) 
        : IRequestHandler<GetBookQuery, BookDto>
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<BookDto> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBook(request.Id);
            
            return _mapper.Map<BookDto>(book);
        }
    }   
}