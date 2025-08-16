using Ecommerce.APIs.Errors;
using Ecommerce.APIs.Helper;
using Ecommerce.Core.RepositoriesContract;
using Ecommerce.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.APIs.Extensions
{
    public static class ApplicationServicesExtension
    {


        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddScoped(typeof(IGenericRepositories<>), typeof(GenericRepositories<>));
            services.AddAutoMapper(typeof(MappingProfile));

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(x => x.Value.Errors)
                        .Select(x => x.ErrorMessage)
                        .ToArray();

                    var errorResponse = new ApiValidationerrorResponse()
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });

            return services;


        }




    }
}
