namespace ChampionsCompanion.Core.Model;

/// <summary>
/// A hero, for example Spider-Man. The database has no hero table: a hero is a
/// <c>cardset</c> whose type is "hero". Its cards are the cards of that set.
/// </summary>
public class Hero
{
    public int Id { get; set; }
    public string Code { get; set; } = "";
    public string Name { get; set; } = "";

    /// <summary>Every card of the hero's set: the identity (hero and alter-ego sides) and the hero cards.</summary>
    public ICollection<Card> Cards { get; set; } = new List<Card>();

    /// <summary>The hero side of the identity card (lowest code if the set has more than one).</summary>
    public Card? IdentityCard => Cards
        .Where(c => c.Type?.Code == CardType.Hero)
        .OrderBy(c => c.Code)
        .FirstOrDefault();

    /// <summary>The name on the alter-ego side, for example "Peter Parker".</summary>
    public string AlterEgoName => Cards
        .Where(c => c.Type?.Code == CardType.AlterEgo)
        .OrderBy(c => c.Code)
        .Select(c => c.Title)
        .FirstOrDefault() ?? "";

    /// <summary>The cards that rule S3 puts in every deck of this hero.</summary>
    public IEnumerable<Card> DeckCards => Cards.Where(c => c.IsHeroDeckCard).OrderBy(c => c.Code);

    /// <summary>Total copies that rule S3 adds (usually 15). Never hard-code it.</summary>
    public int DeckCardCount => DeckCards.Sum(c => c.Quantity);

    public override string ToString() =>
        string.IsNullOrEmpty(AlterEgoName) ? Name : $"{Name} ({AlterEgoName})";
}
