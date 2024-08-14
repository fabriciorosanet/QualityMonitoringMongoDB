using Microsoft.Extensions.Options;
using MongoDB.Driver;
using QualityMonitoringMongoDB.Models;

namespace QualityMonitoringMongoDB.Services
{
    public class AirQualityMonitoringService
    {
        private readonly IMongoCollection<AirQuality> _AirQualityCollection;

        public AirQualityMonitoringService(
            IOptions<QualityMonitoringDatabaseSettings> qualityMonitoringDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                qualityMonitoringDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                qualityMonitoringDatabaseSettings.Value.DatabaseName);

            _AirQualityCollection = mongoDatabase.GetCollection<AirQuality>(
                qualityMonitoringDatabaseSettings.Value.AirQualityCollectionName);
        }

        public async Task<List<AirQuality>> GetAsync() =>
            await _AirQualityCollection.Find(_ => true).ToListAsync();

        public async Task<AirQuality?> GetAsync(string id) =>
            await _AirQualityCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(AirQuality newLeitura) =>
            await _AirQualityCollection.InsertOneAsync(newLeitura);

        public async Task UpdateAsync(string id, AirQuality updatedAirQuality) =>
            await _AirQualityCollection.ReplaceOneAsync(x => x.Id == id, updatedAirQuality);

        public async Task RemoveAsync(string id) =>
            await _AirQualityCollection.DeleteOneAsync(x => x.Id == id);
    }
}
