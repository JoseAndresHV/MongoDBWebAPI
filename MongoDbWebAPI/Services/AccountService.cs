using Microsoft.Extensions.Options;
using MongoDbWebAPI.Models;

namespace MongoDbWebAPI.Services
{
    public class AccountService : BaseCollectionService<Account>
    {
        public AccountService(IOptions<MongoDatabaseOptions> options)
            : base(options.Value.ConnectionString, options.Value.DatabaseName, options.Value.AccountsCollectionName)
        {
        }
    }
}
