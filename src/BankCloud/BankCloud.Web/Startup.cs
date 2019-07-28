﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankCloud.Data.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BankCloud.Data.Entities;
using FixerSharp;

namespace BankCloud.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<BankCloudDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<BankUser, BankUserRole>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<BankCloudDbContext>()
                .AddDefaultTokenProviders();

            services.AddCors(options =>
            {
                options.AddPolicy("MessagesCORSPolicy",
                    builder =>
                    {
                        builder.WithOrigins("http://data.fixer.io/api/latest?access_key=391ea2067e573b4fd36e33b16e9f7ae8")
                        .AllowAnyHeader();
                    });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            Fixer.SetApiKey("391ea2067e573b4fd36e33b16e9f7ae8");

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetRequiredService<BankCloudDbContext>())
                {
                    context.Database.EnsureCreated();

                    if (!context.Roles.Any())
                    {
                        context.Roles.Add(new BankUserRole { Name = "Admin", NormalizedName = "ADMIN" });
                        context.Roles.Add(new BankUserRole { Name = "User", NormalizedName = "USER" });
                        context.Roles.Add(new BankUserRole { Name = "Agent", NormalizedName = "AGENT" });
                    }

                    if (!context.Currencies.Any())
                    {
                        context.Currencies.Add(new Currency
                        {
                            IsoCode = "USD",
                            Name = "American Dollar",
                            Type = Data.Entities.Enums.CurrencyType.International,
                            ТrustLevel = 9
                        });

                        context.Currencies.Add(new Currency
                        {
                            IsoCode = "EUR",
                            Name = "Euro",
                            Type = Data.Entities.Enums.CurrencyType.International,
                            ТrustLevel = 9
                        });

                        context.Currencies.Add(new Currency
                        {
                            IsoCode = "BGN",
                            Name = "Bulgarian Lev",
                            Type = Data.Entities.Enums.CurrencyType.National,
                            ТrustLevel = 9
                        });
                    }

                    context.SaveChanges();
                }
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
