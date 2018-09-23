using System;
using System.Collections.Generic;
using TechnicalRadiation.Models.DetailDtos;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Repositories;

namespace TechnicalRadiation.Services
{
    public class NewsServices
    {
        private readonly NewsRepository _newsRepository = new NewsRepository();

        public IEnumerable<NewsItemDto> GetAllNews(int pageSize, int pageNumber)
        {
		    // hérna þyrfti samt paging að gerast....
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
    }
}