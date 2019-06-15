using System;
using System.Threading.Tasks;
using DigitalBreakthrough.Areas.Identity.Data;
using DigitalBreakthrough.Enums;
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
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<DigitalBreakthroughContext>();
            });

        }

        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            foreach (Roles suit in Enum.GetValues(typeof(Roles)))
            {

            }
            IdentityResult roleResult;
            //Adding Admin Role
            var roleCheck = await RoleManager.RoleExistsAsync(Roles.Patient.ToString());
            if (!roleCheck)
            {
                //create the roles and seed them to the database
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
            }
        }
    }
}