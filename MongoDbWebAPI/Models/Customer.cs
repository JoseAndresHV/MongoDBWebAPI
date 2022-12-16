using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbWebAPI.Models
{
    public class Customer : BaseModel
    {
        [BsonElement("username")]
        public string Username { get; set; } = null!;

        [BsonElement("name")]
        public string Name { get; set; } = null!;

        [BsonElement("address")]
        public string Address { get; set; } = null!;

        [BsonElement("birthdate")]
        public DateTime Birthdate { get; set; }

        [BsonElement("email")]
        public string Email { get; set; } = null!;

        [BsonElement("accounts")]
        public IEnumerable<int> Accounts { get; set; } = null!;

    }
}

