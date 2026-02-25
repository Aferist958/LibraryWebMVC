using MediatR;

namespace Library.Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<Guid>
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public IEnumerable<Guid> BooksId { get; set; } = [];
    }       
}