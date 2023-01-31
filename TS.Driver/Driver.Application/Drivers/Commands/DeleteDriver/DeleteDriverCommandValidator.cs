using FluentValidation;

namespace Driver.Application.Drivers.Commands.DeleteDriver;

public class DeleteDriverCommandValidator : AbstractValidator<DeleteDriverCommand>
{
    public DeleteDriverCommandValidator()
    {
        RuleFor(_ => _.Id).NotEmpty().WithMessage("آی دی خالی می باشد");
    }
}
