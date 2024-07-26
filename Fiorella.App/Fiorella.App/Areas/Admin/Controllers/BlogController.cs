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
            ICollection<Blog> blogs = await _context.Blogs.Where(x=>!x.IsDeleted).ToListAsync();
            return View(blogs);
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
            Blog updatedblog = await _context.Blogs.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == id);
            if (updatedblog == null)
            {
                return NotFound();
            }
            if (dto.formFile != null)
            {
                updatedblog.Image = await dto.formFile.SaveFileAsync(_env.WebRootPath, updatedblog.Blogurl);
            }
            updatedblog.Title = dto.Title;
            updatedblog.Description = dto.Description;
            updatedblog.Updatedat = DateTime.Now;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Remove(int id)
        {
            Blog blog = await _context.Blogs.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == id);
            if (blog == null)
            {
                return NotFound();
            }
            blog.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
