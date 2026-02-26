using AutoMapper;
using Library.Domain.Entities;
using Library.Application.DTOs;
using Library.Application.Resolvers;
using Library.Application.Books.Commands.CreateBook;
using Library.Application.Books.Commands.UpdateBook;

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
            CreateMap<CreateBookCommand, Book>()
                .ForMember(dest => dest.Authors,
                opt => opt
                    .MapFrom<CreateAuthorsIdToAuthorsResolver>());
            CreateMap<UpdateBookCommand, Book>()
               .ForMember(dest => dest.Authors,
                   opt => opt
                       .MapFrom<UpdateAuthorsIdToAuthorsResolver>());
            CreateMap<BookDto, UpdateBookCommand>();
        }
    }
}
