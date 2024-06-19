using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System.Linq.Expressions;

namespace ProgramApplication.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CosmosDbContext _context;
        private readonly Container _container;

        public Repository(CosmosDbContext context, string containerName)
        {
            _context = context;
            _container = _context.GetContainer(containerName);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var query = _container.GetItemLinqQueryable<T>(true).AsQueryable();
            return await query.ToFeedIterator().ReadNextAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            try
            {
                var response = await _container.ReadItemAsync<T>(id.ToString(), new PartitionKey(id.ToString()));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            var query = _container.GetItemLinqQueryable<T>(true).Where(predicate).AsQueryable();
            return await query.ToFeedIterator().ReadNextAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _container.CreateItemAsync(entity, new PartitionKey(Guid.NewGuid().ToString()));
        }

        public async Task UpdateAsync(T entity)
        {
            await _container.UpsertItemAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _container.DeleteItemAsync<T>(id.ToString(), new PartitionKey(id.ToString()));
        }
    }
}
