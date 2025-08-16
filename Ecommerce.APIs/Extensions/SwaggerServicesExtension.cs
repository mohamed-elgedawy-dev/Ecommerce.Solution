using Microsoft.AspNetCore.Builder;

namespace Ecommerce.APIs.Extensions
{
    public static class SwaggerServicesExtension
    {

        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();


            return services;
            
        }

        public static void UseSwaggerMiddlewares(this WebApplication app)
        {

            app.UseSwagger();
            app.UseSwaggerUI();


        }
    }
        
}
