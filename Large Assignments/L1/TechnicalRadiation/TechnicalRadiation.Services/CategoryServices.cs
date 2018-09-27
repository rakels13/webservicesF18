using System;
using System.Collections.Generic;
using TechnicalRadiation.Models.DetailDtos;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Repositories;

namespace TechnicalRadiation.Services
{
    public class CategoryServices
    {
        private readonly CategoryRepository _categoryRepository = new CategoryRepository();
         public IEnumerable<CategoryDto> GetAllCategories()
        {
	        return _categoryRepository.GetAllCategories();
        }

        public CategoryDetailDto GetCategoryById(int id)
        {
	        var category = _categoryRepository.GetCategoryById(id);
            if (category == null) { throw new Exception($"Category with id {id} was not found."); }
            return category;
        }

        public int CreateCategory(CategoryInputModel category)
        {
            return _categoryRepository.CreateCategory(category);
        }

        public void UpdateCategoryById(CategoryInputModel category, int id)
        {
            var entity = _categoryRepository.GetCategoryById(id);
            if (entity == null) { throw new Exception($"Category with id {id} was not found."); }
            _categoryRepository.UpdateCategoryById(category, id);
        }

        public void DeleteCategoryById(int id)
        {
            //var entity = _newsRepository.GetNewsById(id);
            //if (entity == null) { throw new Exception($"NewsItem with id {id} was not found."); }
            _categoryRepository.DeleteCategory(id);
        }

        public void LinkNewsToCategory(int categoryId, int newsItemId)
        {
            //? gæti samt átt að vera frekar hér að tékka hvort id-in séu valid
            _categoryRepository.LinkNewsToCategory(categoryId, newsItemId);
        }

    }
}