using System;
using System.Threading.Tasks;
using HealthRate.Areas.Identity.Data;
using HealthRate.Enums;
using HealthRate.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(HealthRate.Areas.Identity.IdentityHostingStartup))]
namespace HealthRate.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<HealthRateContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("HealthRateContextConnection")));

                services.AddDefaultIdentity<User>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<HealthRateContext>();
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