using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbWebAPI.Models
{
    public class Account
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("account_id")]
        public int AccountId { get; set; }

        [BsonElement("limit")]
        public int Limit { get; set; }

        [BsonElement("products")]
        public IEnumerable<int> Products { get; set; } = null!;
    }
}
