using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Week6Assignment.DAL;
using Week6Assignment.Repositary;

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

        public async Task<T> AddAssets(T asset)
        {
            await _dbSet.AddAsync(asset);
            await _assetDbContext.SaveChangesAsync();
            return asset;
        }

        public async Task DeleteAsssets(T asset)
        {
            _dbSet.Remove(asset);
            await _assetDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAssets()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> SearchAssets(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAssets(T entity)
        {
            _assetDbContext.Entry(entity).State = EntityState.Modified;
            await _assetDbContext.SaveChangesAsync();
        }

        public async Task<string> AssignAsset(int assetId, string assignedTo, string assetType)
        {
            // Check if an entry with the same details already exists
            var existingAssignment = await _assetDbContext.Assign.FirstOrDefaultAsync(a => a.AssetId == assetId && a.AssignedTo == assignedTo && a.AssetType == assetType);
            if (existingAssignment != null)
            {
                return "Asset already assigned";
            }

            // If not, add the new assignment
            var assignAsset = new AssignAsset
            {
                AssetId = assetId,
                AssignedTo = assignedTo,
                AssetType = assetType
            };

            await _assetDbContext.Assign.AddAsync(assignAsset);
            await _assetDbContext.SaveChangesAsync();
            return "Asset assigned successfully";
        }
        public async Task<string> UnassignAsset(int assetId)
        {
            var unassignedAsset = await _assetDbContext.Assign.FirstOrDefaultAsync(a => a.AssetId == assetId);
            if (unassignedAsset == null)
            {
                return "Asset not found";
            }

            _assetDbContext.Assign.Remove(unassignedAsset);
            await _assetDbContext.SaveChangesAsync();
            return "Asset unassigned successfully";
        }


    }
}
