using Microsoft.AspNetCore.Mvc;
using QualityMonitoringMongoDB.Models;
using QualityMonitoringMongoDB.Services;

namespace QualityMonitoringMongoDB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AirQualityController : ControllerBase
    {
        private readonly AirQualityMonitoringService _airQualityMonitoringService;

        public AirQualityController(AirQualityMonitoringService airQualityMonitoringService)
        {
            _airQualityMonitoringService = airQualityMonitoringService;
        }

        // GET: api/AirQuality
        [HttpGet]
        public async Task<List<AirQuality>> GetAll()
        {
            return await _airQualityMonitoringService.GetAsync();
        }

        // GET: api/AirQuality/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AirQuality>> GetById(string id)
        {
            var leitura = await _airQualityMonitoringService.GetAsync(id);

            if (leitura == null)
            {
                return NotFound();
            }

            return leitura;
        }

        // POST: api/AirQuality
        [HttpPost]
        public async Task<IActionResult> Create(AirQuality newLeitura)
        {
            await _airQualityMonitoringService.CreateAsync(newLeitura);

            return CreatedAtAction(nameof(GetById), new { id = newLeitura.Id }, newLeitura);
        }

        // PUT: api/AirQuality/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, AirQuality updatedLeitura)
        {
            var existingLeitura = await _airQualityMonitoringService.GetAsync(id);

            if (existingLeitura == null)
            {
                return NotFound();
            }

            updatedLeitura.Id = existingLeitura.Id;

            await _airQualityMonitoringService.UpdateAsync(id, updatedLeitura);

            return NoContent();
        }

        // DELETE: api/AirQuality/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var leitura = await _airQualityMonitoringService.GetAsync(id);

            if (leitura == null)
            {
                return NotFound();
            }

            await _airQualityMonitoringService.RemoveAsync(id);

            return NoContent();
        }
    }
}
