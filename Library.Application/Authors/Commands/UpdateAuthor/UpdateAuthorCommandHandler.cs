using MediatR;
using AutoMapper;
using Library.Domain.Entities;
using Library.Application.Common.Exceptions;
using Library.Domain.Interfaces.Repositories;

namespace Library.Application.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper) 
        : IRequestHandler<UpdateAuthorCommand, Unit>
    {
        private readonly IAuthorRepository _authorRepository = authorRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            request.Description = request.Description ?? "";
            var author = await _authorRepository.GetAuthor(request.Id);
            if (author == null)
                throw new NotFoundException(nameof(Author), request.Id);
            _mapper.Map(request, author);
            await _authorRepository.UpdateAuthor(author);
            
            return Unit.Value;
        }
    }
}