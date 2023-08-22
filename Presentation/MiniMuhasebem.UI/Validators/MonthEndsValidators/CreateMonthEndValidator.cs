using FluentValidation;
using MiniMuhasebem.UI.Models.RequestModels.MonthEndRM;

namespace MiniMuhasebem.UI.Validators.MonthEndsValidators
{
    public class CreateMonthEndValidator : AbstractValidator<CreateMonthEndVM>
    {
        public CreateMonthEndValidator()
        {
            RuleFor(x => x.RaporOlustur)
                .NotNull();
        }
    }
}
