using Microsoft.Azure.Cosmos;
using ProgramApplication.Configurations;
using ProgrammeApplication.Services;

namespace ProgramApplication.Services
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            var cosmosDbSettings = new AppConfig();
            configuration.Bind(nameof(AppConfig), cosmosDbSettings);
            services.AddSingleton(cosmosDbSettings);

            services.AddSingleton<CosmosClient>(sp =>
            {
                return new CosmosClient(cosmosDbSettings.CosmosDbEndpoint, cosmosDbSettings.CosmosDbKey);
            });

            services.AddAutoMapper(typeof(AutoMapperProfile));


            // Register services
            services.AddScoped<IApplicationFormService, ApplicationFormService>();
            services.AddScoped<IProgrammeService, ProgrammeService>();
            services.AddScoped<IQuestionService, QuestionService>();

            
        }
    }
}
