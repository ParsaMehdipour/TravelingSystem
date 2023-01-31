using FluentValidation;

namespace Driver.Application.Drivers.Commands.AddDriverPoints;

public class AddDriverPointsCommandValidator : AbstractValidator<AddDriverPointsCommand>
{
    public AddDriverPointsCommandValidator()
    {
        RuleFor(_ => _.Id).NotEmpty().WithMessage("آی دی خالی می باشد");

        RuleFor(_ => _.Point).NotEmpty().WithMessage("امتیاز دی خالی می باشد");
    }
}
