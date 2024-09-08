using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AssetsManagementsSystems.DAL;
using AMS.Logic.SoftwareService;
using Microsoft.Extensions.Logging;
using AMS.Api.Response;
using Microsoft.AspNetCore.Authorization;
using AssetsManagementsSystems.Api.Software;

namespace AssetsManagementsSystems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftwareController : ControllerBase
    {
        private readonly ISoftwareService _softwareService;
        private readonly ILogger<SoftwareController> _logger;

        public SoftwareController(ISoftwareService softwareService, ILogger<SoftwareController> logger)
        {
            _softwareService = softwareService;
            _logger = logger;
        }

        [HttpGet("GetAllSoftware")]
        public async Task<SoftwareResponse> GetAllSoftware()
        {
            try
            {
                _logger.LogInformation("GetAllSoftware method executed.");
                var software = await _softwareService.GetAllAsset();
                return new SoftwareResponse { StatusCode = 200, StatusMessage = "Success", Data = software };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all software.");
                return new SoftwareResponse { StatusCode = 500, StatusMessage = "Error", Data = null };
            }
        }

        [HttpGet("{id}")]
        public async Task<SoftwareResponse> GetSoftware(int id)
        {
            try
            {
                _logger.LogInformation("GetSoftware method executed for id: {Id}.", id);
                var software = await _softwareService.SearchAsset(id);
                if (software == null)
                {
                    _logger.LogInformation("Software with id {Id} not found.", id);
                    return new SoftwareResponse { StatusCode = 404, StatusMessage = "Software not found", Data = null };
                }

                return new SoftwareResponse
                {
                    SerialNumber = software.SerialNumber,
                    Name = software.Name,
                    Id = software.Id,
                    Version = software.Version,
                    Details = software.Details,
                    StatusCode = 200,
                    StatusMessage = "Success"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting the software with id: {Id}.", id);
                return new SoftwareResponse { StatusCode = 500, StatusMessage = "Error", Data = null };
            }
        }

        [HttpPost("AddSoftware")]
        public async Task<SoftwareResponse> AddSoftware(SoftwareRequest softwareRequest)
        {
            try
            {
                _logger.LogInformation("AddSoftware method executed.");
                var addedSoftware = await _softwareService.AddAsset(softwareRequest);
                return new SoftwareResponse { StatusCode = 200, StatusMessage = "Asset Added Successfully" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding software.");
                return new SoftwareResponse { StatusCode = 500, StatusMessage = "Error", Data = null };
            }
        }

        [HttpPut("{id}")]
        public async Task<SoftwareResponse> UpdateSoftware(int id, SoftwareRequest softwareRequest)
        {
            try
            {
                _logger.LogInformation("UpdateSoftware method executed for id: {Id}.", id);
                await _softwareService.UpdateAsset(id, softwareRequest);
                return new SoftwareResponse { StatusCode = 204, StatusMessage = "Software updated successfully", Data = null };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the software with id: {Id}.", id);
                return new SoftwareResponse { StatusCode = 500, StatusMessage = "Error", Data = null };
            }
        }

        [HttpDelete("{id}")]
        public async Task<SoftwareResponse> DeleteSoftware(int id)
        {
            try
            {
                _logger.LogInformation("DeleteSoftware method executed for id: {Id}.", id);
                await _softwareService.DeleteAssetById(id);
                return new SoftwareResponse { StatusCode = 204, StatusMessage = "Software deleted successfully", Data = null };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the software with id: {Id}.", id);
                return new SoftwareResponse { StatusCode = 500, StatusMessage = "Error", Data = null };
            }
        }
    }
}
