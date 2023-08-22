using FluentValidation;
using MiniMuhasebem.Application.Models.RequestModels.IncomeRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebem.Application.Validators.IncomesValidators
{
    public class GetIncomeByIdValidator : AbstractValidator<GetIncomeByIdVM>
    {
        public GetIncomeByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Günlük hesap kimlik numarası boş bırakılamaz.")
                .GreaterThan(0)
                .WithMessage("Günlük hesap kimlik bilgisi sıfırdan büyük olmalıdır.");
        }
    }
}
