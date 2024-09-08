using AssetsManagementsSystems.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMS.Logic
{
    public interface IAssetService<T>
    {
        Task AssignAsset(int Id ,string assignedTo, string assetType);
        Task UnassignAsset(int assetId);
        
    }
}
