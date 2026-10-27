using ChampionsCompanion.Core.Model;

namespace ChampionsCompanion.Core.Data.InMemory;

/// <summary>
/// The "database" of Phase 1: plain lists in memory, filled by <see cref="SeedData"/>.
/// There is a single instance (<see cref="Instance"/>) shared by the in-memory DAOs.
/// Everything is lost when the app closes; that is expected in Phase 1.
/// </summary>
public class InMemoryDataStore
{
    private static InMemoryDataStore? _instance;

    /// <summary>The shared store, created from <see cref="SeedData"/> the first time it is used.</summary>
    public static InMemoryDataStore Instance => _instance ??= SeedData.CreateStore();

    public List<Aspect> Aspects { get; } = new();
    public List<CardType> CardTypes { get; } = new();
    public List<Pack> Packs { get; } = new();
    public List<Hero> Heroes { get; } = new();
    public List<Card> Cards { get; } = new();
    public List<Deck> Decks { get; } = new();

    public int NextCardId() => Cards.Count == 0 ? 1 : Cards.Max(c => c.Id) + 1;
    public int NextDeckId() => Decks.Count == 0 ? 1 : Decks.Max(d => d.Id) + 1;
    public int NextDeckSlotId() =>
        Decks.SelectMany(d => d.Slots).Select(s => s.Id).DefaultIfEmpty(0).Max() + 1;

    /// <summary>
    /// Makes the object references match the ids, the way a database join would:
    /// <c>card.Aspect</c> from <c>card.AspectId</c>, <c>hero.Cards</c> from the cards' <c>HeroId</c>, and so on.
    /// Call it after every change.
    /// </summary>
    public void Link()
    {
        foreach (var card in Cards)
        {
            card.Type = CardTypes.First(t => t.Id == card.TypeId);
            card.Aspect = Aspects.First(a => a.Id == card.AspectId);
            card.Pack = Packs.First(p => p.Id == card.PackId);
            card.Hero = card.HeroId == null ? null : Heroes.First(h => h.Id == card.HeroId);
        }

        foreach (var hero in Heroes)
        {
            hero.Cards = Cards.Where(c => c.HeroId == hero.Id).ToList();
        }

        foreach (var deck in Decks)
        {
            deck.Hero = Heroes.First(h => h.Id == deck.HeroId);
            deck.Aspect = deck.AspectId == null ? null : Aspects.First(a => a.Id == deck.AspectId);
            foreach (var slot in deck.Slots)
            {
                slot.DeckId = deck.Id;
                slot.Deck = deck;
                slot.Card = Cards.First(c => c.Id == slot.CardId);
            }
        }
    }
}
