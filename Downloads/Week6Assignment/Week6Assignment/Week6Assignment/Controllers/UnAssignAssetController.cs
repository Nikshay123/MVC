using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Week6Assignment.DAL;
using Week6Assignment.Services;

namespace Week6Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnassignAssetController : ControllerBase
    {
        private readonly IAssetService<AssignAsset> _assetService;

        public UnassignAssetController(IAssetService<AssignAsset> assetService)
        {
            _assetService = assetService;
        }

        // DELETE: api/UnassignAsset/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> UnassignAsset(int id)
        {
            var unassignAsset = await _assetService.SearchAsset(id);
            if (unassignAsset == null)
            {
                return NotFound();
            }

            // Delete the asset from the AssignAsset table
            await _assetService.DeleteAsset(unassignAsset);

            return Ok("Asset unassigned successfully");
        }
    }
}
