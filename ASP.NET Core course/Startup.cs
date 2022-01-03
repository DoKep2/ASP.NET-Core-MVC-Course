using ASP.NET_Core_course.Data;
using ASP.NET_Core_course.Data.Interfaces;
using ASP.NET_Core_course.Data.Mocks;
using ASP.NET_Core_course.Data.Models;
using ASP.NET_Core_course.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_course
{
    public class Startup
    {
        private IConfigurationRoot _constString;

        public Startup(IWebHostEnvironment hostingEnvironment)
        {
            _constString = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("dbSettings.json").Build();
        }

    // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options =>
                options.UseSqlServer(_constString.GetConnectionString("DefaultConnection")));
            services.AddTransient<IAllCars, CarRepository>();
            services.AddTransient<ICarsCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(ShopCart.GetCart);
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "categoryFilter", template: "Car/{action}/{category?}",
                    defaults: new {Controller = "Car", Category = "List"});
            });

            using var scope = app.ApplicationServices.CreateScope();
            AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
            DBObjects.Initial(content);
            /*if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
            });*/
        }
    }
}