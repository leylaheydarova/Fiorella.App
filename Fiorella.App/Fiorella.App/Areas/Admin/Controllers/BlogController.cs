using AutoMapper;
using Fiorella.App.Context;
using Fiorella.App.Dtos.Blog;
using Fiorella.App.Helpers;
using Fiorella.App.Extensions;
using Fiorella.App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Fiorella.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly FiorellaDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;

        public BlogController(FiorellaDbContext context, IMapper mapper, IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _env = env; 
        }

        public async Task<IActionResult> Index()
        {
            var query = _context.Blogs.Where(x => !x.IsDeleted).AsQueryable();
            List< BlogGetDto> dtos = new List<BlogGetDto>();
            dtos = await query.Select(x=> new BlogGetDto{ Id = x.Id, Title = x.Title, Description = x.Description}).ToListAsync();
            return View(dtos);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm]BlogPostDto dto)
        {
            Blog blog = _mapper.Map<Blog>(dto);
            blog.Image = await dto.formFile.SaveFileAsync(_env.WebRootPath, blog.Blogurl);
            blog.Createdat = DateTime.UtcNow;
            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            Blog blog = await _context.Blogs.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == id);
            if (blog == null)
            {
                return NotFound();
            }
            BlogUpdateDto dto = new BlogUpdateDto()
            {
                Title = blog.Title,
                Description = blog.Description,
            };
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, BlogUpdateDto dto)
        {
            Blog blog = await _context.Blogs.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == id);
            if (blog == null)
            {
                return NotFound();
            }

        }
    }
}
