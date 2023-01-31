using Journey.Domain.Enums;

namespace Journey.Domain.Models;

public class JourneyFactory
{
    public Journey Create(string date, string start, string destination, string code, string discountCode, JourneyStatus status, long travelerId, long driverId)
    {
        if (string.IsNullOrWhiteSpace(date))
            throw new ArgumentNullException(date, nameof(date));

        if (string.IsNullOrWhiteSpace(start))
            throw new ArgumentNullException(start, nameof(start));

        if (string.IsNullOrWhiteSpace(destination))
            throw new ArgumentNullException(destination, nameof(destination));

        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentNullException(code, nameof(code));

        if (travelerId == 0)
            throw new ArgumentOutOfRangeException(travelerId.ToString());

        if (driverId == 0)
            throw new ArgumentOutOfRangeException(travelerId.ToString());

        //if (factorId == 0)
        //    throw new ArgumentOutOfRangeException(factorId.ToString());

        Journey journey = new(date, start, destination, code, discountCode, status, travelerId, driverId);

        return journey;
    }
}
