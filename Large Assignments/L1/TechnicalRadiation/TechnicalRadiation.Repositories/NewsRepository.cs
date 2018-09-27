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
    }
}