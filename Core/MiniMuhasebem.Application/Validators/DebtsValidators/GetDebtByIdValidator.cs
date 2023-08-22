using FluentValidation;
using MiniMuhasebem.Application.Models.RequestModels.DebtRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebem.Application.Validators.DebtsValidators
{
    public class GetDebtByIdValidator : AbstractValidator<GetDebtByIdVM>
    {
        public GetDebtByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Borç kimlik numarası boş bırakılamaz.")
                .GreaterThan(0)
                .WithMessage("Borç kimlik bilgisi sıfırdan büyük olmalıdır.");
        }
    }
}
