using Microsoft.Extensions.Options;
using MongoDbWebAPI.Models;

namespace MongoDbWebAPI.Services
{
    public class TransactionService : BaseCollectionService<Transaction>
    {
        public TransactionService(IOptions<MongoDatabaseOptions> options)
            : base(options.Value.ConnectionString, options.Value.DatabaseName, options.Value.TransactionsCollectionName)
        {
        }
    }
}
