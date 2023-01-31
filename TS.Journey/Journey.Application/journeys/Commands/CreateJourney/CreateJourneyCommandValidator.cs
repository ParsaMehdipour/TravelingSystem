using FluentValidation;
using SH.InfrastructureEfCore.Consts;

namespace Journey.Application.journeys.Commands.CreateJourney;

public class CreateJourneyCommandValidator : AbstractValidator<CreateJourneyCommand>
{
    public CreateJourneyCommandValidator()
    {
        RuleFor(_ => _.Date)
            .MaximumLength(50).WithName("تاریخ سفر").WithMessage(ValidationMessage.MaximumLength)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty);

        RuleFor(_ => _.Start)
            .MaximumLength(50).WithName("مبدا").WithMessage(ValidationMessage.MaximumLength)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty);

        RuleFor(_ => _.Destination)
            .MaximumLength(50).WithName("مقصد").WithMessage(ValidationMessage.MaximumLength)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty);

        RuleFor(_ => _.DriverId)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty).WithName("آیدی راننده");

        RuleFor(_ => _.TravelerId)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty).WithName("آیدی مسافر");

    }
}
