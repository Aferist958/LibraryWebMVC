using MediatR;

namespace Library.Application.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}