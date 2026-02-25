namespace Library.Application.DTOs
{
    public class BookWithAuthorsDto
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }

        public IEnumerable<AuthorWithBooksDto> Authors { get; set; } = [];

        public int YearOfPublication { get; set; }

        public int Quantity { get; set; }
        
        public override string ToString()
        {
            return $"{Title} \"{string.Join(", ", Authors.Select(a => a.ToString()))}\"";
        }
    }    
}

