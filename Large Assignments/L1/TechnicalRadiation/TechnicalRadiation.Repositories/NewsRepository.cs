using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.DetailDtos;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Repositories.Data;

namespace TechnicalRadiation.Repositories
{
    public class NewsRepository
    {
        public IEnumerable<NewsItemDto> GetAllNews(int pageSize, int pageNumber)
        {
		    // ? hvort þetta virki... þurfum aðeins að skoða
		    return Mapper.Map<IEnumerable<NewsItemDto>>(DataProvider.NewsItems);
        }

        public NewsItemDetailDto GetNewsById(int id)
        {
            return Mapper.Map<NewsItemDetailDto>(DataProvider.NewsItems.FirstOrDefault(n => n.Id == id));
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
	         return Mapper.Map<IEnumerable<CategoryDto>>(DataProvider.Categories);
        }

        public CategoryDetailDto GetCategoryById(int id)
        {
            return Mapper.Map<CategoryDetailDto>(DataProvider.Categories.FirstOrDefault(n => n.Id == id));
        }
    }
}