﻿using AutoMapper;
using Northwind.Domain.Base;
using Northwind.Domain.Models;
using Northwind.Services.Abstraction;
using NorthwindContracts.Dto.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services
{
    public class OrderService : IOrderService
    {
        private IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public OrderService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public OrderDto CreateOrderId(OrderForCreateDto orderForCreateDto)
        {
            var order = _mapper.Map<Order>(orderForCreateDto);
            _repositoryManager.OrderRepository.Insert(order);
            _repositoryManager.Save();
            var orderDto = _mapper.Map<OrderDto>(order);
            return orderDto;
        }

        public void Edit(OrderDto orderDto)
        {
            var edit = _mapper.Map<Order>(orderDto);
            _repositoryManager.OrderRepository.Edit(edit);
            _repositoryManager.Save();
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrder(bool trackChanges)
        {
            var orderModel = await _repositoryManager.OrderRepository.GetAllOrder(trackChanges);
            var orderDto = _mapper.Map<IEnumerable<OrderDto>>(orderModel);
            return orderDto;
        }

        public async Task<OrderDto> GetOrderById(int orderId, bool trackChanges)
        {
            var orderModel = await _repositoryManager.OrderRepository.GetOrderById(orderId, trackChanges);
            var orderDto = _mapper.Map<OrderDto>(orderModel);
            return orderDto;
        }

        public void Remove(OrderDto orderDto)
        {
            var remove = _mapper.Map<Order>(orderDto);
            _repositoryManager.OrderRepository.Remove(remove);
            _repositoryManager.Save();
        }

        public void Insert(OrderForCreateDto orderForCreateDto)
        {
            var insert = _mapper.Map<Order>(orderForCreateDto);
            _repositoryManager.OrderRepository.Insert(insert);
            _repositoryManager.Save();
        }
    }
}
