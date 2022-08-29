using Microsoft.Extensions.DependencyInjection;
using TodoITA.WebApi.Mapping;
using AutoMapper;

namespace TodoITA.WebApi.StartupExtensions
{
    public static class AddAutoMapperExtension
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(TodoCategoryProfile));

            return services;
        }
    }
}
