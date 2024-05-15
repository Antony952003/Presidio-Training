using Microsoft.EntityFrameworkCore;
using PizzaAPI.Contexts;
using PizzaAPI.Interfaces;
using PizzaAPI.Models;
using PizzaAPI.Repositories;
using PizzaAPI.Services;

namespace PizzaAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #region Contexts
            builder.Services.AddDbContext<PizzaBookingContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default Connection")));
            #endregion

            #region Repositories
            builder.Services.AddScoped<IRepository<int, User>, UserRepository>();
            builder.Services.AddScoped<IRepository<int, Pizza>, PizzaRepository>();
            builder.Services.AddScoped<IRepository<int, UserDetail>, UserDetailRepository>();
            #endregion

            #region Services
            builder.Services.AddScoped<IUserServices, UserService>();
            builder.Services.AddScoped<IPizzaServices, PizzaService>();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
