using FluentValidation;
using MiniMuhasebem.Application.Models.RequestModels.OrderRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebem.Application.Validators.OrdersValidators
{
    public class UpdateOrderValidator : AbstractValidator<UpdateOrderVM>
    {
        public UpdateOrderValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty()
               .WithMessage("Sipariş kimlik numarası boş bırakılamaz.")
               .GreaterThan(0)
               .WithMessage("Sipariş kimlik bilgisi sıfırdan büyük olmalıdır.");

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
