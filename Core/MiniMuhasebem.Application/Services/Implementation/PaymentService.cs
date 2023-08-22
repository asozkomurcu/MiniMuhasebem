﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MiniMuhasebem.Application.Behaviors;
using MiniMuhasebem.Application.Exceptions;
using MiniMuhasebem.Application.Models.Dtos.PaymentDtos;
using MiniMuhasebem.Application.Models.RequestModels.PaymentRM;
using MiniMuhasebem.Application.Services.Abstraction;
using MiniMuhasebem.Application.Validators.PaymentsValidators;
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
    public class PaymentService : IPaymentService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _uWork;

        public PaymentService(IMapper mapper, IUnitWork uWork)
        {
            _mapper = mapper;
            _uWork = uWork;
        }

        public async Task<Result<List<PaymentDto>>> GetAllPayments()
        {
            var result = new Result<List<PaymentDto>>();

            var paymentEntites = await _uWork.GetRepository<Payment>().GetAllAsync();

            var paymentDtos = await paymentEntites.ProjectTo<PaymentDto>(_mapper.ConfigurationProvider).ToListAsync();
            result.Data = paymentDtos;
            _uWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(GetPaymentByIdValidator))]
        public async Task<Result<PaymentDto>> GetPaymentById(int id)
        {
            var result = new Result<PaymentDto>();

            var paymentEntites = await _uWork.GetRepository<Payment>().GetSingleByFilterAsync(x => x.Id == id);
            if (paymentEntites == null)
            {
                throw new NotFoundException($"{id} numaralı ödeme bilgisi bulunamadı.");
            }

            var paymentDtos = _mapper.Map<PaymentDto>(paymentEntites);
            result.Data = paymentDtos;
            return result;
        }

        [ValidationBehavior(typeof(CreatePaymentValidator))]
        public async Task<Result<int>> CreatePayments(CreatePaymentVM createPaymentVM)
        {
            var result = new Result<int>();

            var paymentEntites = _mapper.Map<CreatePaymentVM, Payment>(createPaymentVM);


            _uWork.GetRepository<Payment>().Add(paymentEntites);
            await _uWork.CommitAsync();

            result.Data = paymentEntites.Id;
            _uWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(UpdatePaymentValidator))]
        public async Task<Result<bool>> UpdatePayments(UpdatePaymentVM updatePaymentVM)
        {
            var result = new Result<bool>();

            var paymentEntites = await _uWork.GetRepository<Payment>().GetSingleByFilterAsync(x => x.Id == updatePaymentVM.Id);
            if (paymentEntites == null)
            {
                throw new NotFoundException($"{updatePaymentVM.Id} numaralı ödeme bilgisi bulunamadı.");
            }

            var existspaymentEntity = await _uWork.GetRepository<Payment>().GetById(updatePaymentVM.Id.Value);

            _mapper.Map(updatePaymentVM, existspaymentEntity);

            _uWork.GetRepository<Payment>().Update(existspaymentEntity);

            result.Data = await _uWork.CommitAsync();
            return result;
        }


    }
}
