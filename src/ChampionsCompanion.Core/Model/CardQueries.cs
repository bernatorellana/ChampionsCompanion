using System.Linq.Expressions;

namespace ChampionsCompanion.Core.Model;

/// <summary>
/// Filters shared by every DAO. They are expressions (not methods) so that
/// Entity Framework can translate them to SQL in Phase 2, while the in-memory
/// DAO compiles and runs them in C#.
/// </summary>
public static class CardQueries
{
    /// <summary>
    /// Cards the app works with (requirements C.0): player aspects, no back faces,
    /// no reprints, no identity cards.
    /// </summary>
    public static readonly Expression<Func<Card, bool>> IsPlayerCard = c =>
        Aspect.PlayerCodes.Contains(c.Aspect.Code) &&
        !c.IsHidden &&
        c.DuplicateOfId == null &&
        c.Type.Code != CardType.Hero &&
        c.Type.Code != CardType.AlterEgo;
}
