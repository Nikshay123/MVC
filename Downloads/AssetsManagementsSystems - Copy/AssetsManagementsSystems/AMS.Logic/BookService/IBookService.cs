using AssetsManagementsSystems.DAL;
using AssetsManagementSystems.Api.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Logic.BookService
{
    public  interface IBookService
    {
        Task<BookResponse> AddAsset(BookRequest book);
        Task DeleteAsset(BookRequest book);
        Task<IEnumerable<BookResponse>> GetAllAsset();
        Task<BookRequest> SearchAsset(int id);
        Task UpdateAsset(int id, BookRequest book);
        Task DeleteAssetById(int id);
        Task<string> AssignAsset(int assetId, string assignedTo, string assetType);
        Task<string> UnassignAsset(int assetId);
       
    }
}
