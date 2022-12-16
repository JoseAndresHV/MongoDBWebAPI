using Microsoft.Extensions.Options;
using MongoDbWebAPI.Models;

namespace MongoDbWebAPI.Services
{
    public class CustomerService : BaseCollectionService<Customer>
    {
        public CustomerService(IOptions<MongoDatabaseOptions> options)
            : base(options.Value.ConnectionString, options.Value.DatabaseName, options.Value.CustomersCollectionName)
        {
        }
    }
}
