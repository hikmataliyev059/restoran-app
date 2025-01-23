using FluentValidation;
using restoran_app.Areas.Manage.Helpers.DTOs.Agents;

namespace restoran_app.Areas.Manage.Helpers.Validators.Agents;

public class UpdateAgentDtoValidator : AbstractValidator<UpdateAgentDto>
{
    public UpdateAgentDtoValidator()
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
    }
}
