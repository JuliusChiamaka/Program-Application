using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using ProgramApplication.Configurations;

namespace ProgramApplication.Data.Repositories
{
    public class CosmosDbContext
    {
        private readonly CosmosClient _cosmosClient;
        private readonly Database _database;
        private readonly Container _container;

        public CosmosDbContext(IOptions<AppConfig> config)
        {
            _cosmosClient = new CosmosClient(config.Value.CosmosDbEndpoint, config.Value.CosmosDbKey);
            _database = _cosmosClient.GetDatabase(config.Value.CosmosDbDatabaseName);

            // Create containers if they do not exist
            _database.CreateContainerIfNotExistsAsync("Programs", "/id").GetAwaiter().GetResult();
            _database.CreateContainerIfNotExistsAsync("ApplicationForms", "/id").GetAwaiter().GetResult();
            _database.CreateContainerIfNotExistsAsync("CustomQuestions", "/id").GetAwaiter().GetResult();
        }

        public Container GetContainer(string containerName) => _database.GetContainer(containerName);
    }
}
