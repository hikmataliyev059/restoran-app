using FluentValidation;
using restoran_app.Areas.Manage.Helpers.DTOs.Agents;

namespace restoran_app.Areas.Manage.Helpers.Validators.Agents;

public class CreateAgentDtoValidator : AbstractValidator<CreateAgentDto>
{
    public CreateAgentDtoValidator()
    {
        RuleFor(x => x.Name)
           .NotEmpty()
           .NotNull()
           .WithMessage("Name cannot be empty or null")
           .MinimumLength(3)
           .WithMessage("Enter a minimum of 3 characters")
           .MaximumLength(30)
           .WithMessage("Enter a maximum of 30 characters");

        RuleFor(x => x.PositionId)
          .NotEmpty()
          .NotNull()
          .WithMessage("Position cannot be empty or null");

        RuleFor(x => x.File)
         .NotEmpty()
         .NotNull()
         .WithMessage("File cannot be empty or null");
    }
}
