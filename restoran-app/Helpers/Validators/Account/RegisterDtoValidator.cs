using FluentValidation;
using restoran_app.Helpers.DTOs.Account;

namespace restoran_app.Helpers.Validators.Account;

public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator()
    {
        RuleFor(x => x.FullName)
          .NotEmpty()
          .NotNull()
          .WithMessage("Full Name cannot be empty or null")
          .MinimumLength(3)
          .WithMessage("Enter a minimum of 3 characters")
          .MaximumLength(30)
          .WithMessage("Enter a maximum of 30 characters");

        RuleFor(x => x.Email)
         .NotEmpty()
         .NotNull()
         .WithMessage("Email cannot be empty or null")
         .MinimumLength(3)
         .WithMessage("Enter a minimum of 3 characters")
         .EmailAddress()
         .WithMessage("Enter the email type correctly");

        RuleFor(x => x.Password)
        .NotEmpty()
        .NotNull()
        .WithMessage("Password cannot be empty or null")
        .MinimumLength(4)
        .WithMessage("Enter a minimum of 4 characters")
        .Matches("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$")
        .WithMessage("Enter the correct password type");

        RuleFor(x => x.ConfirmPassword)
        .NotEmpty()
        .NotNull()
        .WithMessage("Confirm Password cannot be empty or null")
        .MinimumLength(4)
        .WithMessage("Enter a minimum of 4 characters")
        .Equal(x => x.Password)
        .WithMessage("Passwords don't matches");
    }
}
