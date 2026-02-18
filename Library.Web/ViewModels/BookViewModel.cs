using Library.Application.DTOs;

namespace Library.Web.ViewModels
{
    public class BookViewModel()
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public List<Guid> AuthorsId { get; set; } = [];

        public int YearOfPublication { get; set; }

        public int Quantity { get; set; }

    }
}
