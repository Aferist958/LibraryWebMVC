using AutoMapper;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using Library.Application.Interfaces.Services;
using Library.Application.DTOs;

namespace Library.Application.Services
{
    // public class AuthorService : IAuthorService
    // {
    //     private readonly IAuthorRepository _authorRepository;
    //     private readonly IMapper _mapper;
    //
    //     public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
    //     {
    //         _authorRepository = authorRepository;
    //         _mapper = mapper;
    //     }
    //     public IEnumerable<Author> GetAllAuthors()
    //     {
    //         return _authorRepository.GetAllAuthors();
    //     }
    //
    //     public AuthorDto? GetAuthor(Guid id)
    //     {
    //         var author = _authorRepository.GetAuthor(id);
    //         return _mapper.Map<AuthorDto>(author);
    //     }
    //
    //     public void AddAuthor(AuthorDto dto)
    //     {
    //         dto.Description = dto.Description ?? "";
    //         var author = _mapper.Map<Author>(dto);
    //         _authorRepository.AddAuthor(author);
    //     }
    //
    //     public void UpdateAuthor(AuthorDto dto)
    //     {
    //         dto.Description = dto.Description ?? "";
    //         var author = _authorRepository.GetAuthor(dto.Id);
    //         _mapper.Map(dto, author);
    //         _authorRepository.UpdateAuthor(author);
    //     }
    //
    //     public void DeleteAuthor(Guid id)
    //     {
    //         _authorRepository.DeleteAuthor(id);
    //     }
    // }
}
