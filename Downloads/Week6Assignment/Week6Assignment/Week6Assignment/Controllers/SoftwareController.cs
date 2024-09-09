using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Week6Assignment.DAL;
using Week6Assignment.Repositary;
using Week6Assignment.Services;

namespace Week6Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftwareController : ControllerBase
    {
        private readonly IAssetService<Software> _softwareRepository;

        public SoftwareController(IAssetService<Software> softwareRepository)
        {
            _softwareRepository = softwareRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSoftware()
        {
            var software = await _softwareRepository.GetAllAsset();
            return Ok(software);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSoftware(int id)
        {
            var software = await _softwareRepository.SearchAsset(id);
            if (software == null)
            {
                return NotFound();
            }
            return Ok(software);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSoftware([FromBody] Software software)
        {
            if (software == null)
            {
                return BadRequest("Software object is null");
            }

            var addedSoftware = await _softwareRepository.AddAsset(software);
            return CreatedAtAction(nameof(GetSoftware), new { id = addedSoftware.Id }, addedSoftware);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSoftware(int id, [FromBody] Software software)
        {
            if (software == null || software.Id != id)
            {
                return BadRequest("Invalid software object");
            }

            var existingSoftware = await _softwareRepository.SearchAsset(id);
            if (existingSoftware == null)
            {
                return NotFound();
            }

            await _softwareRepository.UpdateAsset(software);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSoftware(int id)
        {
            var software = await _softwareRepository.SearchAsset(id);
            if (software == null)
            {
                return NotFound();
            }

            await _softwareRepository.DeleteAsset(software);
            return NoContent();
        }
    }
}
