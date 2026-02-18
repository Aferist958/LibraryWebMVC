using AutoMapper;
using Library.Application.DTOs;
using Library.Application.Resolvers;
using Library.Domain.Entities;

namespace Library.Application.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile() 
        {
            CreateMap<Author, AuthorDto>()
               .ForMember(dest => dest.BooksId, opt => opt.MapFrom(src => src.Books.Select(a => a.Id)));
            CreateMap<AuthorDto, Author>()
               .ForMember(dest => dest.Books, opt => opt.MapFrom<BooksIdToBooksResolver>());
        }
    }
}
