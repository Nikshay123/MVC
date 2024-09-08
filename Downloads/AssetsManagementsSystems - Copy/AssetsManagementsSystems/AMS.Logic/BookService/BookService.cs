using AssetsManagementSystems.Api.Books;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssetsManagementsSystems.Repositary;
using AssetsManagementsSystems.DAL;
using AutoMapper;

namespace AMS.Logic.BookService
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IRepository<Book> bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookResponse> AddAsset(BookRequest book)
        {
            var bookEntity = _mapper.Map<Book>(book);
            var savedBookEntity = await _bookRepository.AddAsset(bookEntity);
            var bookDataContractResponse = _mapper.Map<BookResponse>(savedBookEntity);
            return bookDataContractResponse;
        }

        public async Task DeleteAsset(BookRequest book)
        {
            var bookEntity = _mapper.Map<Book>(book);
            await _bookRepository.DeleteAsset(bookEntity);
        }

        public async Task DeleteAssetById(int id)
        {
            var book = await _bookRepository.SearchAsset(id);
            if (book != null)
            {
                await _bookRepository.DeleteAsset(book);
            }
            else
            {
                throw new Exception("Book not found");
            }
        }

        public async Task<IEnumerable<BookResponse>> GetAllAsset()
        {
            var books = await _bookRepository.GetAllAsset();
            var bookDataContractResponses = _mapper.Map<IEnumerable<BookResponse>>(books);
            return bookDataContractResponses;
        }

        public async Task<BookRequest> SearchAsset(int id)
        {
            var book = await _bookRepository.SearchAsset(id);
            var bookDataContractRequest = _mapper.Map<BookRequest>(book);
            return bookDataContractRequest;
        }

        public async Task UpdateAsset(int id, BookRequest book)
        {
            var bookEntity = _mapper.Map<Book>(book);
            await _bookRepository.UpdateAsset(bookEntity);
        }
        public async Task<string> AssignAsset(int assetId, string assignedTo, string assetType)
        {
            return await _bookRepository.AssignAsset(assetId, assignedTo, assetType);
        }

        public async Task<string> UnassignAsset(int assetId)
        {
            return await _bookRepository.UnassignAsset(assetId);


        }
    }
}
