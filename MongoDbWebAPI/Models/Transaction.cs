using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbWebAPI.Models
{
    public class Transaction
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

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
    }
}
