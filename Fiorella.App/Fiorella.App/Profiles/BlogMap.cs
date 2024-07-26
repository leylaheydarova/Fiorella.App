using AutoMapper;
using Fiorella.App.Dtos.Blog;
using Fiorella.App.Models;

namespace Fiorella.App.Profiles
{
    public class BlogMap:Profile
    {
        public BlogMap()
        {
            CreateMap<BlogPostDto, Blog>();
            CreateMap<BlogUpdateDto, Blog>();
            CreateMap<Blog, BlogGetDto>();

        }
    }
}
