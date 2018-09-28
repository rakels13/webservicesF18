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
    public class AuthorRepository
    {
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
		    return Mapper.Map<IEnumerable<NewsItemDto>>(DataProvider.NewsItems.Where(n => n.AuthorId == id));
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

        public void LinkNewsToAuthor(int authorId, int newsItemId)
        {
            //? hvort það þurfi ekki tékk að þetta sé valid id bæði...
            var newsToLink = DataProvider.NewsItems.FirstOrDefault(n => n.Id == newsItemId);
            newsToLink.AuthorId = authorId;
        }
    }
}