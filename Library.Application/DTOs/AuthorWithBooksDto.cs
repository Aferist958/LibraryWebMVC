namespace Library.Application.DTOs
{
    public class AuthorWithBooksDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public IEnumerable<BookWithAuthorsDto> Books { get; set; } = [];
        
        public override string ToString()
        {
            return Name;
        }
    }    
}