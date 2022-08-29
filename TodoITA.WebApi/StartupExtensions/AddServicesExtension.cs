using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoITA.BLL.ExtensionsMethods;

namespace TodoITA.WebApi.StartupExtensions
{
    public static class AddServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddBLL();
            services.AddRepositories();
            services.AddDbAccesss(configuration);
            services.AddAutoMapper();

            return services;
        }
    }
}
