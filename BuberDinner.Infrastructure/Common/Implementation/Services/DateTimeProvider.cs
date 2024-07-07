using BuberDinner.Application.Common.Interfaces.Services;

namespace BuberDinner.Infrastructure.Common.Implementation.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
