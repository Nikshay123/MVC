using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Week6Assignment.Repositary;
using Week6Assignment.Repository;

namespace Week6Assignment.Services
{
    public class AssetService<T> : IAssetService<T> where T : class
    {
        private readonly IRepository<T> _assetRepository;

        public AssetService(IRepository<T> assetRepository)
        {
            _assetRepository = assetRepository;
        }

        public async Task<T> AddAsset(T asset)
        {
            await _assetRepository.AddAssets(asset);
            return asset;
        }

        public async Task DeleteAsset(T asset)
        {
            await _assetRepository.DeleteAsssets(asset);
        }

        public async Task<IEnumerable<T>> GetAllAsset()
        {
            return await _assetRepository.GetAllAssets();
        }

        public async Task<T> SearchAsset(int id)
        {
            return await _assetRepository.SearchAssets(id);
        }

        public async Task UpdateAsset(T asset)
        {
            await _assetRepository.UpdateAssets(asset);
        }

        public async Task DeleteAssetById(int id)
        {
            var asset = await _assetRepository.SearchAssets(id);
            if (asset != null)
            {
                await _assetRepository.DeleteAsssets(asset);
            }
            else
            {
                throw new Exception("Asset not found");
            }
        }
        public async Task<string> AssignAsset(int assetId, string assignedTo, string assetType)
        {
            return await _assetRepository.AssignAsset(assetId, assignedTo, assetType);
        }
        public async Task<string> UnassignAsset(int assetId)
        {
            return await _assetRepository.UnassignAsset(assetId);
        }

    }
}
