using AutoMapper;
using Library.Domain.Entities;
using Library.Application.DTOs;
using Library.Application.Resolvers;
using Library.Application.Authors.Commands.CreateAuthor;
using Library.Application.Authors.Commands.UpdateAuthor;

namespace Library.Application.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile() 
        {
            CreateMap<Author, AuthorDto>()
               .ForMember(dest => dest.BooksId,
                   opt => opt
                       .MapFrom(src => src.Books.Select(a => a.Id)));
            CreateMap<Author, AuthorWithBooksDto>();
            CreateMap<CreateAuthorCommand, Author>()
                // .ForMember(dest => dest.Id,
                //     opt => opt
                //         .Ignore())
                .ForMember(dest => dest.Books,
                    opt => opt
                        .MapFrom<CreateBooksIdToBooksResolver>());
            CreateMap<UpdateAuthorCommand, Author>()
                .ForMember(dest => dest.Books,
                    opt => opt
                        .MapFrom<UpdateBooksIdToBooksResolver>());
        }
    }
}
