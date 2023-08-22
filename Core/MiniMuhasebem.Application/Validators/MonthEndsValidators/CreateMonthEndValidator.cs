using FluentValidation;
using MiniMuhasebem.Application.Models.RequestModels.MonthEndRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebem.Application.Validators.MonthEndsValidators
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
