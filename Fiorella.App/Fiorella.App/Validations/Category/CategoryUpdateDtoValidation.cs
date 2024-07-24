using Fiorella.App.Dtos.Category;
using FluentValidation;

namespace Fiorella.App.Validations.Category
{
    public class CategoryUpdateDtoValidation:AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateDtoValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty!")
                .NotNull().WithMessage("Name cannot be null")
                .MinimumLength(3)
                .MaximumLength(30);
        }
    }
}
