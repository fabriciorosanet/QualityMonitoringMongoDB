using Microsoft.Extensions.Options;
using MongoDB.Driver;
using QualityMonitoringMongoDB.Models;

namespace QualityMonitoringMongoDB.Services
{
    public class WaterQualityMonitoringService
    {
        private readonly IMongoCollection<WaterQuality> _WaterQualityCollection;

        public WaterQualityMonitoringService(
            IOptions<QualityMonitoringDatabaseSettings> qualityMonitoringDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                qualityMonitoringDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                qualityMonitoringDatabaseSettings.Value.DatabaseName);

            _WaterQualityCollection = mongoDatabase.GetCollection<WaterQuality>(
                qualityMonitoringDatabaseSettings.Value.WaterQualityCollectionName);
        }

        public async Task<List<WaterQuality>> GetAsync() =>
            await _WaterQualityCollection.Find(_ => true).ToListAsync();

        public async Task<WaterQuality?> GetAsync(string id) =>
            await _WaterQualityCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(WaterQuality newLeitura) =>
            await _WaterQualityCollection.InsertOneAsync(newLeitura);

        public async Task UpdateAsync(string id, WaterQuality updatedAirQuality) =>
            await _WaterQualityCollection.ReplaceOneAsync(x => x.Id == id, updatedAirQuality);

        public async Task RemoveAsync(string id) =>
            await _WaterQualityCollection.DeleteOneAsync(x => x.Id == id);
    }
}
