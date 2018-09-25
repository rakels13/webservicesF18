using System;
using System.Collections.Generic;
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
		    // hérna þyrfti samt paging að gerast....
            //if(pageSize == );
            return _newsRepository.GetAllNews(pageSize, pageNumber);
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
            _newsRepository.DeleteNewsItem(id);
        }
    }
}