using FluentValidation;

namespace Factor.Application.Factors.Commands.DeleteFactor;

public class DeleteFactorCommandValidator : AbstractValidator<DeleteFactorCommand>
{
    public DeleteFactorCommandValidator()
    {
        RuleFor(_ => _.Id).NotEmpty().WithMessage("آی دی خالی می باشد");
    }
}
