using FluentValidation;
using MiniMuhasebem.UI.Models.RequestModels.CategoryRM;

namespace MiniMuhasebem.UI.Validators.CategoriesValidators
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryVM>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty()
                .WithMessage("Kategori adı boş olamaz.")
                .MaximumLength(100)
                .WithMessage("Kategori adı 100 karakterden fazla olamaz.");
        }
    }
}
