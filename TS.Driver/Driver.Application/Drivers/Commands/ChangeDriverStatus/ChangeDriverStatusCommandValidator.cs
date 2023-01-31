using FluentValidation;

namespace Driver.Application.Drivers.Commands.ChangeDriverStatus;

public class ChangeDriverStatusCommandValidator : AbstractValidator<ChangeDriverStatusCommand>
{
    public ChangeDriverStatusCommandValidator()
    {
        RuleFor(_ => _.Id).NotEmpty().WithMessage("آی دی خالی می باشد");
    }
}
