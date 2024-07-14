using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Features.Menu.ValueObjects;

namespace BuberDinner.Domain.Features.Menu.Entities;

public sealed class MenuItem : Entity<MenuItemID>
{
    public string Name { get; }
    public string Description { get; }
    private MenuItem(MenuItemID menuItemID, string name, string description) : base(menuItemID)
    {
        Name = name;
        Description = description;
    }
    public static MenuItem Create(
        string name,
        string description)
    {
        return new(
            MenuItemID.CreateUnique(),
            name,
            description);
    }

}
