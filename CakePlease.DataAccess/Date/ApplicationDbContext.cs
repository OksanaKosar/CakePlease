﻿using CakePlease.Models;
using Microsoft.EntityFrameworkCore;

namespace CakePlease.DateAccess
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; } 
    }
    
}
