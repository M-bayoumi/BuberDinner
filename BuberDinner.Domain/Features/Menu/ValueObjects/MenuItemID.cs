using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Features.Menu.ValueObjects;

public sealed class MenuItemID : ValueObject
{
    public Guid Value { get; }

    private MenuItemID(Guid value)
    {
        Value = value;
    }
    public static MenuItemID CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
