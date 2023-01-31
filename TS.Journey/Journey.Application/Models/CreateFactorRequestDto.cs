namespace Journey.Application.Models;

public record CreateFactorRequestDto(long JourneyId, long TravelerId, long DriverId, string Start, string Destination);

