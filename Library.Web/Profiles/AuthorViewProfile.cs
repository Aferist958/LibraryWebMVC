using AutoMapper;
using Library.Application.Authors.Commands.CreateAuthor;
using Library.Application.Authors.Commands.UpdateAuthor;
using Library.Application.DTOs;
using Library.Web.ViewModels;

namespace Library.Web.Profiles
{
    public class AuthorViewProfile : Profile
    {
        public AuthorViewProfile()
        {
            CreateMap<AuthorDto, AuthorViewModel>();
            CreateMap<AuthorViewModel, CreateAuthorCommand>();
            CreateMap<AuthorViewModel, UpdateAuthorCommand>();
        }
    }
}
