using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OutcomeManagementSystem.Data;

[assembly: HostingStartup(typeof(OutcomeManagementSystem.Areas.Identity.IdentityHostingStartup))]
namespace OutcomeManagementSystem.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdentityUserContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("IdentityUserContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<IdentityUserContext>();
            });
        }
    }
}