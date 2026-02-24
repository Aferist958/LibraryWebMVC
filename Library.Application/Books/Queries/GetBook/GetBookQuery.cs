using MediatR;
using Library.Application.DTOs;

namespace Library.Application.Books.Queries.GetBook
{
    public class GetBookQuery : IRequest<BookDto>
    {
        public Guid Id { get; set; }
    }   
}