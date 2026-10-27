namespace ChampionsCompanion.Core.Model;

/// <summary>A product (Core Set, a hero pack...). In the database this is the <c>pack</c> table.</summary>
public class Pack
{
    public int Id { get; set; }
    public string Code { get; set; } = "";
    public string Name { get; set; } = "";

    /// <summary>Release order. It is the first two digits of the codes of the pack's cards (Core Set = 1 → "01001").</summary>
    public int Position { get; set; }

    public override string ToString() => Name;
}
