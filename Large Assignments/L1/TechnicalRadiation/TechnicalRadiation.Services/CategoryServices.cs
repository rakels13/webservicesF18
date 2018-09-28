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
    public class CategoryServices
    {
        private readonly CategoryRepository _categoryRepository = new CategoryRepository();
         public IEnumerable<CategoryDto> GetAllCategories()
        {
            IEnumerable<CategoryDto> categories = _categoryRepository.GetAllCategories();
            foreach (var c in categories)
            {
                AddReferenceLinks(c);
            }
            return categories;
        }

        public CategoryDetailDto GetCategoryById(int id)
        {
	        var category = _categoryRepository.GetCategoryById(id);
            if (category == null) { throw new Exception($"Category with id {id} was not found."); }
            ExpandoObject newLink = new ExpandoObject();
            newLink.AddReference("href", $"api/categories/{category.Id}");
            category.Links.AddReference("self", newLink);
            category.Links.AddReference("edit", newLink);
            category.Links.AddReference("delete", newLink);
            return category;
        }

        public void AddReferenceLinks(CategoryDto category)
        {
            ExpandoObject newLink = new ExpandoObject();
            newLink.AddReference("href", $"api/categories/{category.Id}");
            category.Links.AddReference("self", newLink);
            category.Links.AddReference("edit", newLink);
            category.Links.AddReference("delete", newLink);
            
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