using MediatR;
using Library.Application.DTOs;

namespace Library.Application.Authors.Queries.GetAllAuthors
{
    public class GetAllAuthorsQuery : IRequest<IEnumerable<AuthorWithBooksDto>>
    {
    
    }
}