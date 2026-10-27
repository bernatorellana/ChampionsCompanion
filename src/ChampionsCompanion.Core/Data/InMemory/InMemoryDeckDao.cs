using ChampionsCompanion.Core.Model;

namespace ChampionsCompanion.Core.Data.InMemory;

/// <summary>Phase 1 implementation of <see cref="IDeckDao"/>, over <see cref="InMemoryDataStore"/>.</summary>
public class InMemoryDeckDao : IDeckDao
{
    private readonly InMemoryDataStore _store;

    public InMemoryDeckDao() : this(InMemoryDataStore.Instance) { }

    public InMemoryDeckDao(InMemoryDataStore store) => _store = store;

    // TODO: implement the methods of IDeckDao over _store.Decks.
}
