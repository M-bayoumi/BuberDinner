using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Features.Bill.ValueObjects;

public sealed class BillID : ValueObject
{
    public Guid Value { get; }

    private BillID(Guid value)
    {
        Value = value;
    }
    public static BillID CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
