using System;
using LJWebsite.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(LJWebsite.Areas.Identity.IdentityHostingStartup))]
namespace LJWebsite.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
/*             builder.ConfigureServices((context, services) => {
                services.AddDbContext<LjWebContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("DefaultConnection")));
 */         builder.ConfigureServices((context ,services) =>{
                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<LjWebContext>();
            });
        }
    }
}