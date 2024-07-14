using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Features.Dinner.ValueObjects;
using BuberDinner.Domain.Features.Host.ValueObjects;
using BuberDinner.Domain.Features.Menu.Entities;
using BuberDinner.Domain.Features.Menu.ValueObjects;
using BuberDinner.Domain.Features.MenuReview.ValueObjects;

namespace BuberDinner.Domain.Features.Menu;

public sealed class Menu : AggregateRoot<MenuID>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; private set; }

    public AverageRating AverageRating { get; private set; }
    public HostID HostID { get; private set; }

    private readonly List<MenuSection> _sections = new();
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

    private readonly List<DinnerID> _dinnerIDs = new();
    public IReadOnlyList<DinnerID> DinnerIDs => _dinnerIDs.AsReadOnly();

    private readonly List<MenuReviewID> _menuReviewIDs = new();
    public IReadOnlyList<MenuReviewID> MenuReviewIDs => _menuReviewIDs.AsReadOnly();

    public Menu(
        MenuID menuID,
        string name,
        string description,
        DateTime createdDateTime,
        DateTime updatedDateTime,
        AverageRating averageRating,
        HostID hostID
    ) : base(menuID)
    {
        Name = name;
        Description = description;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
        AverageRating = averageRating;
        HostID = hostID;
    }

    public static Menu Create(string name, string description, HostID hostID)
    {
        return new(MenuID.CreateUnique(), name, description, DateTime.UtcNow, DateTime.UtcNow, AverageRating.Create(), hostID);
    }

    public void UpdateName(string name)
    {
        Name = name;
        UpdatedDateTime = DateTime.UtcNow;
    }

    public void UpdateDescription(string description)
    {
        Description = description;
        UpdatedDateTime = DateTime.UtcNow;
    }

    public void UpdateHostID(HostID hostID)
    {
        HostID = hostID;
        UpdatedDateTime = DateTime.UtcNow;
    }

    public void AddSection(MenuSection section)
    {
        _sections.Add(section);
        UpdatedDateTime = DateTime.UtcNow;
    }

    public void RemoveSection(MenuSection section)
    {
        _sections.Remove(section);
        UpdatedDateTime = DateTime.UtcNow;
    }

    public void UpdateSection(MenuSection oldSection, MenuSection newSection)
    {
        int index = _sections.IndexOf(oldSection);
        if (index != -1)
        {
            _sections[index] = newSection;
            UpdatedDateTime = DateTime.UtcNow;
        }
    }

    public void AddDinnerID(DinnerID dinnerID)
    {
        if (!_dinnerIDs.Contains(dinnerID))
        {
            _dinnerIDs.Add(dinnerID);
            UpdatedDateTime = DateTime.UtcNow;
        }
    }

    public void RemoveDinnerID(DinnerID dinnerID)
    {
        if (_dinnerIDs.Remove(dinnerID))
        {
            UpdatedDateTime = DateTime.UtcNow;
        }
    }

    public void AddMenuReviewID(MenuReviewID menuReviewID)
    {
        if (!_menuReviewIDs.Contains(menuReviewID))
        {
            _menuReviewIDs.Add(menuReviewID);
            UpdatedDateTime = DateTime.UtcNow;
        }
    }

    public void RemoveMenuReviewID(MenuReviewID menuReviewID)
    {
        if (_menuReviewIDs.Remove(menuReviewID))
        {
            UpdatedDateTime = DateTime.UtcNow;
        }
    }
}
