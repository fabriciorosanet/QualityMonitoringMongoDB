using Microsoft.AspNetCore.Mvc;
using QualityMonitoringMongoDB.Models;
using QualityMonitoringMongoDB.Services;

namespace QualityMonitoringMongoDB.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class WaterQualityController : ControllerBase
        {
            private readonly WaterQualityMonitoringService _waterQualityMonitoringService;

            public WaterQualityController(WaterQualityMonitoringService waterQualityMonitoringService)
            {
                _waterQualityMonitoringService = waterQualityMonitoringService;
            }

            // GET: api/WaterQuality
            [HttpGet]
            public async Task<List<WaterQuality>> GetAll()
            {
                return await _waterQualityMonitoringService.GetAsync();
            }

            // GET: api/WaterQuality/{id}
            [HttpGet("{id}")]
            public async Task<ActionResult<WaterQuality>> GetById(string id)
            {
                var leitura = await _waterQualityMonitoringService.GetAsync(id);

                if (leitura == null)
                {
                    return NotFound();
                }

                return leitura;
            }

            // POST: api/WaterQuality
            [HttpPost]
            public async Task<IActionResult> Create(WaterQuality newLeitura)
            {
                await _waterQualityMonitoringService.CreateAsync(newLeitura);

                return CreatedAtAction(nameof(GetById), new { id = newLeitura.Id }, newLeitura);
            }

            // PUT: api/WaterQuality/{id}
            [HttpPut("{id}")]
            public async Task<IActionResult> Update(string id, WaterQuality updatedLeitura)
            {
                var existingLeitura = await _waterQualityMonitoringService.GetAsync(id);

                if (existingLeitura == null)
                {
                    return NotFound();
                }

                updatedLeitura.Id = existingLeitura.Id;

                await _waterQualityMonitoringService.UpdateAsync(id, updatedLeitura);

                return NoContent();
            }

            // DELETE: api/WaterQuality/{id}
            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(string id)
            {
                var leitura = await _waterQualityMonitoringService.GetAsync(id);

                if (leitura == null)
                {
                    return NotFound();
                }

                await _waterQualityMonitoringService.RemoveAsync(id);

                return NoContent();
            }
        }
    }