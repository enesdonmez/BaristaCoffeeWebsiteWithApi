using BaristaCoffee.API.Repositories.AboutRepositories;
using BaristaCoffee.API.Repositories.BaristaRepositories;
using BaristaCoffee.API.Repositories.BaristaTypeRepositories;
using BaristaCoffee.API.Repositories.ContactRepositories;
using BaristaCoffee.API.Repositories.MenuCategoryRepositories;
using BaristaCoffee.API.Repositories.MenuRepositories;
using BaristaCoffee.API.Repositories.RezervationRepository;
using BaristaCoffee.API.Repositories.TestimonialRepositories;
using Microsoft.Data.SqlClient;
using Scalar.AspNetCore;
using System.Data;

namespace BaristaCoffee.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IBaristaRepository, BaristaRepository>();
            builder.Services.AddScoped<IContactRepository, ContactRepository>();
            builder.Services.AddScoped<IAboutRepository, AboutRepository>();
            builder.Services.AddScoped<IMenuRepository, MenuRepository>();
            builder.Services.AddScoped<ITestimonialRepository, TestimonialRepository>();
            builder.Services.AddScoped<IBaristaTypeRepository, BaristaTypeRepository>();
            builder.Services.AddScoped<IMenuCategoryRepository, MenuCategoryRepository>();
            builder.Services.AddScoped<IRezervationRepository, RezervationRepository>();
            builder.Services.AddResponseCompression(opt =>
            {
                opt.EnableForHttps = true;
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference(opt =>
                {
                    opt.Title = "Barista Coffee API";
                    opt.Theme = ScalarTheme.Mars;
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseResponseCompression();

            app.Run();
        }
    }
}
