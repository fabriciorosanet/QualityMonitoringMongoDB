namespace QualityMonitoringMongoDB.Models
{
    public class QualityMonitoringDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string AirQualityCollectionName { get; set; } = null!;

        public string WaterQualityCollectionName { get; set; } = null!;
    }


}

