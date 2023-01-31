using FluentValidation;

namespace Journey.Application.journeys.Commands.ChangeJourneyStatus;

public class ChangeJourneyStatusCommandValidator : AbstractValidator<ChangeJourneyStatusCommand>
{
    public ChangeJourneyStatusCommandValidator()
    {
        RuleFor(_ => _.Id).NotEmpty().WithMessage("آی دی خالی می باشد");
    }
}
