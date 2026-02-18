
namespace Library.Domain.Entities
{
    public class Book
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public List<Author> Authors { get; set; } = [];

        public int YearOfPublication { get; set; }

        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"{Title} \"{string.Join(", ", Authors.Select(a => a.ToString()))}\"";
        }
    }
}
