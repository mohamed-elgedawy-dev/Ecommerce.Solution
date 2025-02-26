using Ecommerce.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.APIs
{
    public class Program
    {
        public static async  Task Main(string[] args)
        {
            #region Configure Serves
            var webApplicationBuilder = WebApplication.CreateBuilder(args);

            

            // Add services to the container.

            webApplicationBuilder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            webApplicationBuilder.Services.AddEndpointsApiExplorer();
            webApplicationBuilder.Services.AddSwaggerGen();

            webApplicationBuilder.Services.AddDbContext<StoreContext>(options=> 
            options.UseSqlServer(webApplicationBuilder.Configuration.GetConnectionString("DefaultConnection")));



            #endregion

           




            var app = webApplicationBuilder.Build();

            using var scope = app.Services.CreateScope();

            var services = scope.ServiceProvider;

            var _dbContext = services.GetRequiredService<StoreContext>();

            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                await _dbContext.Database.MigrateAsync();

                await StoreContextSeeding.SeedAsync(_dbContext); // Seed the database
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();

                logger.LogError(ex, "An error occurred while migrating the database.");

            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();



            app.MapControllers();

            app.Run();
        }
    }
}
