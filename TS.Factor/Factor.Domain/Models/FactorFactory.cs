namespace Factor.Domain.Models;

public class FactorFactory
{
    public Factor Create(string travelCode, int price, int discountRate, int finalPrice, long travelerId, long driverId, long journeyId)
    {
        if (string.IsNullOrWhiteSpace(travelCode))
            throw new ArgumentNullException(travelCode, nameof(travelCode));

        if (price == 0)
            throw new ArgumentOutOfRangeException(nameof(price));

        if (finalPrice == 0)
            throw new ArgumentOutOfRangeException(nameof(finalPrice));

        if (travelerId == 0)
            throw new ArgumentOutOfRangeException(nameof(travelerId));

        if (driverId == 0)
            throw new ArgumentOutOfRangeException(nameof(driverId));

        if (journeyId == 0)
            throw new ArgumentOutOfRangeException(nameof(journeyId));

        Factor factor = new(travelCode, price, discountRate, finalPrice, travelerId, driverId, journeyId);

        return factor;
    }
}
