using AutoMapper;
using Library.Application.DTOs;
using Library.Web.ViewModels;

namespace Library.Web.Profiles
{
    public class BookViewProfile : Profile
    {
        public BookViewProfile()
        {
            CreateMap<BookDto, BookViewModel>();
            CreateMap<BookViewModel, BookDto>();
        }
    }
}
