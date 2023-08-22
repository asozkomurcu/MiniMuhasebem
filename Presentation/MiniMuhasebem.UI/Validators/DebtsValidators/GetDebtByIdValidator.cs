using FluentValidation;
using MiniMuhasebem.UI.Models.RequestModels.DebtRM;

namespace MiniMuhasebem.UI.Validators.DebtsValidators
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
