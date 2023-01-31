using FluentValidation;

namespace Traveler.Application.Travelers.Commands.DeleteTraveler;

public class DeleteTravelerCommandValidator : AbstractValidator<DeleteTravelerCommand>
{
    public DeleteTravelerCommandValidator()
    {
        RuleFor(_ => _.Id).NotEmpty().WithMessage("آی دی خالی می باشد");
    }
}
