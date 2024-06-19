using Microsoft.Azure.Cosmos;
using ProgramApplication.Configurations;

namespace ProgramApplication.Services
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            var cosmosDbSettings = new CosmosDbSettings();
            configuration.Bind(nameof(CosmosDbSettings), cosmosDbSettings);
            services.AddSingleton(cosmosDbSettings);

            services.AddSingleton<CosmosClient>(sp =>
            {
                return new CosmosClient(cosmosDbSettings.AccountEndpoint, cosmosDbSettings.AccountKey);
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Register services
            services.AddScoped<IApplicationService, ApplicationService>();
            // Add other service registrations here
        }
    }
}
