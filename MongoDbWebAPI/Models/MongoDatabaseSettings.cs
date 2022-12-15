﻿namespace MongoDbWebAPI.Models
{
    public class MongoDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string AccountsCollectionName { get; set; } = null!;
        public string CustomersCollectionName { get; set; } = null!;
        public string TransactionsCollectionName { get; set; } = null!;
    }
}
