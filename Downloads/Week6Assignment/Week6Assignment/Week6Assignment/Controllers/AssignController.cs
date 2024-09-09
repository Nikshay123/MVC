using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Week6Assignment.DAL;
using Week6Assignment.Services;

namespace Week6Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignController : ControllerBase
    {
        private readonly IAssetService<AssignAsset> _assetService;

        public AssignController(IAssetService<AssignAsset> assetService)
        {
            _assetService = assetService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAssign([FromBody] AssignAsset assign)
        {
            if (assign == null)
            {
                return BadRequest("Invalid assignment details.");
            }

            try
            {
                var addedAsset = await _assetService.AddAsset(assign);
                return Ok(addedAsset);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
