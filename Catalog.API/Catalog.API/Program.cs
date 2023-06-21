using Catalog.DAL.Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Catalog.DAL.Contracts;
using Catalog.Domain.Contracts;
using Catalog.Domain.Implementations;
using Microsoft.AspNetCore.Hosting;

namespace Catalog.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //builder.Services.AddAutoMapper();
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
            builder.Services.AddControllers();

            builder.Services.AddTransient<IItemService, ItemService>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Catalog Service API", Version = "v1" });
            });

            
            builder.Services.AddDbContext<DataContext>(options =>
                  options.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=Catalog;Integrated Security=True;"));

            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddScoped<IDbRepository, DbRepository>();
            builder.Services.AddTransient<ICategoryService, CategoryService>();
            builder.Services.AddTransient<IItemService, ItemService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}