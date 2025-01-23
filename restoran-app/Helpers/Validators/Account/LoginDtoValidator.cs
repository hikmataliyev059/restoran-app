using FluentValidation;
using restoran_app.Helpers.DTOs.Account;

namespace restoran_app.Helpers.Validators.Account;

public class LoginDtoValidator : AbstractValidator<LoginDto>
{
    public LoginDtoValidator()
    {
        RuleFor(x => x.EmailOrUsername)
         .NotEmpty()
         .NotNull()
         .WithMessage("Email or Username cannot be empty or null")
         .MinimumLength(3)
         .WithMessage("Enter a minimum of 3 characters")
         .MaximumLength(30)
         .WithMessage("Enter a maximum of 30 characters");

        RuleFor(x => x.Password)
         .NotEmpty()
         .NotNull()
         .WithMessage("Password cannot be empty or null")
         .MinimumLength(4)
         .WithMessage("Enter a minimum of 4 characters")
         .Matches("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$")
         .WithMessage("Enter the correct password type");
    }
}
