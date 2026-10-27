using ChampionsCompanion.Core.Model;

namespace ChampionsCompanion.Core.Data;

/// <summary>
/// Data access object (DAO) for cards. The pages only know this interface: Phase 1 uses
/// <c>InMemoryCardDao</c>, Phase 2 an Entity Framework implementation, and nothing else in the app changes.
/// </summary>
/// <remarks>
/// TODO: add the methods your pages need (find one card, add, update, delete...).
/// Write each one here first, then implement it in <c>InMemoryCardDao</c>.
/// </remarks>
public interface ICardDao
{
    /// <summary>
    /// Every player card (requirements C.0), with <see cref="Card.Type"/>, <see cref="Card.Aspect"/>,
    /// <see cref="Card.Pack"/> and <see cref="Card.Hero"/> loaded, ordered by code.
    /// </summary>
    IReadOnlyList<Card> GetAll();
}
