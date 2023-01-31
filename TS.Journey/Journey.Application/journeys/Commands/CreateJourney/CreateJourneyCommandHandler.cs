using FluentResults;
using Journey.Application.Models;
using Journey.Domain.Models;
using Journey.Domain.Repositories;
using MediatR;
using SH.InfrastructureEfCore.Services;

namespace Journey.Application.journeys.Commands.CreateJourney;

public class CreateJourneyCommandHandler : IRequestHandler<CreateJourneyCommand, Result<long>>
{
    protected IJourneyRepository _journeyRepository { get; }
    protected JourneyFactory _journeyFactory { get; }
    protected HttpClientService _httpClientService { get; }

    public CreateJourneyCommandHandler(IJourneyRepository journeyRepository, JourneyFactory journeyFactory, HttpClientService httpClientService)
    {
        _journeyRepository = journeyRepository;
        _journeyFactory = journeyFactory;
        _httpClientService = httpClientService;
    }

    public async Task<Result<long>> Handle(CreateJourneyCommand request, CancellationToken cancellationToken)
    {
        Domain.Models.Journey journey = _journeyFactory.Create(request.Date, request.Start, request.Destination,
            Guid.NewGuid().ToString(), request.DiscountCode, request.Status, request.TravelerId, request.DriverId);

        await _journeyRepository.AddAsync(journey, cancellationToken);
        await _journeyRepository.SaveAsync(cancellationToken);

        //Request to create factor
        _httpClientService.SetBaseAddress("https://localhost:7267/");

        CreateFactorRequestDto requestPost = new(journey.Id, request.TravelerId, request.DriverId, request.Start, request.Destination);

        var createFactorResponse = await _httpClientService.Post<CreateFactorRequestDto, CreateFactorResponseDto>(requestPost, "api/Factors/Create/", cancellationToken);

        journey.SetFactorId(createFactorResponse.FactorId);
        journey.SetDistance(createFactorResponse.Distance);

        await _journeyRepository.SaveAsync(cancellationToken);

        return Result.Ok(journey.Id);
    }
}
