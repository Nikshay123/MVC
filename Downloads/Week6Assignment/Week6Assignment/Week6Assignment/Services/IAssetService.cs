namespace Week6Assignment.Services
{
    public interface IAssetService<T>where T : class
    {
        Task<T> AddAsset(T asset);
        Task DeleteAsset(T asset);
        Task<IEnumerable<T>> GetAllAsset();
        Task<T> SearchAsset(int id);
        Task UpdateAsset(T asset);
        Task DeleteAssetById (int id);
        Task<string> AssignAsset(int assetId, string assignedTo, string assetType);
        Task<string> UnassignAsset(int assetId);


    }
}
