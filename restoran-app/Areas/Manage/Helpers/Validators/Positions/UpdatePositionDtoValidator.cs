using FluentValidation;
using restoran_app.Areas.Manage.Helpers.DTOs.Positions;

namespace restoran_app.Areas.Manage.Helpers.Validators.Positions;

public class UpdatePositionDtoValidator : AbstractValidator<UpdatePositionDto>
{
    public UpdatePositionDtoValidator()
    {
        RuleFor(x => x.Name)
           .NotEmpty()
           .NotNull()
           .WithMessage("Name cannot be empty or null")
           .MinimumLength(3)
           .WithMessage("Enter a minimum of 3 characters")
           .MaximumLength(30)
           .WithMessage("Enter a maximum of 30 characters");
    }
}
