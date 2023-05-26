using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using SalesWebMvc.Data;
using SalesWebMvc.Models;

namespace SalesWebMvc
{
    public class Program
    {
        public static void Main(string[] args )
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddDbContext<SalesWebMvcContext>(options =>
              options.UseMySql("server=localhost;userid=admin;password=123456;database=saleswebmvcappdb", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql")));

            builder.Services.AddScoped<SeedingService>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            

            if (!app.Environment.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();

                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }



            app.UseHttpsRedirection();
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