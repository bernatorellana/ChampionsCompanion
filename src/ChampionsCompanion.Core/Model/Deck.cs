namespace ChampionsCompanion.Core.Model;

/// <summary>A player deck. In the database this is the <c>deck</c> table.</summary>
public class Deck
{
    public const int MinCards = 40;
    public const int MaxCards = 50;

    public int Id { get; set; }
    public string Name { get; set; } = "";

    public int HeroId { get; set; }
    public Hero Hero { get; set; } = null!;

    /// <summary>Null while the user hasn't chosen one (the deck is then incomplete).</summary>
    public int? AspectId { get; set; }
    public Aspect? Aspect { get; set; }

    /// <summary>Relative path of the deck image, or null to show the hero's card.</summary>
    public string? ImagePath { get; set; }

    public DateTime DateCreation { get; set; }
    public DateTime DateUpdate { get; set; }

    public ICollection<DeckSlot> Slots { get; set; } = new List<DeckSlot>();

    /// <summary>Total number of cards, hero cards included (rule S2).</summary>
    public int CardCount => Slots.Sum(s => s.Quantity);
}
