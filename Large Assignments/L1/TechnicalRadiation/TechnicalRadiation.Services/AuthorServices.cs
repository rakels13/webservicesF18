using System;
using System.Collections.Generic;
using System.Dynamic;
using TechnicalRadiation.Models.DetailDtos;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.Extensions;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Repositories;

namespace TechnicalRadiation.Services
{
    public class AuthorServices
    {
        private readonly AuthorRepository _authorRepository = new AuthorRepository();
        private readonly NewsServices _newsServices = new NewsServices();
        public IEnumerable<AuthorDto> GetAllAuthors()
        {
            IEnumerable<AuthorDto> authors = _authorRepository.GetAllAuthors();
            foreach (var a in authors)
            {
                AddReferenceLinks(a);
            }
            return authors;
        }

    	public void AddReferenceLinks(AuthorDto author)
        {
            ExpandoObject newLink = new ExpandoObject();
            newLink.AddReference("href", $"api/authors/{author.Id}");
            author.Links.AddReference("self", newLink);
            author.Links.AddReference("edit", newLink);
            author.Links.AddReference("delete", newLink);
        
            ExpandoObject newsLink = new ExpandoObject();
            newsLink.AddReference("href", $"api/authors/{author.Id}/newsItems");
            author.Links.AddReference("newsItems", newsLink);

            IEnumerable<NewsItemDto> newsByAuthor = GetNewsByAuthorId(author.Id);
            List<ExpandoObject> newsDetailed = new List<ExpandoObject>();
            foreach(var n in newsByAuthor)
            {
                ExpandoObject newNewsLink = new ExpandoObject();
                newNewsLink.AddReference("href", $"api/{n.Id}");
                newsDetailed.Add(newNewsLink);
            }
            author.Links.AddReference("newsItemsDetailed", newsDetailed);
            
        }
        public AuthorDetailDto GetAuthorById(int id)
        {
	        var author = _authorRepository.GetAuthorById(id);
            if (author == null) { throw new Exception($"Author with id {id} was not found."); }
            ExpandoObject newLink = new ExpandoObject();
            newLink.AddReference("href", $"api/authors/{author.Id}");
            author.Links.AddReference("self", newLink);
            author.Links.AddReference("edit", newLink);
            author.Links.AddReference("delete", newLink);
        
            ExpandoObject newsLink = new ExpandoObject();
            newsLink.AddReference("href", $"api/authors/{author.Id}/newsItems");
            author.Links.AddReference("newsItems", newsLink);

            IEnumerable<NewsItemDto> newsByAuthor = GetNewsByAuthorId(author.Id);

            List<ExpandoObject> newsDetailed = new List<ExpandoObject>();
            foreach(var n in newsByAuthor)
            {
                ExpandoObject newNewsLink = new ExpandoObject();
                newNewsLink.AddReference("href", $"api/{n.Id}");
                newsDetailed.Add(newNewsLink);
            }
            author.Links.AddReference("newsItemsDetailed", newsDetailed);
            return author;
        }

        public IEnumerable<NewsItemDto> GetNewsByAuthorId(int id)
        {
            IEnumerable<NewsItemDto> newsByAuthor = _authorRepository.GetNewsByAuthorId(id);
            foreach (var n in newsByAuthor)
            {
                _newsServices.AddReferenceLinks(n);
            }
            return newsByAuthor;
	        
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