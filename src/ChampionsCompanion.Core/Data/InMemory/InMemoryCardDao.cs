using ChampionsCompanion.Core.Model;

namespace ChampionsCompanion.Core.Data.InMemory;

/// <summary>Phase 1 implementation of <see cref="ICardDao"/>, over <see cref="InMemoryDataStore"/>.</summary>
public class InMemoryCardDao : ICardDao
{
    private static readonly Func<Card, bool> IsPlayerCard = CardQueries.IsPlayerCard.Compile();

    private readonly InMemoryDataStore _store;

    public InMemoryCardDao() : this(InMemoryDataStore.Instance) { }

    public InMemoryCardDao(InMemoryDataStore store) => _store = store;

    public IReadOnlyList<Card> GetAll() =>
        _store.Cards.Where(IsPlayerCard).OrderBy(c => c.Code).ToList();

    // TODO: implement the other methods of ICardDao. After a change that adds or modifies
    // a card, call _store.Link() so its Aspect, Type, Pack and Hero references are set.
}
