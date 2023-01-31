using FluentValidation;
using SH.InfrastructureEfCore.Consts;
using Traveler.Domain.Repositories;

namespace Traveler.Application.Travelers.Commands.CreateTraveler;

public class CreateTravelerCommandValidator : AbstractValidator<CreateTravelerCommand>
{
    public CreateTravelerCommandValidator(ITravelerRepository travelerRepository)
    {
        RuleFor(_ => _.FirstName)
            .MaximumLength(50).WithName("نام").WithMessage(ValidationMessage.MaximumLength)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty);

        RuleFor(_ => _.LastName)
            .MaximumLength(50).WithName("نام خانوادگی").WithMessage(ValidationMessage.MaximumLength)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty);

        RuleFor(_ => _.NationalCode)
            .MaximumLength(50).WithName("کد ملی").WithMessage(ValidationMessage.MaximumLength)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .MustAsync(async (nationalCode, cancellationToken) => !await travelerRepository.NationalCodeExists(0, nationalCode, false, cancellationToken)).WithMessage(ValidationMessage.BeUnique);

        RuleFor(_ => _.PhoneNumber)
            .MaximumLength(50).WithName("شماره تماس").WithMessage(ValidationMessage.MaximumLength)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .MustAsync(async (phoneNumber, cancellationToken) => !await travelerRepository.PhoneNumberExists(0, phoneNumber, false, cancellationToken)).WithMessage(ValidationMessage.BeUnique);
    }
}
