using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using n_hashimotoStudy.Data;
using n_hashimotoStudy.Models;
using n_hashimotoStudy.Services;

namespace n_hashimotoStudy
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
            //  DBをPostgresに設定します。
            services.AddDbContext<ApplicationDbContext>(options =>
                //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
                options.UseNpgsql(Configuration.GetConnectionString("KintaiConnection")));


            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // パスワード制限
                //「最低桁数2桁」のルールのみ
                options.Password.RequireDigit = false;  // 数字 [0-9] が含まれるべきか
                options.Password.RequiredLength = 2;    // 最低限必要な文字数
                options.Password.RequireLowercase = false;  // アルファベット小文字 [a-z] が含まれるべきか
                options.Password.RequireNonAlphanumeric = false;    // 記号(=数字/アルファベット[0-9a-zA-Z]以外の文字)が含まれるべきか
                options.Password.RequireUppercase = false;  // アルファベット大文字 [A-Z] が含まれるべきか
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

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
