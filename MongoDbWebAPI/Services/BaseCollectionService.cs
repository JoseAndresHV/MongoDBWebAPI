using MongoDB.Driver;
using MongoDbWebAPI.Models;

namespace MongoDbWebAPI.Services
{
    public class BaseCollectionService<T> where T : Base
    {
        protected readonly IMongoCollection<T> _collection;

        public BaseCollectionService(string connectionString, string databaseName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _collection = database.GetCollection<T>(collectionName);
        }

        public virtual async Task<List<T>> GetAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public virtual async Task<T?> GetAsync(string id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public virtual async Task CreateAsync(T entity) =>
            await _collection.InsertOneAsync(entity);

        public virtual async Task UpdateAsync(string id, T entity) =>
            await _collection.ReplaceOneAsync(x => x.Id == id, entity);

        public virtual async Task RemoveAsync(string id) =>
            await _collection.DeleteOneAsync(x => x.Id == id);
    }
}
