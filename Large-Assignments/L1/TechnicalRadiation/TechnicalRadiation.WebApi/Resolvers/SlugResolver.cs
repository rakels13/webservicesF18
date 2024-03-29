using AutoMapper;
using TechnicalRadiation.Models.DetailDtos;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.Entities;

namespace TechnicalRadiation.WebApi.Resolvers
{
    public class SlugResolver : IValueResolver<Category, CategoryDto, string>
    {
        public string Resolve(Category source, CategoryDto destination, string destMember, ResolutionContext context)
        {
            return source.Name.ToLower().Replace(" ", "-");
        }
    }

    public class SlugResolverDetail : IValueResolver<Category, CategoryDetailDto, string>
    {
        public string Resolve(Category source, CategoryDetailDto destination, string destMember, ResolutionContext context)
        {
            return source.Name.ToLower().Replace(" ", "-");
        }
    }
}