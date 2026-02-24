using MediatR;
using Library.Domain.Interfaces.Repositories;

namespace Library.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler(IBookRepository bookRepository)
        : IRequestHandler<DeleteBookCommand, Unit>
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        
        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            await _bookRepository.DeleteBook(request.Id);
            return Unit.Value;
        }
    }
}

