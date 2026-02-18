using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.DTOs
{
    public class AuthorDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public IEnumerable<Guid> BooksId { get; set; } = [];
    }
}
