using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Features.MenuReview.ValueObjects;

public sealed class MenuReviewID : ValueObject
{
    public Guid Value { get; }

    private MenuReviewID(Guid value)
    {
        Value = value;
    }
    public static MenuReviewID CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
