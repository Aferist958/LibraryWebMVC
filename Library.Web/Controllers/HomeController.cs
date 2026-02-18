using AutoMapper;
using Library.Application.DTOs;
using Library.Application.Interfaces.Services;
using Library.Domain.Entities;
using Library.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Library.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        public HomeController(IBookService bookService, IAuthorService authorService, IMapper mapper)
        {
            _bookService = bookService;
            _authorService = authorService;
            _mapper = mapper;
        }
        
        [HttpPost]
        public IActionResult SearchBook(string search)
        {
            try
            {
                ViewBag.Search = search;
                List<Book> searchResult = new List<Book>(_bookService.GetAllBooks().Count());
                IEnumerable<Book> books = _bookService.GetAllBooks();
                var authors = _authorService.GetAllAuthors();

                if (!string.IsNullOrEmpty(search))
                {
                        searchResult.AddRange(books
                            .Where(b => b.Title
                            .Contains(search, StringComparison.OrdinalIgnoreCase)));
                        searchResult.AddRange(books
                            .Where(b => b.Authors
                            .Any(a => a.Name
                            .Contains(search))));
                        if (int.TryParse(search, out int year))
                        {
                            searchResult.AddRange(books
                                .Where(b => b.YearOfPublication == year));
                        }
                        searchResult = searchResult
                            .DistinctBy(b => b.Id)
                            .ToList();
                }
                BookManagementViewModel viewModel = new BookManagementViewModel() { Books = searchResult, Authors = authors };
                return View("Book", viewModel);
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public IActionResult Book(Guid? id)
        {
            try
            {
                if (id.HasValue)
                {
                    var book = _bookService.GetBook(id.Value);

                    return Json(book);
                }
                var books = _bookService.GetAllBooks();
                var authors = _authorService.GetAllAuthors();
                BookManagementViewModel viewModel = new BookManagementViewModel() { Books = books, Authors = authors };
                return View(viewModel);
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Book(BookViewModel book, Guid? id)
        {
            try
            {
                if (id.HasValue)
                {
                    _bookService.DeleteBook(id.Value);
                }
                else if (book.Id == default(Guid))
                {
                    _bookService.AddBook(_mapper.Map<BookDto>(book));
                }
                else
                {
                    _bookService.UpdateBook(_mapper.Map<BookDto>(book));
                }
                return RedirectToAction("Book");
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult IssueBook(Guid id)
        {
            try
            {
                var book = _bookService.GetBook(id);
                if (book.Quantity > 0)
                {
                    book.Quantity--;
                    _bookService.UpdateBook(book);
                }
                return RedirectToAction("Book");
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult ReturnBook(Guid id)
        {
            try
            {
                var book = _bookService.GetBook(id);
                book.Quantity++;
                _bookService.UpdateBook(book);
                return RedirectToAction("Book");
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult SearchAuthor(string search)
        {
            try
            {
                ViewBag.Search = search;
                List<Author> searchResult = new List<Author>(_authorService.GetAllAuthors().Count());
                IEnumerable<Author> authors = _authorService.GetAllAuthors();
                var books = _bookService.GetAllBooks();
                if (!string.IsNullOrEmpty(search))
                {
                    searchResult.AddRange(authors
                        .Where(a => a.Name
                        .Contains(search, StringComparison.OrdinalIgnoreCase)));
                    searchResult.AddRange(authors
                        .Where(a => a.Description
                        .Contains(search, StringComparison.OrdinalIgnoreCase)));
                    searchResult.AddRange(authors
                        .Where(a => a.Books
                        .Any(b => b.Title
                        .Contains(search))));
                    if (int.TryParse(search, out int year))
                    {
                        searchResult.AddRange(authors
                            .Where(a => a.Books
                            .Any(b => b.YearOfPublication == year)));
                    }
                    searchResult = searchResult
                        .DistinctBy(a => a.Id)
                        .ToList();
                }
                AuthorManagementViewModel viewModel = new AuthorManagementViewModel() { Books = books, Authors = searchResult };
                return View("Author", viewModel);
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }
          

        [HttpGet]
        public IActionResult Author(Guid? id)
        {
            try
            {
                if (id.HasValue)
                {
                    var author = _authorService.GetAuthor(id.Value);

                    return Json(author);
                }
                var books = _bookService.GetAllBooks();
                var authors = _authorService.GetAllAuthors();
                AuthorManagementViewModel viewModel = new AuthorManagementViewModel() { Books = books, Authors = authors };
                return View(viewModel);
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Author(AuthorViewModel author, Guid? id)
        {
            try
            {
                if (id.HasValue)
                {
                    _authorService.DeleteAuthor(id.Value);
                }
                else if (author.Id == default(Guid))
                {
                    _authorService.AddAuthor(_mapper.Map<AuthorDto>(author));
                }
                else
                {
                    Console.WriteLine(string.Join(", ", author.BooksId));
                    _authorService.UpdateAuthor(_mapper.Map<AuthorDto>(author));
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
