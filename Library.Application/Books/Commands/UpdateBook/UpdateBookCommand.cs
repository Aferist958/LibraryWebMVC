using MediatR;

namespace Library.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<Guid> AuthorsId { get; set; } = [];
        public int YearOfPublication { get; set; }
        public int Quantity { get; set; }
    }    
}

