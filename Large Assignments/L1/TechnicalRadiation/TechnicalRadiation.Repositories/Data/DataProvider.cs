using System;
using System.Collections.Generic;
using TechnicalRadiation.Models.Entities;

namespace TechnicalRadiation.Repositories.Data
{
    public class DataProvider
    {
        private static readonly string _adminName = "NewsItemAdmin";
        private static List<NewsItem> _newsItem = new List<NewsItem> 
        {
            new NewsItem
            {
                Id = 1,
                Title = "Blablabla",
                ImgSource = "", //finna url
                ShortDescription = "Lorem ipsum...",
                LongDescription = "Lorem Ipsum..........",
                PublishDate = DateTime.Parse("23/09/2018")
            },
            new NewsItem
            {
                Id = 2,
                Title = "Blablabla",
                ImgSource = "", //finna url
                ShortDescription = "Lorem ipsum...",
                LongDescription = "Lorem Ipsum..........",
                PublishDate = DateTime.Parse("23/09/2018")
            },
            new NewsItem
            {
                Id = 3,
                Title = "Blablabla",
                ImgSource = "", //finna url
                ShortDescription = "Lorem ipsum...",
                LongDescription = "Lorem Ipsum..........",
                PublishDate = DateTime.Parse("23/09/2018")
            },
            new NewsItem
            {
                Id = 4,
                Title = "Blablabla",
                ImgSource = "", //finna url
                ShortDescription = "Lorem ipsum...",
                LongDescription = "Lorem Ipsum..........",
                PublishDate = DateTime.Parse("23/09/2018")
            },
            new NewsItem
            {
                Id = 5,
                Title = "Blablabla",
                ImgSource = "", //finna url
                ShortDescription = "Lorem ipsum...",
                LongDescription = "Lorem Ipsum..........",
                PublishDate = DateTime.Parse("23/09/2018")
            },

        };
        public static List<NewsItem> Models { get => _newsItem; set => _newsItem = value; }

        private static List<Author> _author = new List<Author> 
        {
            new Author
            {
                Id = 1,
                Name = "Bla blablason",
                ProfileImgSource = "", // finna url
                Bio = "Lorem ipsum ...",
                ModifiedBy = _adminName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },

        };

        public static List<Author> Authors { get => _author; set => _author = value; }

        private static List<Category> _category = new List<Category> 
        {
            new Category
            {
                Name = "",
                Slug = "",
                ParentCategoryId = 0,
                ModifiedBy = _adminName,
                ModifiedDate = DateTime.Now
            }
        };

        public static List<Category> Categories { get => _category; set => _category = value; }

    }
}