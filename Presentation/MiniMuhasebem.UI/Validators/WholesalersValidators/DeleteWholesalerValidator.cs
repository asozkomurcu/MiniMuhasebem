using FluentValidation;
using MiniMuhasebem.UI.Models.RequestModels.WholasalerRM;

namespace MiniMuhasebem.UI.Validators.WholesalersValidators
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
