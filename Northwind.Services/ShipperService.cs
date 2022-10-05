using AutoMapper;
using Northwind.Domain.Base;
using Northwind.Domain.Models;
using Northwind.Services.Abstraction;
using NorthwindContracts.Dto.Shipper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services
{
    public class ShipperService : IShipperService
    {
        private IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ShipperService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public void Edit(ShipperDto shipperDto)
        {
            var edit = _mapper.Map<Shipper>(shipperDto);
            _repositoryManager.ShipperRepository.Edit(edit);
            _repositoryManager.Save();
        }

        public async Task<IEnumerable<ShipperDto>> GetAllShipper(bool trackChanges)
        {
            var shipperModel = await _repositoryManager.ShipperRepository.GetAllShipper(trackChanges);
            var shipperDto = _mapper.Map<IEnumerable<ShipperDto>>(shipperModel);
            return shipperDto;
        }

        public async Task<ShipperDto> GetShipperById(int shipperId, bool trackChanges)
        {
            var shipperModel = await _repositoryManager.ShipperRepository.GetShipperById(shipperId, trackChanges);
            var shipperDto = _mapper.Map<ShipperDto>(shipperModel);
            return shipperDto;
        }

        public void Remove(ShipperDto shipperDto)
        {
            var remove = _mapper.Map<Shipper>(shipperDto);
            _repositoryManager.ShipperRepository.Remove(remove);
            _repositoryManager.Save();
        }
    }
}
