using FluentValidation;
using MiniMuhasebem.UI.Models.RequestModels.WholasalerRM;

namespace MiniMuhasebem.UI.Validators.WholesalersValidators
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
