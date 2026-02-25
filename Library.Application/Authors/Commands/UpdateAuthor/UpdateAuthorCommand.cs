using MediatR;

namespace Library.Application.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public string? Description { get; set; }

        public IEnumerable<Guid> BooksId { get; set; } = [];
    }
}
