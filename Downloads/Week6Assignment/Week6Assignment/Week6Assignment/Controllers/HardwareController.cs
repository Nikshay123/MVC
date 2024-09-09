using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Week6Assignment.DAL;
using Week6Assignment.Repositary;
using Week6Assignment.Services;

namespace Week6Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HardwareController : ControllerBase
    {
        private readonly IAssetService<Hardware> _hardwareService;

        public HardwareController(IAssetService<Hardware> hardwareService)
        {
            _hardwareService = hardwareService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHardware()
        {
            var hardware = await _hardwareService.GetAllAsset();
            return Ok(hardware);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHardware(int id)
        {
            var hardware = await _hardwareService.SearchAsset(id);
            if (hardware == null)
            {
                return NotFound();
            }
            return Ok(hardware);
        }

        [HttpPost]
        public async Task<IActionResult> AddHardware([FromBody] Hardware hardware)
        {
            if (hardware == null)
            {
                return BadRequest("Hardware object is null");
            }

            var addedHardware = await _hardwareService.AddAsset(hardware);
            return CreatedAtAction(nameof(GetHardware), new { id = addedHardware.Id }, addedHardware);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHardware(int id, [FromBody] Hardware hardware)
        {
            if (hardware == null || hardware.Id != id)
            {
                return BadRequest("Invalid hardware object");
            }

            var existingHardware = await _hardwareService.SearchAsset(id);
            if (existingHardware == null)
            {
                return NotFound();
            }

            await _hardwareService.UpdateAsset(hardware);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHardware(int id)
        {
            var hardware = await _hardwareService.SearchAsset(id);
            if (hardware == null)
            {
                return NotFound();
            }

            await _hardwareService.DeleteAsset(hardware);
            return NoContent();
        }
    }
}
