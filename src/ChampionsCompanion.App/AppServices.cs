using ChampionsCompanion.Core.Data;
using ChampionsCompanion.Core.Data.InMemory;

namespace ChampionsCompanion.App;

/// <summary>
/// The one place where the app decides where its data comes from.
/// Pages use these properties and never create a DAO themselves.
/// </summary>
/// <remarks>
/// Phase 1: in-memory DAOs. Phase 2 adds a method that creates the Entity Framework DAOs;
/// nothing else in the app changes.
/// </remarks>
public static class AppServices
{
    public static ICardDao Cards { get; private set; } = null!;
    public static IDeckDao Decks { get; private set; } = null!;
    public static ILookupDao Lookups { get; private set; } = null!;

    public static void UseInMemoryData()
    {
        var store = InMemoryDataStore.Instance;
        Cards = new InMemoryCardDao(store);
        Decks = new InMemoryDeckDao(store);
        Lookups = new InMemoryLookupDao(store);
    }
}
