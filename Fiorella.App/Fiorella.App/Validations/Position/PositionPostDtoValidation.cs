using Fiorella.App.Dtos.Position;
using FluentValidation;

namespace Fiorella.App.Validations.Category
{
    public class PositionPostDtoValidation:AbstractValidator<PositionPostDto>
    {
        public PositionPostDtoValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty!")
                .NotNull().WithMessage("Name cannot be null")
                .MinimumLength(3)
                .MaximumLength(30);
        }
    }
}
