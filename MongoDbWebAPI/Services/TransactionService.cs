using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDbWebAPI.Models;

namespace MongoDbWebAPI.Services
{
    public class TransactionService : BaseCollectionService<Transaction>
    {
        public TransactionService(IOptions<MongoDatabaseOptions> options)
            : base(options.Value.ConnectionString, options.Value.DatabaseName, options.Value.TransactionsCollectionName)
        {
        }

        public async Task<List<Transaction>> GetTransactionPagination(int pageSize, int pageNumber)
        {
            int skip = (pageNumber - 1) * pageSize;
            var c = await _collection.Find(_ => true).Skip(skip).Limit(pageSize).ToListAsync();
            return c;
        }
    }
}
