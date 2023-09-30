using BusinessLayer.Repositories;
using DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddScoped(typeof(IRepository<>), typeof(SQLRepository<>));
            builder.Services.AddDbContext<SQLContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection")));
            
            //CUSTOM
            builder.Services.AddCors(option =>
            {
                option.AddPolicy("OtelApiCors", options=> options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //CUSTOM
            app.UseRouting();

            //CUSTOM
            app.UseCors("OtelApiCors");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}