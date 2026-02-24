using MediatR;
using AutoMapper;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;

namespace Library.Application.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        : IRequestHandler<CreateBookCommand, Guid>
    {
        private readonly IBookRepository _bookRepository =  bookRepository;
        private readonly IMapper _mapper =  mapper;
        
        public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request);
            
            await _bookRepository.AddBook(book);
            
            return book.Id;
        }
    }
}
