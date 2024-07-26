using AutoMapper;
using Fiorella.App.Context;
using Fiorella.App.Dtos.Category;
using Fiorella.App.Dtos.Position;
using Fiorella.App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorella.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PositionController : Controller
    {
        private readonly FiorellaDbContext _context;
        private readonly IMapper _mapper;

        public PositionController(FiorellaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var query = _context.Positions.Where(x => !x.IsDeleted).AsQueryable();
            List<PositionGetDto> dtos = new List<PositionGetDto>();
            dtos = await query.Select(x=> new PositionGetDto { Name = x.Name, Id = x.Id }).ToListAsync();
            return View(dtos);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PositionPostDto dto)
        {
            Position position = _mapper.Map<Position>(dto);
            position.Createdat = DateTime.Now;
            await _context.Positions.AddAsync(position);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            Position? position = _context.Positions.FirstOrDefault(x => !x.IsDeleted && x.Id == id);
            if (position == null)
            {
                return NotFound();
            }
            PositionUpdateDto dto = new PositionUpdateDto()
            {
                Name = position.Name,
            };
            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, PositionUpdateDto dto)
        {
            Position? position = _context.Positions.FirstOrDefault(x => !x.IsDeleted && x.Id == id);
            if (position == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            position.Name = dto.Name;
            position.Updatedat = DateTime.Now;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Remove(int id)
        {
            Position? position = _context.Positions.FirstOrDefault(x => !x.IsDeleted && x.Id == id);
            if (position == null)
            {
                return NotFound();
            }
            position.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
