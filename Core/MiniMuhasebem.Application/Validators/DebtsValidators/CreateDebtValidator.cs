using FluentValidation;
using MiniMuhasebem.Application.Models.RequestModels.DebtRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebem.Application.Validators.DebtsValidators
{
    public class CreateDebtValidator : AbstractValidator<CreateDebtVM>
    {
        public CreateDebtValidator()
        {
            RuleFor(x => x.WholesalerId)
                .NotEmpty()
                .WithMessage("Tedarikçi kimlik numarası boş bırakılamaz.")
                .GreaterThan(0)
                .WithMessage("Tedarikçi kimlik bilgisi sıfırdan büyük olmalıdır.");

            RuleFor(x => x.OrderDebt)
                .NotEmpty()
                .WithMessage("Sipariş tutarı boş bırakılamaz.")
                .GreaterThan(0)
                .WithMessage("Sipariş tutarı sıfırdan büyük olmalıdır.");
        }
    }
}
