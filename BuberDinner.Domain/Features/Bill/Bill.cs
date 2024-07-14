using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Features.Bill.ValueObjects;
using BuberDinner.Domain.Features.Dinner.ValueObjects;
using BuberDinner.Domain.Features.Guest.ValueObjects;
using BuberDinner.Domain.Features.Host.ValueObjects;

namespace BuberDinner.Domain.Features.Bill;

public sealed class Bill : AggregateRoot<BillID>
{
    public DinnerID DinnerID { get; private set; }
    public GuestID GuestID { get; private set; }
    public HostID HostID { get; private set; }
    public Price Price { get; private set; }

    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; private set; }

    public Bill(
        BillID billID,
        DinnerID dinnerID,
        GuestID guestID,
        HostID hostID,
        Price price,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(billID)
    {
        DinnerID = dinnerID;
        GuestID = guestID;
        HostID = hostID;
        Price = price;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Bill Create(DinnerID dinnerID, GuestID guestID, HostID hostID, Price price)
    {
        return new Bill(BillID.CreateUnique(), dinnerID, guestID, hostID, price, DateTime.UtcNow, DateTime.UtcNow);
    }

    public void UpdateDinnerID(DinnerID dinnerID)
    {
        DinnerID = dinnerID;
        UpdatedDateTime = DateTime.UtcNow;
    }

    public void UpdateGuestID(GuestID guestID)
    {
        GuestID = guestID;
        UpdatedDateTime = DateTime.UtcNow;
    }

    public void UpdateHostID(HostID hostID)
    {
        HostID = hostID;
        UpdatedDateTime = DateTime.UtcNow;
    }

    public void UpdatePrice(Price price)
    {
        Price = price;
        UpdatedDateTime = DateTime.UtcNow;
    }
}
