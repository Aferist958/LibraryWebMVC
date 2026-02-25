using MediatR;
using Library.Domain.Interfaces.Repositories;

namespace Library.Application.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandHandler(IAuthorRepository authorRepository)
        : IRequestHandler<DeleteAuthorCommand, Unit>
    {
        private readonly IAuthorRepository _authorRepository = authorRepository;

        public async Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            await _authorRepository.DeleteAuthor(request.Id);
            
            return Unit.Value;
        }
    }
}