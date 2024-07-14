using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Features.Menu.ValueObjects;

public sealed class MenuID : ValueObject
{
    public Guid Value { get; }

    private MenuID(Guid value)
    {
        Value = value;
    }
    public static MenuID CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
