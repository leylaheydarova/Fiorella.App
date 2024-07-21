using AutoMapper;
using Fiorella.App.Context;
using Microsoft.AspNetCore.Mvc;

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
            var query=true;
            return View();
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

    }
}
