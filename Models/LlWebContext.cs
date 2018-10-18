using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LJWebsite.Models.Entities;

namespace LJWebsite.Models
{
    public class LjWebContext:IdentityDbContext<IdentityUser>
    {
        public LjWebContext(DbContextOptions<LjWebContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        // Register Tables
        public DbSet<Functionality> Functionality {get; set;}
    }
}