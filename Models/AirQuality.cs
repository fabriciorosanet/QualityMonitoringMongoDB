using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace QualityMonitoringMongoDB.Models
{
    public class AirQuality
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("DataMonitoramento")]
        public DateTime Timestamp { get; set; }
        public double PM25 { get; set; }
        public double PM10 { get; set; }
        public double CO2 { get; set; }

    }
}
