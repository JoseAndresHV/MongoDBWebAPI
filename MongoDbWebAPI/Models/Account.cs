using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbWebAPI.Models
{
    [BsonIgnoreExtraElements]
    public class Account : Base
    {
        [BsonElement("account_id")]
        public int AccountId { get; set; }

        [BsonElement("limit")]
        public int Limit { get; set; }

        [BsonElement("products")]
        public IEnumerable<string> Products { get; set; } = null!;
    }
}
