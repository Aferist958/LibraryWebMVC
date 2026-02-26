using MediatR;
using AutoMapper;
using Library.Application.Authors.Commands.CreateAuthor;
using Library.Application.Authors.Commands.DeleteAuthor;
using Library.Application.Authors.Commands.UpdateAuthor;
using Library.Application.DTOs;
using Library.Application.Interfaces.Services;
using Library.Application.Authors.Queries.GetAllAuthors;
using Library.Application.Books.Queries.GetAllBooks;
using Library.Application.Authors.Queries.GetAuthor;
using Library.Application.Books.Commands.CreateBook;
using Library.Application.Books.Commands.UpdateBook;
using Library.Application.Books.Commands.DeleteBook;
using Library.Application.Books.Queries.GetBook;
using Library.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    public class HomeController(IBookService bookService, IAuthorService authorService, IMapper mapper, IMediator mediator)
        : Controller
    {
        private readonly IBookService _bookService = bookService;
        private readonly IAuthorService _authorService = authorService;
        private readonly IMapper _mapper = mapper;
        private readonly IMediator _mediator = mediator;
        
        [HttpPost]
        public async Task<IActionResult> SearchBook(string search)
        {
            try
            {
                ViewBag.Search = search;
                IEnumerable<BookWithAuthorsDto> books = await _mediator.Send(new GetAllBooksQuery());
                IEnumerable<AuthorWithBooksDto> authors = await  _mediator.Send(new GetAllAuthorsQuery());
                List<BookWithAuthorsDto> searchResult = await _bookService.SearchBooksService(search, books);
                
                BookManagementViewModel viewModel = new BookManagementViewModel()
                    { Books = searchResult, Authors = authors };
                
                return View("Book", viewModel);
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Book(Guid? id)
        {
            try
            {
                if (id.HasValue)
                {
                    BookDto book = await _mediator.Send(new GetBookQuery {
                        Id = id.Value
                    });

                    return Json(book);
                }
                IEnumerable<BookWithAuthorsDto> books = await _mediator.Send(new GetAllBooksQuery());
                IEnumerable<AuthorWithBooksDto> authors = await _mediator.Send(new GetAllAuthorsQuery());
                
                BookManagementViewModel viewModel = new BookManagementViewModel() { Books = books, Authors = authors };
                
                return View(viewModel);
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Book(BookViewModel book, Guid? id)
        {
            try
            {
                if (id.HasValue)
                {
                    await _mediator.Send(new DeleteBookCommand()
                    {
                        Id = id.Value
                    });
                }
                else if (book.Id == Guid.Empty)
                {
                    CreateBookCommand createBookCommand = _mapper.Map<CreateBookCommand>(book);
                    await _mediator.Send(createBookCommand);
                }
                else
                {
                    UpdateBookCommand updateBookCommand = _mapper.Map<UpdateBookCommand>(book);
                    await _mediator.Send(updateBookCommand);
                }
                return RedirectToAction("Book");
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> IssueBook(Guid id)
        {
            try
            {
                BookDto book = await _mediator.Send(new GetBookQuery()
                {
                    Id = id
                });
                await _bookService.IssueBook(book);
                
                return RedirectToAction("Book");
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ReturnBook(Guid id)
        {
            try
            {
                BookDto book = await _mediator.Send(new GetBookQuery()
                {
                    Id = id
                });
                await _bookService.ReturnBook(book);
                
                return RedirectToAction("Book");
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> SearchAuthor(string search)
        {
            try
            {
                ViewBag.Search = search;
                IEnumerable<AuthorWithBooksDto> authors = await _mediator.Send(new GetAllAuthorsQuery());
                IEnumerable<BookWithAuthorsDto> books = await _mediator.Send(new GetAllBooksQuery());
                List<AuthorWithBooksDto> searchResult = await _authorService.SearchAuthorsService(search, authors);
                
                AuthorManagementViewModel viewModel = new AuthorManagementViewModel() { Books = books, Authors = searchResult };
                
                return View("Author", viewModel);
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }
          

        [HttpGet]
        public async Task<IActionResult> Author(Guid? id)
        {
            try
            {
                if (id.HasValue)
                {
                    AuthorDto author = await _mediator.Send(new GetAuthorQuery()
                    {
                        Id = id.Value
                    });

                    return Json(author);
                }
                IEnumerable<BookWithAuthorsDto> books = await _mediator.Send(new GetAllBooksQuery());
                IEnumerable<AuthorWithBooksDto> authors = await _mediator.Send(new GetAllAuthorsQuery());
                
                AuthorManagementViewModel viewModel = new AuthorManagementViewModel() { Books = books, Authors = authors };
                
                return View(viewModel);
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Author(AuthorViewModel author, Guid? id)
        {
            try
            {
                if (id.HasValue)
                {
                    await _mediator.Send(new DeleteAuthorCommand()
                    {
                        Id = id.Value
                    });
                }
                else if (author.Id == Guid.Empty)
                {
                    CreateAuthorCommand createAuthorCommand = _mapper.Map<CreateAuthorCommand>(author);
                    await _mediator.Send(createAuthorCommand);
                }
                else
                {
                    UpdateAuthorCommand updateAuthorCommand = _mapper.Map<UpdateAuthorCommand>(author);
                    await _mediator.Send(updateAuthorCommand);
                }
                return RedirectToAction("Author");
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
