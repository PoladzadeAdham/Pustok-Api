using FluentValidation;
using Pustok.Buisness.Helpers;

namespace Pustok.Buisness.Validators.ProductValidators
{
    public class EmployeeUpdateDtoValidator : AbstractValidator<EmployeeUpdateDto>
    {
        public EmployeeUpdateDtoValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().MaximumLength(256)
                .MinimumLength(3);

            RuleFor(x => x.Salary)
                .NotNull().GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(10000000);

            RuleFor(x => x.Image)
                .Must(x => x?.CheckSize(2) ?? true).WithMessage("Image max size must be 2 mb")
                .Must(x => x?.CheckType("image") ?? true).WithMessage("You can upload file only image format");

        }

    }

}
