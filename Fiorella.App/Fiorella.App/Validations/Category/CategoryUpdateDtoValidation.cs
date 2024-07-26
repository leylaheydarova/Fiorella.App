﻿using Fiorella.App.Dtos.Category;
using FluentValidation;

namespace Fiorella.App.Validations.Category
{
    public class PositionUpdateDtoValidation:AbstractValidator<CategoryUpdateDto>
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
