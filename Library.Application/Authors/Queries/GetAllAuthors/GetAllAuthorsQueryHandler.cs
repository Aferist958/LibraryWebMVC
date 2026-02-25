using MediatR;
using AutoMapper;
using Library.Domain.Interfaces.Repositories;
using Library.Application.DTOs;

namespace Library.Application.Authors.Queries.GetAllAuthors
{
    public class GetAllAuthorsQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
        : IRequestHandler<GetAllAuthorsQuery, IEnumerable<AuthorWithBooksDto>>
    {
        private readonly IAuthorRepository _authorRepository = authorRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<AuthorWithBooksDto>> Handle(GetAllAuthorsQuery request,
            CancellationToken cancellationToken)
        {
            var book = await _authorRepository.GetAllAuthors();
            
            return _mapper.Map<IEnumerable<AuthorWithBooksDto>>(book);
        }
    }
}