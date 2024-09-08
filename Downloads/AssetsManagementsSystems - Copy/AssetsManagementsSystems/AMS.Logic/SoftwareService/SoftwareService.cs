using AssetsManagementsSystems.DAL;
using AssetsManagementsSystems.Repositary;
using AutoMapper;
using AssetsManagementsSystems.Api.Software;

namespace AMS.Logic.SoftwareService
{
    public class SoftwareService : ISoftwareService
    {
        private readonly IRepository<Software> _softwareRepository;
        private readonly IMapper _mapper;

        public SoftwareService(IRepository<Software> softwareRepository, IMapper mapper)
        {
            _softwareRepository = softwareRepository;
            _mapper = mapper;
        }

        public async Task<SoftwareResponse> AddAsset(SoftwareRequest software)
        {
            var softwareEntity = _mapper.Map<Software>(software);
            var savedSoftwareEntity = await _softwareRepository.AddAsset(softwareEntity);
            var softwareDataContractResponse = _mapper.Map<SoftwareResponse>(savedSoftwareEntity);
            return softwareDataContractResponse;
        }

        public async Task DeleteAsset(SoftwareRequest software)
        {
            var softwareEntity = _mapper.Map<Software>(software);
            await _softwareRepository.DeleteAsset(softwareEntity);
        }

        public async Task DeleteAssetById(int id)
        {
            var software = await _softwareRepository.SearchAsset(id);
            if (software != null)
            {
                await _softwareRepository.DeleteAsset(software);
            }
            else
            {
                throw new Exception("Software not found");
            }
        }

        public async Task<IEnumerable<SoftwareResponse>> GetAllAsset()
        {
            var softwares = await _softwareRepository.GetAllAsset();
            var softwareDataContractResponses = _mapper.Map<IEnumerable<SoftwareResponse>>(softwares);
            return softwareDataContractResponses;
        }

        public async Task<SoftwareRequest> SearchAsset(int id)
        {
            var software = await _softwareRepository.SearchAsset(id);
            var softwareDataContractRequest = _mapper.Map<SoftwareRequest>(software);
            return softwareDataContractRequest;
        }

        public async Task UpdateAsset(int id, SoftwareRequest software)
        {
            var softwareEntity = _mapper.Map<Software>(software);
            await _softwareRepository.UpdateAsset(softwareEntity);
        }
    }
}
