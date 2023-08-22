using FluentValidation;
using MiniMuhasebem.Application.Models.RequestModels.CustomerImageRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebem.Application.Validators.CustomerImagesValidators
{
    public class GetAllCustomerImageByCustomerValidator : AbstractValidator<GetAllCustomerImageByCustomerVM>
    {
        public GetAllCustomerImageByCustomerValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotNull().WithMessage("Kullanıcıya ait kimlik bilgisi boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Kullanıcıya ait kimlik bilgisi sıfırdan büyük olmalıdır.");
        }
    }
}
