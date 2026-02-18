namespace Library.Web.ViewModels
{
    public class AuthorViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public List<Guid> BooksId { get; set; } = [];
    }
}
