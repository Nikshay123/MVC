using System.Threading.Tasks;
using AssetsManagementsSystems.Repositary;

namespace AMS.Logic
{
    public class AssetService<T> : IAssetService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public AssetService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task AssignAsset(int Id, string assignedTo, string assetType)
        {
            await _repository.AssignAsset(Id , assignedTo, assetType);
        }

       

        public async Task UnassignAsset(int assetId)
        {
            await _repository.UnassignAsset(assetId);
        }
    }
}
