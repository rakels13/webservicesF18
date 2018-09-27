using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using TechnicalRadiation.Models;
using TechnicalRadiation.Models.DetailDtos;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Models.Extensions;
using TechnicalRadiation.Repositories;


namespace TechnicalRadiation.Services
{
    public class NewsServices
    {
        private readonly NewsRepository _newsRepository = new NewsRepository();

        public Envelope<NewsItemDto> GetAllNews(int pageSize, int pageNumber)
        {
            if(pageSize == 0)
            {
                pageSize = 25;   
            }
            if(pageNumber == 0)
            {
                pageNumber = 1;
            }
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

            AddReferenceLinks(items);
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
                
                var newLink = new ExpandoObject();
                m.Links.AddReference("href", $"/api/{m.Id}");

                m.Links.AddReference("self", $"{newLink}");
            }
        }

        public NewsItemDetailDto GetNewsById(int id)
        {
		    var news = _newsRepository.GetNewsById(id);
            if (news == null) { throw new Exception($"NewsItem with id {id} was not found."); }
            return news;
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
    }
}