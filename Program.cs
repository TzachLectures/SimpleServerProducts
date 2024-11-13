
using Microsoft.EntityFrameworkCore;
using SimpleServerProducts.Application.Interfaces;
using SimpleServerProducts.Application.Services;
using SimpleServerProducts.Core.Interfaces;
using SimpleServerProducts.Infrastructure.Data;
using SimpleServerProducts.Infrastructure.Services;

namespace SimpleServerProducts
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            
            string connectionString = "Server=LAPTOP-M1H6FNPI\\MSSQLSERVER02; Database=MyStore; Trusted_Connection=True; TrustServerCertificate=True;";

            builder.Services.AddDbContext<MyStoreContext>(options=>options.UseSqlServer(connectionString));
            
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            builder.Services.AddScoped<IProductService, ProductService>();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
