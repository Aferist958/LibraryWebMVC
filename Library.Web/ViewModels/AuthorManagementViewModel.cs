using Library.Application.DTOs;
using Library.Domain.Entities;

namespace Library.Web.ViewModels
{
    public class AuthorManagementViewModel
    {
        public AuthorViewModel Author { get; set; } = new AuthorViewModel();
        public IEnumerable<BookWithAuthorsDto> Books { get; set; } = new List<BookWithAuthorsDto>();
        public IEnumerable<AuthorWithBooksDto> Authors { get; set; } = new List<AuthorWithBooksDto>();
    }
}
