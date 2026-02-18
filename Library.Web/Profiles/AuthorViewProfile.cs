using AutoMapper;
using Library.Application.DTOs;
using Library.Web.ViewModels;

namespace Library.Web.Profiles
{
    public class AuthorViewProfile : Profile
    {
        public AuthorViewProfile()
        {
            CreateMap<AuthorDto, AuthorViewModel>();
            CreateMap<AuthorViewModel, AuthorDto>();
        }
    }
}
