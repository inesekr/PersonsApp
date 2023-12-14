using PersonsApp.Core.Models;
using PersonsApp.Core.Services;
using PersonsApp.Data;
using PersonsApp.Services;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace PersonsApp.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<PersonDbContext>(options =>
               options.UseSqlite(builder.Configuration.GetConnectionString("PersonsDb")));
   
            builder.Services.AddTransient<IDbService, DbService>();
            builder.Services.AddTransient<IEntityService<Person>, EntityService<Person>>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}