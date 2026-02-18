using Library.Domain.Entities;

namespace Library.Web.ViewModels
{
    public class BookManagementViewModel
    {
        public BookViewModel Book { get; set; } = new BookViewModel();
        public IEnumerable<Book> Books { get; set; } = new List<Book>();
        public IEnumerable<Author> Authors { get; set; } = new List<Author>();
    }
}
