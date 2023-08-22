using FluentValidation;
using MiniMuhasebem.Application.Models.RequestModels.CategoryRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebem.Application.Validators.CategoriesValidators
{
    public class GetCategoryByIdValidator : AbstractValidator<GetCategoryByIdVM>
    {
        public GetCategoryByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Kategori kimlik numarası boş bırakılamaz.")
                .GreaterThan(0)
                .WithMessage("Kategori kimlik bilgisi sıfırdan büyük olmalıdır.");
        }
    }
}
