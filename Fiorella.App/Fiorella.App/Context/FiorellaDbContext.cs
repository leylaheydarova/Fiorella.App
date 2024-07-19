using Fiorella.App.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiorella.App.Context
{
    public class FiorellaDbContext:DbContext
    {
        DbSet<Category>Categories { get; set; }
        public FiorellaDbContext(DbContextOptions<FiorellaDbContext> options) : base(options)
        {
        }
    }
}
