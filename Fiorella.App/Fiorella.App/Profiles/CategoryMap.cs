using AutoMapper;
using Fiorella.App.Dtos.Category;
using Fiorella.App.Models;

namespace Fiorella.App.Profiles
{
    public class CategoryMap:Profile
    {
        public CategoryMap()
        {
            CreateMap<CategoryPostDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryGetDto>();

        }
    }
}
