using Journey.Domain.Enums;
using SH.Domain;
using SH.Domain.Interfaces;

namespace Journey.Domain.Models;

public class Journey : AuditableEntity, IAggregateRoot
{
    public string Date { get; private set; }
    public string Start { get; private set; }
    public string Destination { get; private set; }
    public int Distance { get; private set; }
    public string Code { get; private set; }
    public string DiscountCode { get; private set; }
    public JourneyStatus Status { get; private set; }

    #region Relational Ids

    public long FactorId { get; private set; }
    public long TravelerId { get; private set; }
    public long DriverId { get; private set; }


    #endregion

    public Journey()
    {

    }

    public Journey(string date, string start, string destination, string code, string discountCode, JourneyStatus status, long travelerId, long driverId)
    {
        SetDate(date);
        SetStart(start);
        SetDestination(destination);
        SetCode(code);
        SetDiscountCode(discountCode);
        SetStatus(status);
        SetTravelerId(travelerId);
        SetDriverId(driverId);

        CreatedDate = DateTime.Now;
    }

    public void SetDate(string date)
    {
        if (Date == date)
            return;

        Date = date;
    }

    public void SetStart(string start)
    {
        if (Start == start)
            return;

        Start = start;
    }

    public void SetDestination(string destination)
    {
        if (Destination == destination)
            return;

        Destination = destination;
    }

    public void SetDistance(int distance)
    {
        if (Distance == distance)
            return;

        Distance = distance;
    }

    public void SetCode(string code)
    {
        if (Code == code)
            return;

        Code = code;
    }

    public void SetDiscountCode(string discountCode)
    {
        if (DiscountCode == discountCode)
            return;

        DiscountCode = discountCode;
    }

    public void SetStatus(JourneyStatus status)
    {
        if (Status == status)
            return;

        Status = status;
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

    public void SetFactorId(long factorId)
    {
        if (FactorId == factorId)
            return;

        FactorId = factorId;
    }
}
