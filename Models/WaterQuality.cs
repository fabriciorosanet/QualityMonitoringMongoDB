using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace QualityMonitoringMongoDB.Models
{
    public class WaterQuality
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("DataMonitoramento")]
        public DateTime Timestamp { get; set; }
        public double PH { get; set; }
        public double Turbidity { get; set; }
        public double DissolvedOxygen { get; set; }
    }
}
