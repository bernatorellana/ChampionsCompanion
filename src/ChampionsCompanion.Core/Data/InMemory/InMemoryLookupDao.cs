using ChampionsCompanion.Core.Model;

namespace ChampionsCompanion.Core.Data.InMemory;

/// <summary>Phase 1 implementation of <see cref="ILookupDao"/>, over <see cref="InMemoryDataStore"/>.</summary>
public class InMemoryLookupDao : ILookupDao
{
    private readonly InMemoryDataStore _store;

    public InMemoryLookupDao() : this(InMemoryDataStore.Instance) { }

    public InMemoryLookupDao(InMemoryDataStore store) => _store = store;

    // TODO: implement the methods of ILookupDao over _store.Aspects, _store.CardTypes,
    // _store.Packs and _store.Heroes.
}
