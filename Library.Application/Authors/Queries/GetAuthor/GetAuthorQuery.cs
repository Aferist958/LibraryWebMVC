using MediatR;
using Library.Application.DTOs;

namespace Library.Application.Authors.Queries.GetAuthor
{
    public class GetAuthorQuery : IRequest<AuthorDto>
    {
        public Guid Id { get; set; }
    }
}