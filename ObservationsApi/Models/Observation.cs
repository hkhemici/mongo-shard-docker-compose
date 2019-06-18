using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ObservationsApi.Models

{
    public class Observation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public decimal Value { get; set; }

        public string Subject { get; set; }
    }
}