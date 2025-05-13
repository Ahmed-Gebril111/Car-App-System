using AutoMapper;
using CarApplication.BLL.Interfaces;
using CarApplication.BLL.Repositories;
using CarApplication.DAL.Contexts;
using CarApplication.PL.MappingProfiles;
using Microsoft.EntityFrameworkCore;

namespace CarApplication.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<MVCAppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<ICarRepository, CarRepository>();

            builder.Services.AddAutoMapper(M => M.AddProfiles(new List<Profile>() { new CarProfile() }));
            //builder.Services.AddAutoMapper(typeof(MappingProfiles));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
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
