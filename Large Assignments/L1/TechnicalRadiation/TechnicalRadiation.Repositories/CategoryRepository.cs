using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TechnicalRadiation.Models.DetailDtos;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Repositories.Data;

namespace TechnicalRadiation.Repositories
{
    public class CategoryRepository
    {
        public IEnumerable<CategoryDto> GetAllCategories()
        {
	         return Mapper.Map<IEnumerable<CategoryDto>>(DataProvider.Categories);
        }

        public CategoryDetailDto GetCategoryById(int id)
        {
            return Mapper.Map<CategoryDetailDto>(DataProvider.Categories.FirstOrDefault(c => c.Id == id));
        }

         public int CreateCategory(CategoryInputModel category)
        {
            var nextId = DataProvider.Categories.Count() + 1;
            var entity = Mapper.Map<Category>(category);
            entity.Id = nextId;
            DataProvider.Categories.Add(entity);
            return nextId;
        }

        public void UpdateCategoryById(CategoryInputModel category, int id)
        {
            var updateCategory = DataProvider.Categories.FirstOrDefault(c => c.Id == id);

            if (updateCategory == null) { return; /* Throw some exception */ }

            // updating category 
            updateCategory.Name = category.Name;
            updateCategory.ParentCategoryId = category.ParentCategoryId;
            updateCategory.Slug = category.Slug;
            updateCategory.ModifiedDate = DateTime.Now;
        }

        public void DeleteCategory(int id)
        {
            //DataProvider.NewsItems.Remove(Mapper.Map<NewsItem>(newsItem));
            var element = DataProvider.Categories.FirstOrDefault(c => c.Id == id);
            //TODO vantar villumeðhöndlun!
            DataProvider.Categories.Remove(element);
        }

        public void LinkNewsToCategory(int categoryId, int newsItemId)
        {
            //? hvort það þurfi ekki tékk að þetta sé valid id bæði...
            var newsToLink = DataProvider.NewsItems.FirstOrDefault(n => n.Id == newsItemId);
            newsToLink.CategoryId = categoryId;
        }
    }
}