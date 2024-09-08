using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AssetsManagementSystems.Api.Hardware;
using AssetsManagementsSystems.DAL;
using AMS.Logic.HardwareService;
using Microsoft.Extensions.Logging;
using AMS.Api.Response;
using Microsoft.AspNetCore.Authorization;

namespace AssetsManagementsSystems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HardwareController : ControllerBase
    {
        private readonly IHardwareService _hardwareService;
        private readonly ILogger<HardwareController> _logger;

        public HardwareController(IHardwareService hardwareService, ILogger<HardwareController> logger)
        {
            _hardwareService = hardwareService;
            _logger = logger;
        }

        [HttpGet("GetAllHardware")]
        public async Task<HardwareResponse> GetAllHardware()
        {
            try
            {
                _logger.LogInformation("GetAllHardware method executed.");
                var hardware = await _hardwareService.GetAllAsset();
                return new HardwareResponse { StatusCode = 200, StatusMessage = "Success", Data = hardware };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all hardware.");
                return new HardwareResponse { StatusCode = 500, StatusMessage = "Error", Data = null };
            }
        }

        [HttpGet("{id}")]
        public async Task<HardwareResponse> GetHardware(int id)
        {
            try
            {
                _logger.LogInformation("GetHardware method executed for id: {Id}.", id);
                var hardware = await _hardwareService.SearchAsset(id);
                if (hardware == null)
                {
                    _logger.LogInformation("Hardware with id {Id} not found.", id);
                    return new HardwareResponse { StatusCode = 404, StatusMessage = "Hardware not found", Data = null };
                }

                return new HardwareResponse
                {
                    SerialNumber = hardware.SerialNumber,
                    Name = hardware.Name,
                    Id = hardware.Id,
                    Details = hardware.Details,
                    StatusCode = 200,
                    StatusMessage = "Success"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting the hardware with id: {Id}.", id);
                return new HardwareResponse { StatusCode = 500, StatusMessage = "Error", Data = null };
            }
        }

        [HttpPost("AddHardware")]
        public async Task<HardwareResponse> AddHardware(HardwareRequest hardwareRequest)
        {
            try
            {
                _logger.LogInformation("AddHardware method executed.");
                var addedHardware = await _hardwareService.AddAsset(hardwareRequest);
                return new HardwareResponse { StatusCode = 200, StatusMessage = "Asset Added Successfully" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding hardware.");
                return new HardwareResponse { StatusCode = 500, StatusMessage = "Error", Data = null };
            }
        }

        [HttpPut("{id}")]
        public async Task<HardwareResponse> UpdateHardware(int id, HardwareRequest hardwareRequest)
        {
            try
            {
                _logger.LogInformation("UpdateHardware method executed for id: {Id}.", id);
                await _hardwareService.UpdateAsset(id, hardwareRequest);
                return new HardwareResponse { StatusCode = 204, StatusMessage = "Hardware updated successfully", Data = null };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the hardware with id: {Id}.", id);
                return new HardwareResponse { StatusCode = 500, StatusMessage = "Error", Data = null };
            }
        }

        [HttpDelete("{id}")]
        public async Task<HardwareResponse> DeleteHardware(int id)
        {
            try
            {
                _logger.LogInformation("DeleteHardware method executed for id: {Id}.", id);
                await _hardwareService.DeleteAssetById(id);
                return new HardwareResponse { StatusCode = 204, StatusMessage = "Hardware deleted successfully", Data = null };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the hardware with id: {Id}.", id);
                return new HardwareResponse { StatusCode = 500, StatusMessage = "Error", Data = null };
            }
        }
    }
}
