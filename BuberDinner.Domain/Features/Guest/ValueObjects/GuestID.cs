using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Features.Guest.ValueObjects;

public sealed class GuestID : ValueObject
{
    public Guid Value { get; }

    private GuestID(Guid value)
    {
        Value = value;
    }
    public static GuestID CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
