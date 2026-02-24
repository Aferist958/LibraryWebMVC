using AutoMapper;
using Library.Domain.Entities;
using Library.Application.Books.Commands.CreateBook;
using Library.Application.Books.Commands.UpdateBook;
using Library.Application.DTOs;
using Library.Application.Resolvers;

namespace Library.Application.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.AuthorsId,
                    opt => opt
                        .MapFrom(src => src.Authors.Select(a => a.Id)));
            CreateMap<Book, BookWithAuthorsDto>();
            CreateMap<CreateBookCommand, Book>();
            CreateMap<UpdateBookCommand, Book>()
               .ForMember(dest => dest.Authors,
                   opt => opt
                       .MapFrom<AuthorsIdToAuthorsResolver>());
            
        }
    }
}
