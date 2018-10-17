using Microsoft.EntityFrameworkCore;
using LJWebsite.Models.Entities;

namespace LJWebsite.Models
{
    public class LjWebContext:DbContext
    {
        public LjWebContext(DbContextOptions<LjWebContext> options):base(options)
        {

        }

        // Register Tables
        public DbSet<Functionality> Functionality {get; set;}
    }
}