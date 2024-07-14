using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Features.Menu.ValueObjects;
public sealed class MenuSectionID : ValueObject
{
    public Guid Value { get; }

    private MenuSectionID(Guid value)
    {
        Value = value;
    }
    public static MenuSectionID CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
