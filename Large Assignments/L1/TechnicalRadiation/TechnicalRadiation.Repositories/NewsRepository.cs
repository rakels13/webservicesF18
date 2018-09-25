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
    public class NewsRepository
    {
        public IEnumerable<NewsItemDto> GetAllNews(int pageSize, int pageNumber)
        {
		    return Mapper.Map<IEnumerable<NewsItemDto>>(DataProvider.NewsItems);
        }

        public int GetNewsItemCount()
        {
            return DataProvider.NewsItems.Count();
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
            return Mapper.Map<CategoryDetailDto>(DataProvider.Categories.FirstOrDefault(c => c.Id == id));
        }

        public IEnumerable<AuthorDto> GetAllAuthors()
        {
	         return Mapper.Map<IEnumerable<AuthorDto>>(DataProvider.Authors);
        }

        public AuthorDetailDto GetAuthorById(int id)
        {
            return Mapper.Map<AuthorDetailDto>(DataProvider.Authors.FirstOrDefault(a => a.Id == id));
        }

        public IEnumerable<NewsItemDto> GetNewsByAuthorId(int id)
        {
            //TODO vantar filteringu!
		    return Mapper.Map<IEnumerable<NewsItemDto>>(DataProvider.NewsItems);
        }

        public int CreateNewsItem(NewsItemInputModel newsItem)
        {
            var nextId = DataProvider.NewsItems.Count() + 1;
            var entity = Mapper.Map<NewsItem>(newsItem);
            entity.Id = nextId;
            DataProvider.NewsItems.Add(entity);
            return nextId;
        }

        public void UpdateNewsById(NewsItemInputModel newsItem, int id)
        {
            var updateNews = DataProvider.NewsItems.FirstOrDefault(n => n.Id == id);

            if (updateNews == null) { return; /* Throw some exception */ }

            // updating newsItem 
            updateNews.Title = newsItem.Title;
            updateNews.ShortDescription = newsItem.ShortDescription;
            updateNews.LongDescription = newsItem.LongDescription;
            updateNews.ImgSource = newsItem.ImgSource;
            updateNews.ModifiedDate = DateTime.Now;
        }

        public void DeleteNewsItem(int id)
        {
            //DataProvider.NewsItems.Remove(Mapper.Map<NewsItem>(newsItem));
            var element = DataProvider.NewsItems.FirstOrDefault(n => n.Id == id);
            //TODO vantar villumeðhöndlun!
            DataProvider.NewsItems.Remove(element);
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

        
        public int CreateAuthor(AuthorInputModel author)
        {
            var nextId = DataProvider.Authors.Count() + 1;
            var entity = Mapper.Map<Author>(author);
            entity.Id = nextId;
            DataProvider.Authors.Add(entity);
            return nextId;
        }

        public void UpdateAuthorById(AuthorInputModel author, int id)
        {
            var updateAuthor = DataProvider.Authors.FirstOrDefault(a => a.Id == id);

            if (updateAuthor == null) { return; /* Throw some exception */ }

            updateAuthor.Name = author.Name;
            updateAuthor.ProfileImgSource = author.ProfileImgSource;
            updateAuthor.Bio = author.Bio;
        }

        public void DeleteAuthor(int id)
        {
            //DataProvider.NewsItems.Remove(Mapper.Map<NewsItem>(newsItem));
            var element = DataProvider.Authors.FirstOrDefault(a => a.Id == id);
            //TODO vantar villumeðhöndlun!
            DataProvider.Authors.Remove(element);
        }
    }
}