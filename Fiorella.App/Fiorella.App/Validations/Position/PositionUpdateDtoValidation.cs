using Fiorella.App.Dtos.Position;
using FluentValidation;

namespace Fiorella.App.Validations.Position
{
    public class PositionUpdateDtoValidation:AbstractValidator<PositionUpdateDto>
    {
        public PositionUpdateDtoValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty!")
                .NotNull().WithMessage("Name cannot be null")
                .MinimumLength(3)
                .MaximumLength(30);
        }
    }
}
