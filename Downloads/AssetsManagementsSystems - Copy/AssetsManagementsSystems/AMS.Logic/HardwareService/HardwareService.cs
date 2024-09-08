using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssetsManagementSystems.Api.Hardware;
using AssetsManagementsSystems.DAL;
using AssetsManagementsSystems.Repositary;
using AutoMapper;

namespace AMS.Logic.HardwareService
{
    public class HardwareService : IHardwareService
    {
        private readonly IRepository<Hardware> _hardwareRepository;
        private readonly IMapper _mapper;

        public HardwareService(IRepository<Hardware> hardwareRepository, IMapper mapper)
        {
            _hardwareRepository = hardwareRepository;
            _mapper = mapper;
        }

        public async Task<HardwareResponse> AddAsset(HardwareRequest hardware)
        {
            var hardwareEntity = _mapper.Map<Hardware>(hardware);
            var savedHardwareEntity = await _hardwareRepository.AddAsset(hardwareEntity);
            var hardwareDataContractResponse = _mapper.Map<HardwareResponse>(savedHardwareEntity);
            return hardwareDataContractResponse;
        }

        public async Task DeleteAsset(HardwareRequest hardware)
        {
            var hardwareEntity = _mapper.Map<Hardware>(hardware);
            await _hardwareRepository.DeleteAsset(hardwareEntity);
        }

        public async Task DeleteAssetById(int id)
        {
            var hardware = await _hardwareRepository.SearchAsset(id);
            if (hardware != null)
            {
                await _hardwareRepository.DeleteAsset(hardware);
            }
            else
            {
                throw new Exception("Hardware not found");
            }
        }

        public async Task<IEnumerable<HardwareResponse>> GetAllAsset()
        {
            var hardwares = await _hardwareRepository.GetAllAsset();
            var hardwareDataContractResponses = _mapper.Map<IEnumerable<HardwareResponse>>(hardwares);
            return hardwareDataContractResponses;
        }

        public async Task<HardwareRequest> SearchAsset(int id)
        {
            var hardware = await _hardwareRepository.SearchAsset(id);
            var hardwareDataContractRequest = _mapper.Map<HardwareRequest>(hardware);
            return hardwareDataContractRequest;
        }

        public async Task UpdateAsset(int id, HardwareRequest hardware)
        {
            var hardwareEntity = _mapper.Map<Hardware>(hardware);
            await _hardwareRepository.UpdateAsset(hardwareEntity);
        }
    }
}
