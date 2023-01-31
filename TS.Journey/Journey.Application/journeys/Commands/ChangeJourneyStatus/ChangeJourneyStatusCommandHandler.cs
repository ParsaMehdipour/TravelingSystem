using FluentResults;
using Journey.Application.Models;
using Journey.Domain.Enums;
using Journey.Domain.Repositories;
using MediatR;
using SH.InfrastructureEfCore.Services;

namespace Journey.Application.journeys.Commands.ChangeJourneyStatus;

public class ChangeJourneyStatusCommandHandler : IRequestHandler<ChangeJourneyStatusCommand, Result>
{
    protected IJourneyRepository _journeyRepository { get; }
    protected HttpClientService _httpClientService { get; }

    public ChangeJourneyStatusCommandHandler(IJourneyRepository journeyRepository, HttpClientService httpClientService)
    {
        _journeyRepository = journeyRepository;
        _httpClientService = httpClientService;
    }

    public async Task<Result> Handle(ChangeJourneyStatusCommand request, CancellationToken cancellationToken)
    {
        Domain.Models.Journey journey = await _journeyRepository.GetByIdAsync(cancellationToken, request.Id);

        ArgumentNullException.ThrowIfNull(journey, nameof(journey));

        journey.SetStatus(request.Status);

        if (request.Status == JourneyStatus.End)
        {
            //Request to add points to the driver
            _httpClientService.SetBaseAddress("https://localhost:7173/");

            AddPointsToDriverDto requestPost = new(journey.DriverId, 10);

            var Result = await _httpClientService.Post<AddPointsToDriverDto, Result>(requestPost, "api/Driver/AddDriverPoints/", cancellationToken);
        }

        _journeyRepository.Update(journey);
        await _journeyRepository.SaveAsync(cancellationToken);

        return Result.Ok();
    }
}
