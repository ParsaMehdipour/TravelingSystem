using Factor.Domain.Models;
using Factor.Domain.Repositories;
using FluentResults;
using MediatR;

namespace Factor.Application.Factors.Commands.CreateFactor;

public class CreateFactorCommandHandler : IRequestHandler<CreateFactorCommand, Result<CreateFactorDto>>
{
    protected FactorFactory _factorFactory { get; }
    protected IFactorRepository _factorRepository { get; }

    public CreateFactorCommandHandler(FactorFactory factorFactory, IFactorRepository factorRepository)
    {
        _factorFactory = factorFactory;
        _factorRepository = factorRepository;
    }

    public async Task<Result<CreateFactorDto>> Handle(CreateFactorCommand request, CancellationToken cancellationToken)
    {
        Random randomEngine = new Random();

        var price = randomEngine.Next(10000, 80000);
        var distance = randomEngine.Next(6, 15);

        int markdown = price * (request.DiscountRate / 100);
        int finalPrice = price - markdown;

        Domain.Models.Factor factor = _factorFactory.Create(Guid.NewGuid().ToString(), price, request.DiscountRate,
            finalPrice, request.TravelerId, request.DriverId, request.JourneyId);

        await _factorRepository.AddAsync(factor, cancellationToken);
        await _factorRepository.SaveAsync(cancellationToken);

        CreateFactorDto result = new(factor.Id, distance);

        return Result.Ok(result);

    }
}
