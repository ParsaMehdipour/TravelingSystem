using SH.Domain;
using SH.Domain.Interfaces;

namespace Factor.Domain.Models;

public class Factor : AuditableEntity, IAggregateRoot
{
    public string TravelCode { get; private set; }
    public int Price { get; private set; }
    public int DiscountRate { get; private set; }
    public int FinalPrice { get; private set; }

    #region Relational Ids

    public long TravelerId { get; private set; }
    public long DriverId { get; private set; }
    public long JourneyId { get; private set; }

    #endregion

    public Factor()
    {
    }

    public Factor(string travelCode, int price, int discountRate, int finalPrice, long travelerId, long driverId, long journeyId)
    {
        SetTravelCode(travelCode);
        SetPrice(price);
        SetDiscountRate(discountRate);
        SetFinalPrice(finalPrice);
        SetTravelerId(travelerId);
        SetDriverId(driverId);
        SetJourneyId(journeyId);

        CreatedDate = DateTime.Now;
    }

    public void SetTravelCode(string travelCode)
    {
        if (TravelCode == travelCode)
            return;

        TravelCode = travelCode;
    }

    public void SetPrice(int price)
    {
        if (Price == price)
            return;

        Price = price;
    }

    public void SetDiscountRate(int discountRate)
    {
        if (DiscountRate == discountRate)
            return;

        DiscountRate = discountRate;
    }

    public void SetFinalPrice(int finalPrice)
    {
        if (FinalPrice == finalPrice)
            return;

        FinalPrice = finalPrice;
    }

    public void SetTravelerId(long travelerId)
    {
        if (TravelerId == travelerId)
            return;

        TravelerId = travelerId;
    }

    public void SetDriverId(long driverId)
    {
        if (DriverId == driverId)
            return;

        DriverId = driverId;
    }

    public void SetJourneyId(long journeyId)
    {
        if (JourneyId == journeyId)
            return;

        JourneyId = journeyId;
    }
}
