using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Features.Dinner.ValueObjects;

public sealed class DinnerID : ValueObject
{
    public Guid Value { get; }

    private DinnerID(Guid value)
    {
        Value = value;
    }
    public static DinnerID CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
