using System;
using DigitalBreakthrough.Areas.Identity.Data;
using DigitalBreakthrough.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(DigitalBreakthrough.Areas.Identity.IdentityHostingStartup))]
namespace DigitalBreakthrough.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<DigitalBreakthroughContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DigitalBreakthroughContextConnection")));

                services.AddDefaultIdentity<User>()
                    .AddEntityFrameworkStores<DigitalBreakthroughContext>();
            });
        }
    }
}