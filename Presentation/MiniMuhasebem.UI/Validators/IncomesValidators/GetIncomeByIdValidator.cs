﻿using FluentValidation;
using MiniMuhasebem.UI.Models.RequestModels.IncomeRM;

namespace MiniMuhasebem.UI.Validators.IncomesValidators
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
