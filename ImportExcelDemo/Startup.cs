using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImportExcelDemo.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ImportExcelDemo
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
            //Added Windows-1252 Encoding
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            
            services.AddDbContext<DemoContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DemoContext")));

           /* services.AddScoped<DemoContext, DbContext>*/

            //Allows MVC to be used along with RazorPages
            services.AddMvc(options => options.EnableEndpointRouting = false)
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
            // Added Dynamic Updated package RuntimeCompilation
            // will allow for JS, HTML, CSS changes to work during runtime          
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.Name = "Cookie";
            });

            services.AddMemoryCache();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            /*app.UseRouting();*/

            app.UseAuthorization();

            app.UseMvc();
            /* app.UseEndpoints(endpoints =>
             {
                 endpoints.MapRazorPages();
             });*/

            app.UseSession();
        }
    }
}
