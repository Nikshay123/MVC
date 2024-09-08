using AMS.Logic;
using AssetsManagementsSystems.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AssetsManagementsSystems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AssignController : ControllerBase
    {
        private readonly IAssetService<AssignAsset> _assetService;

        public AssignController(IAssetService<AssignAsset> assetService)
        {
            _assetService = assetService;
        }

        [HttpPost("assign")]
        public async Task<IActionResult> AssignAsset([FromBody] AssignAsset request)
        {
            try
            {
                if (request.AssetId <= 0 || string.IsNullOrEmpty(request.AssignedTo) || string.IsNullOrEmpty(request.AssetType))
                    return BadRequest("Invalid assetId, assetType, or assignedTo.");

                await _assetService.AssignAsset(request.AssetId, request.AssignedTo, request.AssetType);

                return Ok("Asset assigned successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("unassign")]
        public async Task<IActionResult> UnassignAsset(int assetId)
        {
            try
            {
                if (assetId <= 0)
                    return BadRequest("Invalid assetId.");

                await _assetService.UnassignAsset(assetId);

                return Ok("Asset unassigned successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }

   
}
