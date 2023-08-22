using FluentValidation;
using MiniMuhasebem.Application.Models.RequestModels.WholasalerRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebem.Application.Validators.WholesalersValidators
{
    public class DeleteWholesalerValidator : AbstractValidator<DeleteWholesalerVM>
    {
        public DeleteWholesalerValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Tedarikçi kimlik numarası boş bırakılamaz.")
                .GreaterThan(0)
                .WithMessage("Tedarikçi kimlik bilgisi sıfırdan büyük olmalıdır.");
        }
    }
}
