using AssetsManagementSystems.Api.Books;
using AssetsManagementSystems.Api.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Logic.HardwareService
{
    public interface IHardwareService
    {

        Task<HardwareResponse> AddAsset(HardwareRequest hardware);
        Task DeleteAsset(HardwareRequest hardware);
        Task<IEnumerable<HardwareResponse>> GetAllAsset();
        Task<HardwareRequest> SearchAsset(int id);
        Task UpdateAsset(int id, HardwareRequest book);
        Task DeleteAssetById(int id);
    }
}
