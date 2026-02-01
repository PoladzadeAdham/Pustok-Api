using FluentValidation;
using Pustok.Buisness.Dtos.UserDtos;

namespace Pustok.Buisness.Validators.UserValidators
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username boş ola bilməz")
            .MinimumLength(3).WithMessage("Username minimum 3 simvol olmalıdır");

            RuleFor(x => x.Fullname)
                .NotEmpty().WithMessage("Fullname boş ola bilməz")
                .MinimumLength(3).WithMessage("Fullname minimum 3 simvol olmalıdır");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email boş ola bilməz")
                .EmailAddress().WithMessage("Email formatı yanlışdır");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password boş ola bilməz")
                .MinimumLength(6).WithMessage("Password minimum 6 simvol olmalıdır")
                .Matches("[a-z]").WithMessage("Password ən azı 1 kiçik hərf içərməlidir")
                .Matches("[0-9]").WithMessage("Password ən azı 1 rəqəm içərməlidir");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password)
                .WithMessage("ConfirmPassword Password ilə eyni olmalıdır");


        }

    }
}
