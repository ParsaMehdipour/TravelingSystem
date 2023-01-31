using FluentValidation;
using SH.InfrastructureEfCore.Consts;
using Traveler.Domain.Repositories;

namespace Traveler.Application.Travelers.Commands.EditTraveler;

public class EditTravelerCommandValidator : AbstractValidator<EditTravelerCommand>
{
    public EditTravelerCommandValidator(ITravelerRepository travelerRepository)
    {
        RuleFor(_ => _.Id).NotEmpty().WithMessage(ValidationMessage.NotEmpty).WithName("شناسه");

        RuleFor(_ => _.FirstName).NotEmpty().WithMessage(ValidationMessage.NotEmpty).WithName("نام")
            .MaximumLength(50).WithName("نام").WithMessage(ValidationMessage.MaximumLength)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty);

        RuleFor(_ => _.LastName).NotEmpty().WithMessage(ValidationMessage.NotEmpty).WithName("نام خانوادگی")
            .MaximumLength(50).WithName("نام خانوادگی").WithMessage(ValidationMessage.MaximumLength)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty);

        RuleFor(_ => _.NationalCode).NotEmpty().WithMessage(ValidationMessage.NotEmpty).WithName("کد ملی")
            .MaximumLength(50).WithName("کد ملی").WithMessage(ValidationMessage.MaximumLength)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .MustAsync(async (command, nationalCode, cancellationToken) => !await travelerRepository.NationalCodeExists(command.Id, command.NationalCode, true, cancellationToken)).WithMessage(ValidationMessage.NotExists).WithName("کد ملی");

        RuleFor(_ => _.PhoneNumber).NotEmpty().WithMessage(ValidationMessage.NotEmpty).WithName("شماره تماس")
            .MaximumLength(50).WithName("شماره تماس").WithMessage(ValidationMessage.MaximumLength)
            .NotEmpty().WithMessage(ValidationMessage.NotEmpty)
            .MustAsync(async (command, phoneNumber, cancellationToken) => !await travelerRepository.PhoneNumberExists(command.Id, command.PhoneNumber, true, cancellationToken)).WithMessage(ValidationMessage.NotExists).WithName("شماره تماس");
    }
}
