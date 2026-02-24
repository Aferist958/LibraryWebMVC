using MediatR;
using AutoMapper;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;

namespace Library.Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
        : IRequestHandler<CreateAuthorCommand, Guid>
    {
        private readonly IAuthorRepository _authorRepository = authorRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Guid> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            request.Description = request.Description ?? string.Empty;
            var author = _mapper.Map<Author>(request);
            
            await _authorRepository.AddAuthor(author);
            
            return author.Id;
        }
    }
}

