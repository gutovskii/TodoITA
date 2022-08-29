using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoITA.BLL.Services.Interfaces;
using TodoITA.BLL.Services.Realization;

namespace TodoITA.WebApi.StartupExtensions
{
    public static class AddBLLExtension
    {
        public static IServiceCollection AddBLL(this IServiceCollection services)
        {
            services.AddScoped<ITodoItemService, TodoItemService>();
            services.AddScoped<ITodoCategoryService, TodoCategoryService>();

            return services;
        }
    }
}
