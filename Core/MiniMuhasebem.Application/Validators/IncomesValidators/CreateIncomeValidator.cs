using FluentValidation;
using MiniMuhasebem.Application.Models.RequestModels.IncomeRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebem.Application.Validators.IncomesValidators
{
    public class CreateIncomeValidator : AbstractValidator<CreateIncomeVM>
    {
        public CreateIncomeValidator()
        {
            RuleFor(x => x.Cash)
                .NotNull().WithMessage("Nakit para alanı boş olamaz.")
                .GreaterThan(-1).WithMessage("Nakit para alanı sıfır veya daha büyük bir değer olmalı.");

            RuleFor(x => x.CreditCard1)
                .NotNull().WithMessage("Kredi Kartı alanı boş olamaz.")
                .GreaterThan(-1).WithMessage("Kredi Kartı alanı sıfır veya daha büyük bir değer olmalı.");

            RuleFor(x => x.CreditCard2)
                .NotNull().WithMessage("Kredi Kartı alanı boş olamaz.")
                .GreaterThan(-1).WithMessage("Kredi Kartı alanı sıfır veya daha büyük bir değer olmalı.");
        }
    }
}
