using AutoMapper;
using Library.Application.DTOs;
using Library.Application.Resolvers;
using Library.Domain.Entities;

namespace Library.Application.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>()
               .ForMember(dest => dest.AuthorsId, opt => opt.MapFrom(src => src.Authors.Select(a => a.Id)));
            CreateMap<BookDto, Book>()
               .ForMember(dest => dest.Authors, opt => opt.MapFrom<AuthorsIdToAuthorsResolver>());
        }
    }
}
