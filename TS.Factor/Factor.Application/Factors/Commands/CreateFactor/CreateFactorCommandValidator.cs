using FluentValidation;
using SH.InfrastructureEfCore.Consts;

namespace Factor.Application.Factors.Commands.CreateFactor;

public class CreateFactorCommandValidator : AbstractValidator<CreateFactorCommand>
{
    public CreateFactorCommandValidator()
    {
        RuleFor(_ => _.DriverId).NotEmpty().WithMessage("آی دی راننده خالی می باشد");

        RuleFor(_ => _.JourneyId).NotEmpty().WithMessage("آی دی سفر خالی می باشد");

        RuleFor(_ => _.TravelerId).NotEmpty().WithMessage("آی دی مسافر خالی می باشد");

        RuleFor(_ => _.Start)
            .MaximumLength(50).WithName("مبدا").WithMessage(ValidationMessage.MaximumLength)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty);

        RuleFor(_ => _.Destination)
            .MaximumLength(50).WithName("مقصد").WithMessage(ValidationMessage.MaximumLength)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty);
    }
}
