using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbWebAPI.Models
{
    [BsonIgnoreExtraElements]
    public class Transaction : Base
    {
        [BsonElement("account_id")]
        public int AccountId { get; set; }

        [BsonElement("transaction_count")]
        public int TransactionCount { get; set; }

        [BsonElement("bucket_start_date")]
        public DateTime BucketStartDate { get; set; }

        [BsonElement("bucket_end_date")]
        public DateTime BucketEndDate { get; set; }

        [BsonElement("transactions")]
        public IEnumerable<TransactionDetail> Transactions { get; set; } = null!;

        public class TransactionDetail
        {
            [BsonElement("date")]
            public DateTime Date { get; set; }

            [BsonElement("amount")]
            public int Amount { get; set; }

            [BsonElement("transaction_code")]
            public string TransactionCode { get; set; } = null!;

            [BsonElement("symbol")]
            public string Symbol { get; set; } = null!;

            [BsonElement("price")]
            public string Price { get; set; } = null!;

            [BsonElement("total")]
            public string Total { get; set; } = null!;
        }
    }
}
