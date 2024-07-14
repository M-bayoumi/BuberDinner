using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Features.Host.ValueObjects;

public sealed class HostID : ValueObject
{
    public Guid Value { get; }

    private HostID(Guid value)
    {
        Value = value;
    }
    public static HostID CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
