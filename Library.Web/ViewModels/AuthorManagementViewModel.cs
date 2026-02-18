using Library.Domain.Entities;

namespace Library.Web.ViewModels
{
    public class AuthorManagementViewModel
    {
        public AuthorViewModel Author { get; set; } = new AuthorViewModel();
        public IEnumerable<Book> Books { get; set; } = new List<Book>();
        public IEnumerable<Author> Authors { get; set; } = new List<Author>();
    }
}
