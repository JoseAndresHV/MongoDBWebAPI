using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbWebAPI.Models
{
    public class Account : BaseModel
    {
        [BsonElement("account_id")]
        public int AccountId { get; set; }

        [BsonElement("limit")]
        public int Limit { get; set; }

        [BsonElement("products")]
        public IEnumerable<string> Products { get; set; } = null!;
    }
}
