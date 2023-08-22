using FluentValidation;
using MiniMuhasebem.Application.Models.RequestModels.WholasalerRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebem.Application.Validators.WholesalersValidators
{
    public class CreateWholesalerValidator : AbstractValidator<CreateWholesalerVM>
    {
        public CreateWholesalerValidator()
        {
            RuleFor(x => x.WholesalerName)
                .NotEmpty()
                .WithMessage("Tedarikçi adı boş olamaz.")
                .MaximumLength(50)
                .WithMessage("Tedarikçi adı 50 karakterden fazla olamaz.");
        }
    }
}
