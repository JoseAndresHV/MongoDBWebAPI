using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbWebAPI.Models
{
    public class Base
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
    }
}
