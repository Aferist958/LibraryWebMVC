using MediatR;
using AutoMapper;
using Library.Domain.Interfaces.Repositories;
using Library.Application.DTOs;

namespace Library.Application.Authors.Queries.GetAuthor
{
    public class GetAuthorQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
        : IRequestHandler<GetAuthorQuery, AuthorDto>
    {
        private readonly IAuthorRepository _authorRepository = authorRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<AuthorDto> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var book = await _authorRepository.GetAuthor(request.Id);
            
            return _mapper.Map<AuthorDto>(book);
        }
    }
}