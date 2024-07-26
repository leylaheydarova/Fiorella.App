using AutoMapper;
using Fiorella.App.Context;
using Fiorella.App.Dtos.Category;
using Fiorella.App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorella.App.Areas.Admin.Controllers
    {
        [Area("Admin")]
        public class CategoryController : Controller
        {
            private readonly FiorellaDbContext _context;
            private readonly IMapper _mapper;

            public CategoryController(FiorellaDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IActionResult> Index()
            {
                var query = _context.Categories.Where(x => !x.IsDeleted).AsQueryable();
                List<CategoryGetDto> dtos = new List<CategoryGetDto>();
                dtos = await query.Select(x => new CategoryGetDto { Name = x.Name, Id = x.Id }).ToListAsync();
                return View(dtos);
            }

            public async Task<IActionResult> Create()
            {
                return View();
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(CategoryPostDto dto)
            {
                Category category = _mapper.Map<Category>(dto);
                category.Createdat = DateTime.Now;
                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            public async Task<IActionResult> Update(int id)
            {
                Category? category = _context.Categories.FirstOrDefault(x => !x.IsDeleted && x.Id == id);
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
            public async Task<IActionResult> Update(int id, CategoryUpdateDto dto)
            {
                Category? category = _context.Categories.FirstOrDefault(x => !x.IsDeleted && x.Id == id);
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

            public async Task<IActionResult> Remove(int id)
        {
            Category? category = _context.Categories.FirstOrDefault(x => !x.IsDeleted && x.Id == id);
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


