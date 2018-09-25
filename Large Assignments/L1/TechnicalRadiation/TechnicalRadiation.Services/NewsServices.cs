using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using TechnicalRadiation.Models;
using TechnicalRadiation.Models.DetailDtos;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Repositories;

namespace TechnicalRadiation.Services
{
    public class NewsServices
    {
        private readonly NewsRepository _newsRepository = new NewsRepository();

        public IEnumerable<NewsItemDto> GetAllNews(int pageSize, int pageNumber)
        {
		    if(pageSize == null)
            {
                pageSize = 25;
                pageNumber = 1;
            }
            return _newsRepository.GetAllNews(pageSize, pageNumber);
        }

        public Envelope<NewsItemDto> GetNewsToEnvelope(int pageSize, int pageNumber)
        {
            /*Total count of models in DataContext */
            decimal newsCount = _newsRepository.GetNewsItemCount();
            /*Calculating maximum pages */
            int maxPages = (int)(Math.Ceiling(newsCount/pageSize));
            /*Calculating how many models are in the beginning of the list before the ones we want */
            int pagesToSkip = (pageNumber-1)*pageSize;

            /*Constructing the ModelDTO list of models */
            IEnumerable<NewsItemDto> newsItems = _newsRepository.GetAllNews(pageSize, pageNumber);

            /*Selecting the models to put in the envelope */
            var items = newsItems.Skip(pagesToSkip).Take(pageSize).ToList();

            /*Adding _links reference to each model */
            /*foreach (var mod in items){
                mod.Links.AddReference("self",string.Format("http://localhost:5000/api/tinysoldiers/{0}", mod.Id));
            }
            */
            /*Constructing the envelope */
            var envelope = new Envelope<NewsItemDto>() 
            {
                Items = items,
                PageSize = pageSize,
                PageNumber = pageNumber,
                MaxPages = maxPages
            };
            return envelope;
        }

        public void AddReferenceLinks(IEnumerable<NewsItemDto> newsItem)
        {
            foreach (var m in newsItem){
                m.Links.AddReference("self", $"api/{m.Id}")
            }
        }

        public NewsItemDetailDto GetNewsById(int id)
        {
		    var news = _newsRepository.GetNewsById(id);
            if (news == null) { throw new Exception($"NewsItem with id {id} was not found."); }
            return news;
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
	        return _newsRepository.GetAllCategories();
        }

        public CategoryDetailDto GetCategoryById(int id)
        {
	        var category = _newsRepository.GetCategoryById(id);
            if (category == null) { throw new Exception($"Category with id {id} was not found."); }
            return category;
        }

        public IEnumerable<AuthorDto> GetAllAuthors()
        {
	        return _newsRepository.GetAllAuthors();
        }

        public AuthorDetailDto GetAuthorById(int id)
        {
	        var author = _newsRepository.GetAuthorById(id);
            if (author == null) { throw new Exception($"Author with id {id} was not found."); }
            return author;
        }

        public IEnumerable<NewsItemDto> GetNewsByAuthorId(int id)
        {
	        return _newsRepository.GetNewsByAuthorId(id);
        }

        public int CreateNewsItem(NewsItemInputModel newsItem)
        {
            return _newsRepository.CreateNewsItem(newsItem);
        }

        public void UpdateNewsById(NewsItemInputModel newsItem, int id)
        {
            var entity = _newsRepository.GetNewsById(id);
            if (entity == null) { throw new Exception($"NewsItem with id {id} was not found."); }
            _newsRepository.UpdateNewsById(newsItem, id);
        }

        public void DeleteNewsById(int id)
        {
            //var entity = _newsRepository.GetNewsById(id);
            //if (entity == null) { throw new Exception($"NewsItem with id {id} was not found."); }
            _newsRepository.DeleteNewsItem(id);
        }

        public int CreateCategory(CategoryInputModel category)
        {
            return _newsRepository.CreateCategory(category);
        }

        public void UpdateCategoryById(CategoryInputModel category, int id)
        {
            var entity = _newsRepository.GetCategoryById(id);
            if (entity == null) { throw new Exception($"Category with id {id} was not found."); }
            _newsRepository.UpdateCategoryById(category, id);
        }

        public void DeleteCategoryById(int id)
        {
            //var entity = _newsRepository.GetNewsById(id);
            //if (entity == null) { throw new Exception($"NewsItem with id {id} was not found."); }
            _newsRepository.DeleteCategory(id);
        }

         public int CreateAuthor(AuthorInputModel author)
        {
            return _newsRepository.CreateAuthor(author);
        }

        public void UpdateAuthorById(AuthorInputModel author, int id)
        {
            var entity = _newsRepository.GetAuthorById(id);
            if (entity == null) { throw new Exception($"Author with id {id} was not found."); }
            _newsRepository.UpdateAuthorById(author, id);
        }

        public void DeleteAuthorById(int id)
        {
            //var entity = _newsRepository.GetNewsById(id);
            //if (entity == null) { throw new Exception($"NewsItem with id {id} was not found."); }
            _newsRepository.DeleteAuthor(id);
        }
    }
}