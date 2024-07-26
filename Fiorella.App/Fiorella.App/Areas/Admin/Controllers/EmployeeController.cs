using Fiorella.App.Context;
using Fiorella.App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorella.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeController : Controller
    {
        private readonly FiorellaDbContext _context;
        private readonly IWebHostEnvironment _env;

        public EmployeeController(FiorellaDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<Employee> employees = await _context.Employees
                .Where(x => !x.IsDeleted)
                .Include(x => x.PositionId)
                .ToListAsync();
            return View(employees);
        }

    }
}
