﻿using Fiorella.App.Models;
using Fiorella.App.Models.Base_Models;
using Microsoft.EntityFrameworkCore;

namespace Fiorella.App.Context
{
    public class FiorellaDbContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public FiorellaDbContext(DbContextOptions<FiorellaDbContext> options) : base(options)
        {
        }
    }
}
