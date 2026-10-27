namespace ChampionsCompanion.Core.Model;

/// <summary>One card of a deck and how many copies. In the database this is the <c>deckslot</c> table.</summary>
public class DeckSlot
{
    public int Id { get; set; }

    public int DeckId { get; set; }
    public Deck? Deck { get; set; }

    public int CardId { get; set; }
    public Card Card { get; set; } = null!;

    public int Quantity { get; set; }
}
