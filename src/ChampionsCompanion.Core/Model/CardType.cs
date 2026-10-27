namespace ChampionsCompanion.Core.Model;

/// <summary>
/// The type of a card: Ally, Event, Resource, Support, Upgrade...
/// In the database this is the <c>type</c> table.
/// </summary>
public class CardType
{
    public const string Ally = "ally";
    public const string Event = "event";
    public const string Resource = "resource";
    public const string Support = "support";
    public const string Upgrade = "upgrade";
    public const string PlayerSideScheme = "player_side_scheme";
    public const string Hero = "hero";
    public const string AlterEgo = "alter_ego";

    /// <summary>The types a player deck can contain.</summary>
    public static readonly string[] PlayerCodes = [Ally, Event, Resource, Support, Upgrade, PlayerSideScheme];

    public int Id { get; set; }
    public string Code { get; set; } = "";
    public string Name { get; set; } = "";

    public override string ToString() => Name;
}
