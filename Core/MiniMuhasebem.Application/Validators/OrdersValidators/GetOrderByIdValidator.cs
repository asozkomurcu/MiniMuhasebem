using FluentValidation;
using MiniMuhasebem.Application.Models.RequestModels.OrderRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebem.Application.Validators.OrdersValidators
{
    public class GetOrderByIdValidator : AbstractValidator<GetOrderByIdVM>
    {
        public GetOrderByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Sipariş kimlik numarası boş bırakılamaz.")
                .GreaterThan(0)
                .WithMessage("Sipariş kimlik bilgisi sıfırdan büyük olmalıdır.");
        }
    }
}
