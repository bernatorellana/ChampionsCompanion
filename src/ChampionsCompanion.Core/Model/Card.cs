namespace ChampionsCompanion.Core.Model;

/// <summary>
/// A card. In the database this is the <c>card</c> table (it has many more columns,
/// most of them for encounter cards; the app only uses these).
/// </summary>
/// <remarks>
/// Every reference to another entity has two properties: the id (<see cref="AspectId"/>)
/// and the object (<see cref="Aspect"/>). In Phase 1 the seed data fills both;
/// in Phase 2 Entity Framework fills them from the database.
/// </remarks>
public class Card
{
    /// <summary>Value of <see cref="Cost"/> for a cost of X.</summary>
    public const int CostX = -1;

    public int Id { get; set; }

    /// <summary>Unique code: pack number (2 digits) + position (3 digits) + optional side letter. Example: "01058".</summary>
    public string Code { get; set; } = "";

    /// <summary>The card's title (DB column <c>name</c>).</summary>
    public string Title { get; set; } = "";

    /// <summary>Second line of the title, for example "Matt Murdock" (DB column <c>subname</c>).</summary>
    public string? Subtitle { get; set; }

    public int TypeId { get; set; }
    public CardType Type { get; set; } = null!;

    /// <summary>DB column <c>faction_id</c>.</summary>
    public int AspectId { get; set; }
    public Aspect Aspect { get; set; } = null!;

    /// <summary>Only for hero cards and identities (DB column <c>set_id</c>).</summary>
    public int? HeroId { get; set; }
    public Hero? Hero { get; set; }

    public int PackId { get; set; }
    public Pack Pack { get; set; } = null!;

    /// <summary>Position inside the pack (the last three digits of the code).</summary>
    public int Position { get; set; }

    /// <summary>0–9, <see cref="CostX"/> for X, or null for cards without cost (resources).</summary>
    public int? Cost { get; set; }

    public int? ResourceEnergy { get; set; }
    public int? ResourcePhysical { get; set; }
    public int? ResourceMental { get; set; }
    public int? ResourceWild { get; set; }

    /// <summary>Allies only.</summary>
    public int? Attack { get; set; }
    /// <summary>Allies only: consequential damage after attacking.</summary>
    public int? AttackCost { get; set; }
    /// <summary>Allies only.</summary>
    public int? Thwart { get; set; }
    /// <summary>Allies only: consequential damage after thwarting.</summary>
    public int? ThwartCost { get; set; }
    /// <summary>Allies and identities.</summary>
    public int? Health { get; set; }

    /// <summary>Traits, each one ending with a period: "Avenger. Gamma."</summary>
    public string? Traits { get; set; }

    /// <summary>Rules text. It contains &lt;b&gt;, &lt;i&gt; and icon tokens such as [energy] or [[TRAIT]].</summary>
    public string? Text { get; set; }

    public string? Flavor { get; set; }

    public bool IsUnique { get; set; }

    /// <summary>Maximum copies per deck (rule S5). Nullable because the original data has gaps.</summary>
    public int? DeckLimit { get; set; }

    /// <summary>Copies in the product. For hero cards it is the HeroSetQuantity of rule S3.</summary>
    public int Quantity { get; set; } = 1;

    /// <summary>True for the back face of double-sided cards.</summary>
    public bool IsHidden { get; set; }

    /// <summary>Set when this card is a reprint of an earlier card.</summary>
    public int? DuplicateOfId { get; set; }

    /// <summary>True for cards created in the app. Only those can be deleted (C.4).</summary>
    public bool IsUserCreated { get; set; }

    /// <summary>Relative path ("Images/Cards/01058.png") or absolute URL of the card image (DB column <c>image_url</c>).</summary>
    public string? ImagePath { get; set; }

    public DateTime DateCreation { get; set; }
    public DateTime DateUpdate { get; set; }

    // ---- Calculated properties (not stored) ----

    /// <summary>True when the aspect is Hero.</summary>
    public bool IsHeroCard => Aspect?.Code == Model.Aspect.Hero;

    /// <summary>True for the hero cards that rule S3 puts in a deck (not the identity, not a back face, not a reprint).</summary>
    public bool IsHeroDeckCard =>
        IsHeroCard && !IsHidden && DuplicateOfId == null &&
        Type?.Code is not (CardType.Hero or CardType.AlterEgo);

    /// <summary>Deck limit with a safety net for missing data: 1 if unique, 3 otherwise.</summary>
    public int EffectiveDeckLimit => DeckLimit ?? (IsUnique ? 1 : 3);

    /// <summary>"3", "X" or "—".</summary>
    public string CostText => Cost switch
    {
        null => "—",
        CostX => "X",
        _ => Cost.Value.ToString()
    };

    public override string ToString() => string.IsNullOrEmpty(Subtitle) ? Title : $"{Title} ({Subtitle})";
}
