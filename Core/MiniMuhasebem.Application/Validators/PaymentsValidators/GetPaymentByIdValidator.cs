using FluentValidation;
using MiniMuhasebem.Application.Models.RequestModels.PaymentRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebem.Application.Validators.PaymentsValidators
{
    public class GetPaymentByIdValidator : AbstractValidator<GetPaymentByIdVM>
    {
        public GetPaymentByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Ödeme kimlik numarası boş bırakılamaz.")
                .GreaterThan(0)
                .WithMessage("Ödeme kimlik bilgisi sıfırdan büyük olmalıdır.");
        }
    }
}
