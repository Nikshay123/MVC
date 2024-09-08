using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetsManagementsSystems.DAL;
using AssetsManagementsSystems.Repositary;

namespace Week6Assignment.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbSet<T> _dbSet;
        private readonly AssetDbContext _assetDbContext;

        public Repository(AssetDbContext assetDbContext)
        {
            _assetDbContext = assetDbContext;
            _dbSet = assetDbContext.Set<T>();
        }

        public async Task<T> AddAsset(T asset)
        {
            await _dbSet.AddAsync(asset);
            await _assetDbContext.SaveChangesAsync();
            return asset;
        }

        public async Task DeleteAsset(T asset)
        {
            _dbSet.Remove(asset);
            await _assetDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsset()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> SearchAsset(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsset(T asset)
        {
            _assetDbContext.Entry(asset).State = EntityState.Modified;
            await _assetDbContext.SaveChangesAsync();
        }

        public async Task DeleteAssetById(int id)
        {
            var asset = await _dbSet.FindAsync(id);
            if (asset != null)
            {
                _dbSet.Remove(asset);
                await _assetDbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Asset not found");
            }
        }
        public async Task<string> AssignAsset(int AssetId, string assignedTo, string assetType)
        {
            // Check if the asset is already assigned to the given person for the given type
            var existingAssignment = await _assetDbContext.Assign.FirstOrDefaultAsync(a => a.AssetId == AssetId && a.AssignedTo == assignedTo && a.AssetType == assetType);
            if (existingAssignment != null)
            {
                return "Asset already assigned";
            }

            try
            {
                // Create a new assignment
                var assignAsset = new AssignAsset
                {
                    AssetId = AssetId,
                    AssignedTo = assignedTo,
                    AssetType = assetType
                };

                // Add the assignment to the database and save changes
                _assetDbContext.Assign.Add(assignAsset);
                await _assetDbContext.SaveChangesAsync();

                return "Asset assigned successfully";
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during assignment
                return $"Error assigning asset: {ex.Message}";
            }
        }

        public async Task<string> UnassignAsset(int assetId)
        {
            var unassignedAsset = await _assetDbContext.Assign.FirstOrDefaultAsync(a => a.Id == assetId);
            if (unassignedAsset != null)
            {
                _assetDbContext.Assign.Remove(unassignedAsset);
                await _assetDbContext.SaveChangesAsync();
                return "Asset unassigned successfully";
            }
            else
            {
                return "Asset not found";
            }
        }
    }
}
