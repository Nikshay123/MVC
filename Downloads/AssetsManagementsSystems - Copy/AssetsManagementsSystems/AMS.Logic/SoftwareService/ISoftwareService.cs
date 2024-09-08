using AssetsManagementsSystems.Api.Software;
using AssetsManagementSystems.Api.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Logic.SoftwareService
{
    public  interface ISoftwareService
    {
        Task<SoftwareResponse> AddAsset(SoftwareRequest hardware);
        Task DeleteAsset(SoftwareRequest hardware);
        Task<IEnumerable<SoftwareResponse>> GetAllAsset();
        Task<SoftwareRequest> SearchAsset(int id);
        Task UpdateAsset(int id, SoftwareRequest book);
        Task DeleteAssetById(int id);
    }
}
