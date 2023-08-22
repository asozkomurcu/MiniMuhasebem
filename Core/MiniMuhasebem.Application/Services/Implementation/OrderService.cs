﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MiniMuhasebem.Application.Behaviors;
using MiniMuhasebem.Application.Exceptions;
using MiniMuhasebem.Application.Models.Dtos.OrderDtos;
using MiniMuhasebem.Application.Models.RequestModels.OrderRM;
using MiniMuhasebem.Application.Services.Abstraction;
using MiniMuhasebem.Application.Validators.OrdersValidators;
using MiniMuhasebem.Application.Wrapper;
using MiniMuhasebem.Domain.Entities;
using MiniMuhasebem.Domain.UWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebem.Application.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _uWork;

        public OrderService(IMapper mapper, IUnitWork uWork)
        {
            _mapper = mapper;
            _uWork = uWork;
        }

        public async Task<Result<List<OrderDto>>> GetAllOrder()
        {
            var result = new Result<List<OrderDto>>();

            var orderEntites = await _uWork.GetRepository<Order>().GetAllAsync();

            var orderDtos = await orderEntites.ProjectTo<OrderDto>(_mapper.ConfigurationProvider).ToListAsync();
            result.Data = orderDtos;
            _uWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(GetOrderByIdValidator))]
        public async Task<Result<OrderDto>> GetOrderById(int id)
        {
            var result = new Result<OrderDto>();

            var orderEntites = await _uWork.GetRepository<Order>().GetSingleByFilterAsync(x => x.Id == id);
            if (orderEntites == null)
            {
                throw new NotFoundException($"{id} numaralı sipariş bilgisi bulunamadı.");
            }

            var orderDtos = _mapper.Map<OrderDto>(orderEntites);
            result.Data = orderDtos;
            return result;
        }

        [ValidationBehavior(typeof(CreateOrderValidator))]
        public async Task<Result<int>> CreateOrder(CreateOrderVM createOrderVM)
        {
            var result = new Result<int>();

            var orderEntites = _mapper.Map<CreateOrderVM, Order>(createOrderVM);


            _uWork.GetRepository<Order>().Add(orderEntites);
            await _uWork.CommitAsync();

            result.Data = orderEntites.Id;
            _uWork.Dispose();
            return result;

        }

        [ValidationBehavior(typeof(UpdateOrderValidator))]
        public async Task<Result<bool>> UpdateOrder(UpdateOrderVM updateOrderVM)
        {
            var result = new Result<bool>();

            var orderEntites = await _uWork.GetRepository<Order>().GetSingleByFilterAsync(x => x.Id == updateOrderVM.Id);
            if (orderEntites == null)
            {
                throw new NotFoundException($"{updateOrderVM.Id} numaralı sipariş bilgisi bulunamadı.");
            }

            var existsOrderEntity = await _uWork.GetRepository<Order>().GetById(updateOrderVM.Id.Value);

            _mapper.Map(updateOrderVM, existsOrderEntity);

            _uWork.GetRepository<Order>().Update(existsOrderEntity);

            result.Data = await _uWork.CommitAsync();
            return result;
        }


    }
}
