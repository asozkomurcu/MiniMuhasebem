﻿using FluentValidation;
using MiniMuhasebem.Application.Models.RequestModels.PaymentRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebem.Application.Validators.PaymentsValidators
{
    public class CreatePaymentValidator : AbstractValidator<CreatePaymentVM>
    {
        public CreatePaymentValidator()
        {
            RuleFor(x => x.WholesalerId)
                .NotEmpty()
                .WithMessage("Tedarikçi kimlik numarası boş bırakılamaz.")
                .GreaterThan(0)
                .WithMessage("Tedarikçi kimlik bilgisi sıfırdan büyük olmalıdır.");

            RuleFor(x => x.OrderPayment)
                .NotEmpty()
                .WithMessage("Sipariş için yapılan ödeme tutarı boş bırakılamaz.")
                .GreaterThan(0)
                .WithMessage("Sipariş için yapılan ödeme tutarı sıfırdan büyük olmalıdır.");

            RuleFor(x => x.PaymentType)
               .NotEmpty()
               .WithMessage("Yapılan ödeme tür bilgisi boş olamaz.")
               .IsInEnum()
               .WithMessage("Yapılan ödeme tür bilgisi geçerli değil. ( 1(Nakit) veya 2(Kredi kartı) olabilir.)");
        }
    }
}
