using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDbWebAPI.Models;

namespace MongoDbWebAPI.Services
{
    public class AccountService : BaseCollectionService<Account>
    {
        public AccountService(IOptions<MongoDatabaseOptions> options)
            : base(options.Value.ConnectionString, options.Value.DatabaseName, options.Value.AccountsCollectionName)
        {
        }

        public async Task<Account?> GetByAccountIdAsync(int accountId) =>
            await _collection.Find(x => x.AccountId == accountId).FirstOrDefaultAsync();
    }
}
