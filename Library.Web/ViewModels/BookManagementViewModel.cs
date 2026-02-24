using Library.Application.DTOs;

namespace Library.Web.ViewModels
{
    public class BookManagementViewModel
    {
        public BookViewModel Book { get; set; } = new BookViewModel();
        public IEnumerable<BookWithAuthorsDto> Books { get; set; } = new List<BookWithAuthorsDto>();
        public IEnumerable<AuthorWithBooksDto> Authors { get; set; } = new List<AuthorWithBooksDto>();
    }
}
