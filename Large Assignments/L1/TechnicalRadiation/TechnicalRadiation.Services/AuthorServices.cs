using System;
using System.Collections.Generic;
using TechnicalRadiation.Models.DetailDtos;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Repositories;

namespace TechnicalRadiation.Services
{
    public class AuthorServices
    {
        private readonly AuthorRepository _authorRepository = new AuthorRepository();
        public IEnumerable<AuthorDto> GetAllAuthors()
        {
	        return _authorRepository.GetAllAuthors();
        }

        public AuthorDetailDto GetAuthorById(int id)
        {
	        var author = _authorRepository.GetAuthorById(id);
            if (author == null) { throw new Exception($"Author with id {id} was not found."); }
            return author;
        }

        public IEnumerable<NewsItemDto> GetNewsByAuthorId(int id)
        {
	        return _authorRepository.GetNewsByAuthorId(id);
        }

        public int CreateAuthor(AuthorInputModel author)
        {
            return _authorRepository.CreateAuthor(author);
        }

        public void UpdateAuthorById(AuthorInputModel author, int id)
        {
            var entity = _authorRepository.GetAuthorById(id);
            if (entity == null) { throw new Exception($"Author with id {id} was not found."); }
            _authorRepository.UpdateAuthorById(author, id);
        }

        public void DeleteAuthorById(int id)
        {
            //var entity = _newsRepository.GetNewsById(id);
            //if (entity == null) { throw new Exception($"NewsItem with id {id} was not found."); }
            _authorRepository.DeleteAuthor(id);
        }

        public void LinkNewsToAuthor(int authorId, int newsItemId)
        {
            //? gæti samt átt að vera frekar hér að tékka hvort id-in séu valid
            _authorRepository.LinkNewsToAuthor(authorId, newsItemId);
        }
    }
}