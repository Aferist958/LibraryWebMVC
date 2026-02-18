namespace Library.Domain.Entities
{
    public class Author
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Book> Books { get; set; } = [];

        public override string ToString()
        {
            return Name;
        }
    }
}
