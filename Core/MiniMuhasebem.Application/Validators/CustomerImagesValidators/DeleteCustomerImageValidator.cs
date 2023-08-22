using FluentValidation;
using MiniMuhasebem.Application.Models.RequestModels.CustomerImageRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebem.Application.Validators.CustomerImagesValidators
{
    public class DeleteCustomerImageValidator : AbstractValidator<DeleteCustomerImageVM>
    {
        public DeleteCustomerImageValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("Silinecek kullanıcı resmine ait kimlik bilgisi boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Silinecek kullanıcı resmi kimlik bilgisi sıfırdan büyük olmalıdır.");
        }
    }
}
