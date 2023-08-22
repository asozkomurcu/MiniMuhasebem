﻿using FluentValidation;
using MiniMuhasebem.UI.Models.RequestModels.OrderRM;

namespace MiniMuhasebem.UI.Validators.OrdersValidators
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderVM>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.WholesalerId)
                .NotEmpty()
                .WithMessage("Tedarikçi kimlik numarası boş bırakılamaz.")
                .GreaterThan(0)
                .WithMessage("Tedarikçi kimlik bilgisi sıfırdan büyük olmalıdır.");

            RuleFor(x => x.OrderPrice)
                .NotEmpty()
                .WithMessage("Sipariş tutarı boş bırakılamaz.")
                .GreaterThan(0)
                .WithMessage("Sipariş tutarı sıfırdan büyük olmalıdır.");
        }
    }
}
