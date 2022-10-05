using AutoMapper;
using Northwind.Domain.Base;
using Northwind.Domain.Models;
using Northwind.Services.Abstraction;
using NorthwindContracts.Dto.OrderDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public OrderDetailService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public void Edit(OrderDetailDto orderDetailDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderDetailDto>> GetAllOrderDetail(bool trackChanges)
        {
            var orderDetailModel = await _repositoryManager.OrderDetailRepository.GetAllOrderDetail(trackChanges);
            var orderDetailDto = _mapper.Map<IEnumerable<OrderDetailDto>>(orderDetailModel);
            return orderDetailDto;
        }

        public async Task<OrderDetailDto> GetOrderDetailById(int orderId, bool trackChanges)
        {
            var orderDetailModel = await _repositoryManager.OrderDetailRepository.GetOrderDetailById(orderId, trackChanges);
            var orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetailModel);
            return orderDetailDto;
        }

        public void Remove(OrderDetailDto orderDetailDto)
        {
            var remove = _mapper.Map<OrderDetail>(orderDetailDto);
            _repositoryManager.OrderDetailRepository.Remove(remove);
            _repositoryManager.Save();
        }

        public void Insert(OrderDetailForCreateDto orderDetailForCreateDto)
        {
            var insert = _mapper.Map<OrderDetail>(orderDetailForCreateDto);
            _repositoryManager.OrderDetailRepository.Insert(insert);
            _repositoryManager.Save();
        }
    }
}
