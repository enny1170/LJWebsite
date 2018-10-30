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
            //builder.Entity<FunctionTemplate>().HasMany<FunctionTemplateData>(f => f.TemplateData);
            //builder.Entity<FunctionTemplateData>().HasOne<FunctionTemplate>(d => d.FunctionTemplate);
            builder.Entity<FunctionTemplateValue>().HasOne(f=>f.FunctionTemplate).WithMany(f => f.TemplateValue);
            builder.Entity<FunctionTemplateChannel>().HasOne(c => c.FunctionTemplate).WithMany(f => f.TemplateChannel);
        }

        // Register Tables
        public DbSet<ColorKey> ColorKeys {get; set;}
        public DbSet<ControllerFunction> ControllerFunctions {get;set;}
        public DbSet<FunctionTemplate> FunctionTemplates {get;set;}
        public DbSet<FunctionTemplateChannel> FunctionTemplateChannels {get;set;}
        public DbSet<FunctionTemplateValue> FunctionTemplateValues { get; set; }

        public DbSet<Fixture> Fixtures { get; set; }
        public DbSet<FixtureFunction> FixtureFunctions { get; set; }
        public DbSet<FixtureFunctionChannel> FixtureFunctionChannels { get; set; }
        public DbSet<FixtureFunctionValue> FixtureFunctionValues { get; set; }

    }
}