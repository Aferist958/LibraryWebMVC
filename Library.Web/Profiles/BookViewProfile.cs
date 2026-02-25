using AutoMapper;
using Library.Application.Books.Commands.CreateBook;
using Library.Application.Books.Commands.UpdateBook;
using Library.Application.DTOs;
using Library.Web.ViewModels;

namespace Library.Web.Profiles
{
    public class BookViewProfile : Profile
    {
        public BookViewProfile()
        {
            CreateMap<BookDto, BookViewModel>();
            CreateMap<BookDto, UpdateBookCommand>();
            CreateMap<BookViewModel, CreateBookCommand>();
            CreateMap<BookViewModel, UpdateBookCommand>();
        }
    }
}
