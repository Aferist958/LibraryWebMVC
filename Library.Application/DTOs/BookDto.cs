namespace Library.Application.DTOs
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public IEnumerable<Guid> AuthorsId { get; set; } = [];

        public int YearOfPublication { get; set; }

        public int Quantity { get; set; }

    }
}
