using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbWebAPI.Models
{
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
