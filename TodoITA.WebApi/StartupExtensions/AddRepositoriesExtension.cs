using Microsoft.Extensions.DependencyInjection;
using TodoITA.DataAccess.Repositories.Interfaces;
using TodoITA.DataAccess.Repositories.Realizations;

namespace TodoITA.WebApi.StartupExtensions
{
    public static class AddRepositoriesExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITodoItemRepository, TodoItemRepository>();
            services.AddScoped<ITodoCategoryRepository, TodoCategoryRepository>();

            return services;
        }
    }
}
