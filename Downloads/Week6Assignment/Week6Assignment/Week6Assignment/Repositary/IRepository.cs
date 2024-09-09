namespace Week6Assignment.Repositary
{
    public interface IRepository<T>where T: class
    {

        Task<IEnumerable<T>> GetAllAssets();
        Task<T>SearchAssets (int id);
        Task<T> AddAssets(T asset);
        Task UpdateAssets(T asset);
        Task  DeleteAsssets (T asset);
        Task<string> AssignAsset(int assetId, string assignedTo, string assetType);
        Task<string> UnassignAsset(int assetId);
    }
}
