using MediatR;
using Library.Application.DTOs;

namespace Library.Application.Books.Queries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<IEnumerable<BookWithAuthorsDto>>
    {
    
    }
}