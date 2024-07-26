using Fiorella.App.Dtos.Blog;
using Fiorella.App.Helpers;
using FluentValidation;

namespace Fiorella.App.Validations.Blog
{
    public class BlogPostDtoValidation:AbstractValidator<BlogPostDto>
    {
        public BlogPostDtoValidation()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Name cannot be empty!")
                .NotNull().WithMessage("Name cannot be null")
                .MinimumLength(3)
                .MaximumLength(30);
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Name cannot be empty!")
                .NotNull().WithMessage("Name cannot be null")
                .MinimumLength(10)
                .MaximumLength(30);
            RuleFor(x => x.formFile).Custom((file, context) =>
            {
                if (!file.IsImage())
                {
                    context.AddFailure("File must be an image");
                }

                if (!file.IsSizeOK(2))
                {
                    context.AddFailure("Image must be less than 2 mbs.");
                }
            });
        }
    }
}
