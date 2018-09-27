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
                Title = "The future of being a woman in technology",
                ImgSource = "https://www.information-age.com/being-a-woman-in-technology-123474491/", 
                ShortDescription = "The glaring gender imbalance in the tech industry",
                LongDescription = "The glaring gender imbalance in the tech industry is there for all to see. Laura Malcolm, from Avanade, looks at the future of women in tech",
                PublishDate = DateTime.Parse("23/09/2018, 13:11:56"),
                AuthorId = 1,
                CategoryId =1,
            },
            new NewsItem
            {
                Id = 2,
                Title = "What’s Your Digital Transformation Starting Point?",
                ImgSource = "https://www.information-age.com/sponsored/?prx_t=hw8EAyJEqA_tkPA", 
                ShortDescription = "Did you know that your chances of surviving a heart attack are higher in Copenhagen, Denmark?",
                LongDescription = "Did you know that your chances of surviving a heart attack are higher in Copenhagen, Denmark? That’s because emergency dispatchers in Copenhagen now use a virtual agent to them help identify cardiac arrests. Although human dispatchers alone recognize cardiac arrests 73% of the time, initial data shows that the virtual agent plus a human dispatcher recognizes cardiac arrests 95% of the time. This is an example of how artificial intelligence (AI) can be a starting point for digital transformation that enables machines to deliver value for an organisation",
                PublishDate = DateTime.Parse("23/09/2018, 13:30:50"),
                AuthorId = 1,
                CategoryId =1,
            },
            new NewsItem
            {
                Id = 3,
                Title = "We are the champions: fighting cyber crime needs security champions",
                ImgSource = "https://www.information-age.com/fighting-cyber-crime-123475052/",
                ShortDescription = "Cyber crime is as much about people as it is about technology",
                LongDescription = "Cyber crime is as much about people as it is about technology — and fighting it requires people too, and darn good communication",
                PublishDate = DateTime.Parse("23/09/2018, 13:33:20"),
                AuthorId = 2,
                CategoryId =2,
            },
            new NewsItem
            {
                Id = 4,
                Title = "Phishing attacks — can AI help people provide a fix?",
                ImgSource = "https://www.information-age.com/phishing-attacks-can-ai-help-people-provide-a-fix-123475054/",
                ShortDescription = "AI isn’t quite like having a cyber security expert on your shoulder",
                LongDescription = "LAI isn’t quite like having a cyber security expert on your shoulder, but it could be the next best thing, Paul Bentham, co-founder of Surevine, told us.",
                PublishDate = DateTime.Parse("23/09/2018, 13:40:30"),
                AuthorId = 2,
                CategoryId =2,
            },
            new NewsItem
            {
                Id = 5,
                Title = "‘IoT is the fastest growing force affecting PKI planning and evolution’ – Thales",
                ImgSource = "https://www.information-age.com/iot-pki-planning-123475030/", 
                ShortDescription = "Rapid growth in the use of IoT devices is having an impact",
                LongDescription = "The Internet of Things is the fastest growing trend driving the deployment of applications that use PKI (public key infrastructure), ",
                PublishDate = DateTime.Parse("23/09/2018"),
                AuthorId = 1,
                CategoryId =1,
            },

        };
        public static List<NewsItem> NewsItems { get => _newsItem; set => _newsItem = value; }

        private static List<Author> _author = new List<Author> 
        {
            new Author
            {
                Id = 1,
                Name = "InformationAge",
                ProfileImgSource = "https://s26913.pcdn.co/wp-content/themes/wp-ia-theme/image/IA_NEW_LOGO_2018_RGB.png", 
                Bio = "InformationAge web page",
                ModifiedBy = _adminName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            },
            new Author
            {
                Id = 2,
                Name = "Michael Baxter",
                ProfileImgSource = "https://s26913.pcdn.co/wp-content/uploads/2018/09/IMG_1526-150x150.png", 
                Bio = "Cyber security",
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
                Id = 1,
                Name = "Technology News",
                Slug = "technology-news",
                ParentCategoryId = 0,
                ModifiedBy = _adminName,
                ModifiedDate = DateTime.Now
            },
            new Category
            {
                Id = 1,
                Name = "Cyber Security",
                Slug = "cyber-security",
                ParentCategoryId = 0,
                ModifiedBy = _adminName,
                ModifiedDate = DateTime.Now
            }
        };

        public static List<Category> Categories { get => _category; set => _category = value; }

    }
}