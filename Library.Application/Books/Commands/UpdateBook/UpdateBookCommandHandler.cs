using MediatR;
using AutoMapper;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using Library.Application.Common.Exceptions;

namespace Library.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        : IRequestHandler<UpdateBookCommand, Unit>
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBook(request.Id);
            if (book == null)
                throw new NotFoundException(nameof(Book), request.Id);
            _mapper.Map(request, book);
            await _bookRepository.UpdateBook(book);
            
            return Unit.Value;
        }
    }    
}

