using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Features.Menu.ValueObjects;

namespace BuberDinner.Domain.Features.Menu.Entities;

public sealed class MenuSection : Entity<MenuSectionID>
{
    private readonly List<MenuItem> _items = new();

    public string Name { get; }
    public string Description { get; }
    public IReadOnlyList<MenuItem> Items => _items.ToList();

    public MenuSection(MenuSectionID id, string name, string description) : base(id)
    {
        Name = name;
        Description = description;
    }
    public static MenuSection Create(
        string name,
        string description)
    {
        return new MenuSection(
            MenuSectionID.CreateUnique(),
            name,
            description);
    }
}
