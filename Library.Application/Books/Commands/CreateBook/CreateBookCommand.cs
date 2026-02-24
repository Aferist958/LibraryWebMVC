using MediatR;

namespace Library.Application.Books.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public IEnumerable<Guid> AuthorsId { get; set; } = [];
        public int YearOfPublication { get; set; }
        public int Quantity { get; set; }
    }
}

