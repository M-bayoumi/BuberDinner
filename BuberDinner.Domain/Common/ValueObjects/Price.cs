using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects;

public class Price : ValueObject
{
    public int Amount { get; set; }
    public string Currency { get; set; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;

    }
}
