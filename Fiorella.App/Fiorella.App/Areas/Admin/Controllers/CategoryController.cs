using AutoMapper;
using Fiorella.App.Context;
using Fiorella.App.Dtos.Category;
using Fiorella.App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorella.App.areas.Admin.Controllers
{
    [Area("admin")]
    public class CategoryController : Controller
    {
        private readonly FiorellaDbContext _context;
        private readonly IMapper _mapper;
        public CategoryController(FiorellaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //IEnumerable<Category> categories = await _context.Categories.Where(x => !x.IsDeleted).ToListAsync();
            //return View(categories);
            var query = _context.Categories.Where(x => !x.IsDeleted).AsQueryable();
            List<CategoryGetDto> categories = new List<CategoryGetDto>();
            categories = await query.Select(x => new CategoryGetDto { Name = x.Name, Id = x.Id }).ToListAsync();
            return View(categories);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] CategoryPostDto dto)
        {

            if (_context.Categories.Any(x => !x.IsDeleted && x.Name.ToLower() == dto.Name.ToLower()))
            {
                ModelState.AddModelError(nameof(dto.Name), "Name is already exists");

                return View();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            Category category = _mapper.Map<Category>(dto);
            category.Createdat = DateTime.Now;
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Category? category = await _context.Categories.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            CategoryUpdateDto dto = new CategoryUpdateDto()
            {
                Name = category.Name,
            };
            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] CategoryUpdateDto dto)
        {

            Category? category = await _context.Categories.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            category.Name = dto.Name;
            category.Updatedat = DateTime.Now;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            Category? category = await _context.Categories.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            category.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
