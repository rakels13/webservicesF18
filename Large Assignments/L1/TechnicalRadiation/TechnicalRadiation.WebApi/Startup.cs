using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TechnicalRadiation.Models.DetailDtos;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.WebApi.Resolvers;

namespace TechnicalRadiation.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            AutoMapper.Mapper.Initialize(cfg => {
                cfg.CreateMap<NewsItem, NewsItemDto>();
                cfg.CreateMap<NewsItemDto, NewsItem>();
                cfg.CreateMap<NewsItem, NewsItemDetailDto>();
                cfg.CreateMap<NewsItemDetailDto, NewsItem>();
                cfg.CreateMap<NewsItemInputModel, NewsItem>()
                    .ForMember(m => m.CreatedDate, opt => opt.UseValue(DateTime.Now))
                    .ForMember(m => m.ModifiedDate, opt => opt.UseValue(DateTime.Now))
                    .ForMember(m => m.ModifiedBy, opt => opt.UseValue("NewsAdmin"));
                cfg.CreateMap<Category, CategoryDto>()
                    .ForMember(m => m.Slug, opt => opt.ResolveUsing<SlugResolver>());
                cfg.CreateMap<CategoryDto, Category>();
                cfg.CreateMap<Category, CategoryDetailDto>()
                    .ForMember(m => m.Slug, opt => opt.ResolveUsing<SlugResolverDetail>());
                cfg.CreateMap<CategoryDetailDto, Category>();
                cfg.CreateMap<CategoryInputModel, Category>()
                    .ForMember(m => m.CreatedDate, opt => opt.UseValue(DateTime.Now))
                    .ForMember(m => m.ModifiedDate, opt => opt.UseValue(DateTime.Now))
                    .ForMember(m => m.ModifiedBy, opt => opt.UseValue("NewsAdmin"));
                cfg.CreateMap<Author, AuthorDto>();
                cfg.CreateMap<AuthorDto, Author>();
                cfg.CreateMap<Author, AuthorDetailDto>();
                cfg.CreateMap<AuthorDetailDto, Author>();
                cfg.CreateMap<AuthorInputModel, Author>()
                    .ForMember(m => m.CreatedDate, opt => opt.UseValue(DateTime.Now))
                    .ForMember(m => m.ModifiedDate, opt => opt.UseValue(DateTime.Now))
                    .ForMember(m => m.ModifiedBy, opt => opt.UseValue("NewsAdmin"));

            });
        }
    }
}
