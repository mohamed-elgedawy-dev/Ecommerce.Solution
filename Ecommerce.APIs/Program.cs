using Ecommerce.APIs.Errors;
using Ecommerce.APIs.Extensions;
using Ecommerce.APIs.Helper;
using Ecommerce.APIs.MiddleWares;
using Ecommerce.Core.RepositoriesContract;
using Ecommerce.Repository;
using Ecommerce.Repository.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Ecommerce.APIs
{
    public class Program
    {
        public static async  Task Main(string[] args)
        {
          
            var webApplicationBuilder = WebApplication.CreateBuilder(args);

            #region Configure Serves

            // Add services to the container.

            webApplicationBuilder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            webApplicationBuilder.Services.AddSwaggerServices();
            webApplicationBuilder.Services.AddDbContext<StoreContext>(options=> 
            options.UseSqlServer(webApplicationBuilder.Configuration.GetConnectionString("DefaultConnection")));


            webApplicationBuilder.Services.AddApplicationServices();


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
                app.UseSwaggerMiddlewares();
            }
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseStatusCodePagesWithReExecute("/errors");
            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.MapControllers();

            app.Run();





        }
    }
}
