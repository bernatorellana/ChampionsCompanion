using ChampionsCompanion.Core.Model;

namespace ChampionsCompanion.Core.Data.InMemory;

/// <summary>
/// Data to play with in Phase 1: a real subset of the card database (Core Set).
/// <list type="bullet">
/// <item>2 heroes, Spider-Man and Captain Marvel, with their identity cards and their 8 hero cards each (15 copies).</item>
/// <item>40 Basic and aspect cards.</item>
/// <item>1 sample deck, "Spidey Justice" (Spider-Man, Justice, 45 cards).</item>
/// </list>
/// Generated from marvelcdb.com. The images are in <c>Images/Cards</c>, one file per card code.
/// </summary>
public static class SeedData
{
    public static InMemoryDataStore CreateStore()
    {
        var store = new InMemoryDataStore();

        // ---- Aspects (DB table: faction) ----
        var hero = new Aspect { Id = 1, Code = Aspect.Hero, Name = "Hero" };
        var basic = new Aspect { Id = 2, Code = Aspect.Basic, Name = "Basic" };
        var justice = new Aspect { Id = 3, Code = Aspect.Justice, Name = "Justice" };
        var aggression = new Aspect { Id = 4, Code = Aspect.Aggression, Name = "Aggression" };
        var protection = new Aspect { Id = 5, Code = Aspect.Protection, Name = "Protection" };
        var leadership = new Aspect { Id = 6, Code = Aspect.Leadership, Name = "Leadership" };
        store.Aspects.AddRange([hero, basic, justice, aggression, protection, leadership]);

        // ---- Card types (DB table: type) ----
        var ally = new CardType { Id = 1, Code = CardType.Ally, Name = "Ally" };
        var evt = new CardType { Id = 2, Code = CardType.Event, Name = "Event" };
        var resource = new CardType { Id = 3, Code = CardType.Resource, Name = "Resource" };
        var support = new CardType { Id = 4, Code = CardType.Support, Name = "Support" };
        var upgrade = new CardType { Id = 5, Code = CardType.Upgrade, Name = "Upgrade" };
        var playerSideScheme = new CardType { Id = 6, Code = CardType.PlayerSideScheme, Name = "Player Side Scheme" };
        var heroType = new CardType { Id = 7, Code = CardType.Hero, Name = "Hero" };
        var alterEgo = new CardType { Id = 8, Code = CardType.AlterEgo, Name = "Alter-Ego" };
        store.CardTypes.AddRange([ally, evt, resource, support, upgrade, playerSideScheme, heroType, alterEgo]);

        // ---- Packs ----
        var core = new Pack { Id = 1, Code = "core", Name = "Core Set", Position = 1 };
        store.Packs.Add(core);

        // ---- Heroes (DB table: cardset, type hero) ----
        var spiderMan = new Hero { Id = 1, Code = "spider_man", Name = "Spider-Man" };
        var captainMarvel = new Hero { Id = 2, Code = "captain_marvel", Name = "Captain Marvel" };
        store.Heroes.AddRange([spiderMan, captainMarvel]);

        // ---- Cards ----
        store.Cards.AddRange(
        [
            new Card
            {
                Id = 1, Code = "01001a", Title = "Spider-Man",
                TypeId = heroType.Id, AspectId = hero.Id, HeroId = spiderMan.Id, PackId = core.Id, Position = 1,
                Health = 10,
                Traits = "Avenger.",
                Text = "Spider-Sense — <b>Interrupt</b>: When the villain initiates an attack against you, draw 1 card.",
                Flavor = "\"Just your friendly neighborhood Spider-Man!\"",
                IsUnique = true, DeckLimit = 1, Quantity = 1, ImagePath = "Images/Cards/01001a.png",
            },
            new Card
            {
                Id = 2, Code = "01001b", Title = "Peter Parker",
                TypeId = alterEgo.Id, AspectId = hero.Id, HeroId = spiderMan.Id, PackId = core.Id, Position = 1,
                Health = 10,
                Traits = "Genius.",
                Text = "Scientist — <b>Resource</b>: Generate a [mental] resource. (Limit once per round.)",
                Flavor = "\"Right now, I'd trade the whole Spider-Man bit for a rocking chair and a good book.\"",
                IsUnique = true, DeckLimit = 1, Quantity = 1, IsHidden = true, ImagePath = "Images/Cards/01001b.png",
            },
            new Card
            {
                Id = 3, Code = "01002", Title = "Black Cat", Subtitle = "Felicia Hardy",
                TypeId = ally.Id, AspectId = hero.Id, HeroId = spiderMan.Id, PackId = core.Id, Position = 2,
                Cost = 2, ResourceEnergy = 1,
                Attack = 1, Thwart = 1, ThwartCost = 1, Health = 2,
                Traits = "Hero for Hire.",
                Text = "<b>Forced Response</b>: After you play Black Cat, discard the top 2 cards of your deck. Add each card with a printed [mental] resource discarded this way to your hand.",
                Flavor = "\"I'm not a hero, I'm a thief.\"",
                IsUnique = true, DeckLimit = 1, Quantity = 1, ImagePath = "Images/Cards/01002.png",
            },
            new Card
            {
                Id = 4, Code = "01003", Title = "Backflip",
                TypeId = evt.Id, AspectId = hero.Id, HeroId = spiderMan.Id, PackId = core.Id, Position = 3,
                Cost = 0, ResourcePhysical = 1,
                Traits = "Defense. Skill.",
                Text = "<b>Interrupt</b> <i>(defense)</i>: When you would take any amount of damage from an attack, prevent all of that damage.",
                Flavor = "\"Have you been training? 'Cause that almost hit me.\" —Spider-Man",
                DeckLimit = 2, Quantity = 2, ImagePath = "Images/Cards/01003.png",
            },
            new Card
            {
                Id = 5, Code = "01004", Title = "Enhanced Spider-Sense",
                TypeId = evt.Id, AspectId = hero.Id, HeroId = spiderMan.Id, PackId = core.Id, Position = 4,
                Cost = 1, ResourceMental = 1,
                Traits = "Superpower.",
                Text = "<b>Hero Interrupt</b>: When a treachery card is revealed from the encounter deck, cancel its \"<b>When Revealed</b>\" effects.",
                Flavor = "\"My spider-sense is tingling!\" —Spider-Man",
                DeckLimit = 2, Quantity = 2, ImagePath = "Images/Cards/01004.png",
            },
            new Card
            {
                Id = 6, Code = "01005", Title = "Swinging Web Kick",
                TypeId = evt.Id, AspectId = hero.Id, HeroId = spiderMan.Id, PackId = core.Id, Position = 5,
                Cost = 3, ResourceMental = 1,
                Traits = "Aerial. Attack. Superpower.",
                Text = "<b>Hero Action</b> <i>(attack)</i>: Deal 8 damage to an enemy.",
                Flavor = "\"Tally-ho!\" —Spider-Man",
                DeckLimit = 3, Quantity = 3, ImagePath = "Images/Cards/01005.png",
            },
            new Card
            {
                Id = 7, Code = "01006", Title = "Aunt May",
                TypeId = support.Id, AspectId = hero.Id, HeroId = spiderMan.Id, PackId = core.Id, Position = 6,
                Cost = 1, ResourceEnergy = 1,
                Traits = "Persona.",
                Text = "<b>Alter-Ego Action</b>: Exhaust Aunt May → heal 4 damage from Peter Parker.",
                Flavor = "\"Goodness, Peter! You've been so clumsy lately.\"",
                IsUnique = true, DeckLimit = 1, Quantity = 1, ImagePath = "Images/Cards/01006.png",
            },
            new Card
            {
                Id = 8, Code = "01007", Title = "Spider-Tracer",
                TypeId = upgrade.Id, AspectId = hero.Id, HeroId = spiderMan.Id, PackId = core.Id, Position = 7,
                Cost = 1, ResourceEnergy = 1,
                Traits = "Item. Tech.",
                Text = "Attach to a minion.\n<b>Forced Interrupt</b>: When attached minion is defeated, remove 3 threat from a scheme.",
                DeckLimit = 2, Quantity = 2, ImagePath = "Images/Cards/01007.png",
            },
            new Card
            {
                Id = 9, Code = "01008", Title = "Web-Shooter",
                TypeId = upgrade.Id, AspectId = hero.Id, HeroId = spiderMan.Id, PackId = core.Id, Position = 8,
                Cost = 1, ResourcePhysical = 1,
                Traits = "Item. Tech.",
                Text = "Uses (3 web counters). <i>(Enters play with 3 counters. When those are gone, discard this card)</i>\n<b>Hero Resource</b>: Exhaust Web-Shooter and remove 1 web counter from it → generate a [wild] resource.",
                DeckLimit = 2, Quantity = 2, ImagePath = "Images/Cards/01008.png",
            },
            new Card
            {
                Id = 10, Code = "01009", Title = "Webbed Up",
                TypeId = upgrade.Id, AspectId = hero.Id, HeroId = spiderMan.Id, PackId = core.Id, Position = 9,
                Cost = 4, ResourcePhysical = 1,
                Traits = "Condition.",
                Text = "Hero form only. Attach to an enemy. Max 1 per enemy.\n<b>Forced Interrupt</b>: When attached enemy would attack, discard Webbed Up instead. Then, stun that enemy.",
                DeckLimit = 2, Quantity = 2, ImagePath = "Images/Cards/01009.png",
            },
            new Card
            {
                Id = 11, Code = "01010a", Title = "Captain Marvel",
                TypeId = heroType.Id, AspectId = hero.Id, HeroId = captainMarvel.Id, PackId = core.Id, Position = 10,
                Health = 12,
                Traits = "Avenger. Soldier.",
                Text = "Rechannel — <b>Action</b>: Spend a [energy] resource and heal 1 damage from Captain Marvel → draw 1 card. (Limit once per round.)",
                Flavor = "\"I never quit.\"",
                IsUnique = true, DeckLimit = 1, Quantity = 1, ImagePath = "Images/Cards/01010a.png",
            },
            new Card
            {
                Id = 12, Code = "01010b", Title = "Carol Danvers",
                TypeId = alterEgo.Id, AspectId = hero.Id, HeroId = captainMarvel.Id, PackId = core.Id, Position = 10,
                Health = 12,
                Traits = "S.H.I.E.L.D. Soldier.",
                Text = "Commander — <b>Action</b>: Choose a player to draw 1 card. (Limit once per round.)",
                Flavor = "\"It's my job to protect the Earth and everyone on it.\"",
                IsUnique = true, DeckLimit = 1, Quantity = 1, IsHidden = true, ImagePath = "Images/Cards/01010b.png",
            },
            new Card
            {
                Id = 13, Code = "01011", Title = "Spider-Woman", Subtitle = "Jessica Drew",
                TypeId = ally.Id, AspectId = hero.Id, HeroId = captainMarvel.Id, PackId = core.Id, Position = 11,
                Cost = 3, ResourceWild = 1,
                Attack = 2, AttackCost = 1, Thwart = 2, ThwartCost = 1, Health = 2,
                Traits = "Avenger. Spy.",
                Text = "<b>Response</b>: After Spider-Woman enters play, confuse the villain.",
                Flavor = "\"This is what I wanted: helping the innocents by hospitalizing the guilty.\"",
                IsUnique = true, DeckLimit = 1, Quantity = 1, ImagePath = "Images/Cards/01011.png",
            },
            new Card
            {
                Id = 14, Code = "01012", Title = "Crisis Interdiction",
                TypeId = evt.Id, AspectId = hero.Id, HeroId = captainMarvel.Id, PackId = core.Id, Position = 12,
                Cost = 2, ResourceEnergy = 1,
                Traits = "Thwart.",
                Text = "<b>Hero Action</b> <i>(thwart)</i>: Remove 2 threat from a scheme. Then, if you have the [[Aerial]] trait, remove 2 threat from a different scheme.",
                Flavor = "\"This is one of the more impressive messes I've ever seen.\" —Carol Danvers",
                DeckLimit = 3, Quantity = 3, ImagePath = "Images/Cards/01012.png",
            },
            new Card
            {
                Id = 15, Code = "01013", Title = "Photonic Blast",
                TypeId = evt.Id, AspectId = hero.Id, HeroId = captainMarvel.Id, PackId = core.Id, Position = 13,
                Cost = 3, ResourcePhysical = 1,
                Traits = "Attack. Superpower.",
                Text = "<b>Hero Action</b> <i>(attack)</i>: Deal 5 damage to an enemy. If you paid for this card using a [energy] resource, draw 1 card.",
                DeckLimit = 3, Quantity = 3, ImagePath = "Images/Cards/01013.png",
            },
            new Card
            {
                Id = 16, Code = "01014", Title = "Energy Absorption",
                TypeId = resource.Id, AspectId = hero.Id, HeroId = captainMarvel.Id, PackId = core.Id, Position = 14,
                ResourceEnergy = 3,
                Flavor = "\"That's enough!\" —Carol Danvers",
                DeckLimit = 2, Quantity = 2, ImagePath = "Images/Cards/01014.png",
            },
            new Card
            {
                Id = 17, Code = "01015", Title = "Alpha Flight Station",
                TypeId = support.Id, AspectId = hero.Id, HeroId = captainMarvel.Id, PackId = core.Id, Position = 15,
                Cost = 1, ResourceMental = 1,
                Traits = "Location. S.H.I.E.L.D.",
                Text = "<b>Action</b>: Exhaust Alpha Flight Station, choose and discard 1 card from your hand → draw 1 card (draw 2 cards instead if you are Carol Danvers).",
                Flavor = "This low-orbit space station can beam cargo and crew to and from the Triskelion",
                IsUnique = true, DeckLimit = 1, Quantity = 1, ImagePath = "Images/Cards/01015.png",
            },
            new Card
            {
                Id = 18, Code = "01016", Title = "Captain Marvel's Helmet",
                TypeId = upgrade.Id, AspectId = hero.Id, HeroId = captainMarvel.Id, PackId = core.Id, Position = 16,
                Cost = 2, ResourcePhysical = 1,
                Traits = "Armor. Tech.",
                Text = "Captain Marvel gets +1 DEF (+2 DEF instead if you have the [[Aerial]] trait).",
                Flavor = "\"This is so cool!\" —Jessica Drew",
                IsUnique = true, DeckLimit = 1, Quantity = 1, ImagePath = "Images/Cards/01016.png",
            },
            new Card
            {
                Id = 19, Code = "01017", Title = "Cosmic Flight",
                TypeId = upgrade.Id, AspectId = hero.Id, HeroId = captainMarvel.Id, PackId = core.Id, Position = 17,
                Cost = 2, ResourceEnergy = 1,
                Traits = "Superpower.",
                Text = "Captain Marvel gains the [[Aerial]] trait.\n<b>Hero Interrupt</b> (<i>defense</i>): When Captain Marvel would take damage, discard Cosmic Flight → prevent 3 of that damage.",
                DeckLimit = 2, Quantity = 2, ImagePath = "Images/Cards/01017.png",
            },
            new Card
            {
                Id = 20, Code = "01018", Title = "Energy Channel",
                TypeId = upgrade.Id, AspectId = hero.Id, HeroId = captainMarvel.Id, PackId = core.Id, Position = 18,
                Cost = 0, ResourceMental = 1,
                Traits = "Superpower.",
                Text = "Max 1 per player.\n<b>Action</b>: Spend X [energy] resources → put X energy counters here.\n<b>Hero Action</b> <i>(attack)</i>: Discard Energy Channel → deal 2 damage to an enemy (to a maximum of 10) for each energy counter here.",
                DeckLimit = 2, Quantity = 2, ImagePath = "Images/Cards/01018.png",
            },
            new Card
            {
                Id = 21, Code = "01050", Title = "Hulk", Subtitle = "Bruce Banner",
                TypeId = ally.Id, AspectId = aggression.Id, PackId = core.Id, Position = 50,
                Cost = 2, ResourceEnergy = 1,
                Attack = 3, AttackCost = 1, Health = 5,
                Traits = "Avenger. Gamma.",
                Text = "<b>Forced Response</b>: After Hulk attacks, discard the top card of your deck. If that card's printed resource has:\n[physical] - Deal 2 damage to an enemy.\n[energy] - Deal 1 damage to each character.\n[mental] - Discard Hulk.\n[wild] - All of the above.",
                IsUnique = true, DeckLimit = 1, Quantity = 1, ImagePath = "Images/Cards/01050.png",
            },
            new Card
            {
                Id = 22, Code = "01051", Title = "Tigra", Subtitle = "Greer Grant Nelson",
                TypeId = ally.Id, AspectId = aggression.Id, PackId = core.Id, Position = 51,
                Cost = 3, ResourceMental = 1,
                Attack = 2, AttackCost = 1, Thwart = 1, ThwartCost = 1, Health = 3,
                Traits = "Avenger.",
                Text = "<b>Response</b>: After Tigra attacks and defeats a minion, heal 1 damage from her.",
                Flavor = "\"Sorry —no autographs.\"",
                IsUnique = true, DeckLimit = 1, Quantity = 1, ImagePath = "Images/Cards/01051.png",
            },
            new Card
            {
                Id = 23, Code = "01052", Title = "Chase Them Down",
                TypeId = evt.Id, AspectId = aggression.Id, PackId = core.Id, Position = 52,
                Cost = 0, ResourceMental = 1,
                Traits = "Thwart.",
                Text = "<b>Response</b> <i>(thwart)</i>: After your hero attacks and defeats an enemy, remove 2 threat from a scheme.",
                Flavor = "\"Kamala, we don't have a theme song. Please stop humming one...\" —Captain Marvel",
                DeckLimit = 3, Quantity = 3, ImagePath = "Images/Cards/01052.png",
            },
            new Card
            {
                Id = 24, Code = "01053", Title = "Relentless Assault",
                TypeId = evt.Id, AspectId = aggression.Id, PackId = core.Id, Position = 53,
                Cost = 2, ResourceEnergy = 1,
                Traits = "Attack.",
                Text = "<b>Hero Action</b> <i>(attack)</i>: Deal 5 damage to a minion. If you paid for this card using a [physical] resource, this attack gains overkill. <i>(Excess damage from this attack is dealt to the villain.)</i>",
                DeckLimit = 3, Quantity = 3, ImagePath = "Images/Cards/01053.png",
            },
            new Card
            {
                Id = 25, Code = "01054", Title = "Uppercut",
                TypeId = evt.Id, AspectId = aggression.Id, PackId = core.Id, Position = 54,
                Cost = 3, ResourcePhysical = 1,
                Traits = "Attack.",
                Text = "<b>Hero Action</b> <i>(attack)</i>: Deal 5 damage to an enemy.",
                Flavor = "SMACK!",
                DeckLimit = 3, Quantity = 3, ImagePath = "Images/Cards/01054.png",
            },
            new Card
            {
                Id = 26, Code = "01055", Title = "The Power of Aggression",
                TypeId = resource.Id, AspectId = aggression.Id, PackId = core.Id, Position = 55,
                ResourceWild = 1,
                Text = "Max 2 per deck.\nDouble the number of resources this card generates while paying for a Aggression <i>(red)</i> card.",
                DeckLimit = 2, Quantity = 2, ImagePath = "Images/Cards/01055.png",
            },
            new Card
            {
                Id = 27, Code = "01057", Title = "Combat Training",
                TypeId = upgrade.Id, AspectId = aggression.Id, PackId = core.Id, Position = 57,
                Cost = 2, ResourcePhysical = 1,
                Traits = "Skill.",
                Text = "Play under any player's control. Max 1 per player.\nYour hero gets +1 ATK.",
                Flavor = "\"Tony! She did it again!\" —Janet Van Dyne",
                DeckLimit = 3, Quantity = 3, ImagePath = "Images/Cards/01057.png",
            },
            new Card
            {
                Id = 28, Code = "01058", Title = "Daredevil", Subtitle = "Matt Murdock",
                TypeId = ally.Id, AspectId = justice.Id, PackId = core.Id, Position = 58,
                Cost = 4, ResourcePhysical = 1,
                Attack = 2, AttackCost = 1, Thwart = 2, ThwartCost = 1, Health = 3,
                Traits = "Defender.",
                Text = "<b>Response</b>: After Daredevil thwarts, deal 1 damage to an enemy.",
                Flavor = "\"Sometimes, I think I accomplish more with my fists than with my law firm.\"",
                IsUnique = true, DeckLimit = 1, Quantity = 1, ImagePath = "Images/Cards/01058.png",
            },
            new Card
            {
                Id = 29, Code = "01059", Title = "Jessica Jones",
                TypeId = ally.Id, AspectId = justice.Id, PackId = core.Id, Position = 59,
                Cost = 3, ResourceEnergy = 1,
                Attack = 2, AttackCost = 1, Thwart = 1, ThwartCost = 1, Health = 3,
                Traits = "Defender.",
                Text = "Jessica Jones gets +1 THW for each side scheme in play.",
                Flavor = "\"I am very good at finding people.\"",
                IsUnique = true, DeckLimit = 1, Quantity = 1, ImagePath = "Images/Cards/01059.png",
            },
            new Card
            {
                Id = 30, Code = "01060", Title = "For Justice!",
                TypeId = evt.Id, AspectId = justice.Id, PackId = core.Id, Position = 60,
                Cost = 2, ResourceEnergy = 1,
                Traits = "Thwart.",
                Text = "<b>Hero Action</b> <i>(thwart)</i>: Remove 3 threat from a scheme (4 threat instead if you paid for this card using a [mental] resource).",
                Flavor = "\"You lose. And you're going to answer for what you've done.\" —Captain America",
                DeckLimit = 3, Quantity = 3, ImagePath = "Images/Cards/01060.png",
            },
            new Card
            {
                Id = 31, Code = "01061", Title = "Great Responsibility",
                TypeId = evt.Id, AspectId = justice.Id, PackId = core.Id, Position = 61,
                Cost = 0, ResourceMental = 1,
                Text = "<b>Hero Interrupt</b>: When any amount of threat would be placed on a scheme, you take it as damage instead.",
                DeckLimit = 3, Quantity = 3, ImagePath = "Images/Cards/01061.png",
            },
            new Card
            {
                Id = 32, Code = "01062", Title = "The Power of Justice",
                TypeId = resource.Id, AspectId = justice.Id, PackId = core.Id, Position = 62,
                ResourceWild = 1,
                Text = "Max 2 per deck.\nDouble the number of resources this card generates while paying for a Justice <i>(yellow)</i> card.",
                DeckLimit = 2, Quantity = 2, ImagePath = "Images/Cards/01062.png",
            },
            new Card
            {
                Id = 33, Code = "01063", Title = "Interrogation Room",
                TypeId = support.Id, AspectId = justice.Id, PackId = core.Id, Position = 63,
                Cost = 1, ResourceEnergy = 1,
                Traits = "Location.",
                Text = "Max 1 per player.\n<b>Response</b>: After you defeat a minion, exhaust Interrogation Room → remove 1 threat from a scheme.",
                Flavor = "\"Oh, she's sorry! Let me get the keys and call you a car service!\" —Misty Knight",
                DeckLimit = 3, Quantity = 3, ImagePath = "Images/Cards/01063.png",
            },
            new Card
            {
                Id = 34, Code = "01065", Title = "Heroic Intuition",
                TypeId = upgrade.Id, AspectId = justice.Id, PackId = core.Id, Position = 65,
                Cost = 2, ResourceEnergy = 1,
                Traits = "Skill.",
                Text = "Play under any player's control. Max 1 per player.\nYour hero gets +1 THW.",
                DeckLimit = 3, Quantity = 3, ImagePath = "Images/Cards/01065.png",
            },
            new Card
            {
                Id = 35, Code = "01066", Title = "Hawkeye", Subtitle = "Clint Barton",
                TypeId = ally.Id, AspectId = leadership.Id, PackId = core.Id, Position = 66,
                Cost = 3, ResourceEnergy = 1,
                Attack = 1, AttackCost = 1, Thwart = 1, ThwartCost = 1, Health = 3,
                Traits = "Avenger.",
                Text = "Hawkeye enters play with 4 arrow counters on him.\n<b>Response</b>: After a minion enters play, remove 1 arrow counter from Hawkeye → deal 2 damage to that minion.",
                IsUnique = true, DeckLimit = 1, Quantity = 1, ImagePath = "Images/Cards/01066.png",
            },
            new Card
            {
                Id = 36, Code = "01067", Title = "Maria Hill",
                TypeId = ally.Id, AspectId = leadership.Id, PackId = core.Id, Position = 67,
                Cost = 2, ResourceMental = 1,
                Attack = 1, AttackCost = 1, Thwart = 2, ThwartCost = 1, Health = 2,
                Traits = "S.H.I.E.L.D.",
                Text = "<b>Response</b>: After Maria Hill enters play, each player draws 1 card.",
                Flavor = "\"Believe it or not, we all want the same thing.\"",
                IsUnique = true, DeckLimit = 1, Quantity = 1, ImagePath = "Images/Cards/01067.png",
            },
            new Card
            {
                Id = 37, Code = "01068", Title = "Vision",
                TypeId = ally.Id, AspectId = leadership.Id, PackId = core.Id, Position = 68,
                Cost = 4, ResourcePhysical = 1,
                Attack = 2, AttackCost = 1, Thwart = 1, ThwartCost = 1, Health = 3,
                Traits = "Android. Avenger.",
                Text = "<b>Action</b>: Spend a [energy] resource → choose THW or ATK. Until the end of the phase, Vision gets +2 to the chosen power. (Limit once per round.)",
                Flavor = "\"I will handle this\"",
                IsUnique = true, DeckLimit = 1, Quantity = 1, ImagePath = "Images/Cards/01068.png",
            },
            new Card
            {
                Id = 38, Code = "01069", Title = "Get Ready",
                TypeId = evt.Id, AspectId = leadership.Id, PackId = core.Id, Position = 69,
                Cost = 0, ResourcePhysical = 1,
                Text = "<b>Action</b>: Ready an ally.",
                Flavor = "\"We train hard every day so that when the time comes, we'll be ready.\" —Steve Rogers",
                DeckLimit = 3, Quantity = 3, ImagePath = "Images/Cards/01069.png",
            },
            new Card
            {
                Id = 39, Code = "01070", Title = "Lead from the Front",
                TypeId = evt.Id, AspectId = leadership.Id, PackId = core.Id, Position = 70,
                Cost = 2, ResourceEnergy = 1,
                Traits = "Tactic.",
                Text = "<b>Hero Action</b>: Choose a player. Each character that player controls gets +1 THW and +1 ATK until the end of the phase.",
                Flavor = "\"Let's go everyone!\" —Carol Danvers",
                DeckLimit = 3, Quantity = 3, ImagePath = "Images/Cards/01070.png",
            },
            new Card
            {
                Id = 40, Code = "01071", Title = "Make the Call",
                TypeId = evt.Id, AspectId = leadership.Id, PackId = core.Id, Position = 71,
                Cost = 0, ResourceMental = 1,
                Text = "<b>Action</b>: Pay the printed cost of an ally in any player's discard pile → put that ally into play under your control.",
                Flavor = "\"This is a code red! All hands on deck!\" —Maria Hill",
                DeckLimit = 3, Quantity = 3, ImagePath = "Images/Cards/01071.png",
            },
            new Card
            {
                Id = 41, Code = "01072", Title = "The Power of Leadership",
                TypeId = resource.Id, AspectId = leadership.Id, PackId = core.Id, Position = 72,
                ResourceWild = 1,
                Text = "Max 2 per deck.\nDouble the number of resources this card generates while paying for a Leadership <i>(blue)</i> card.",
                DeckLimit = 2, Quantity = 2, ImagePath = "Images/Cards/01072.png",
            },
            new Card
            {
                Id = 42, Code = "01074", Title = "Inspired",
                TypeId = upgrade.Id, AspectId = leadership.Id, PackId = core.Id, Position = 74,
                Cost = 1, ResourcePhysical = 1,
                Traits = "Condition.",
                Text = "Attach to an ally. Max 1 per ally.\nAttached ally gets +1 THW and +1 ATK.",
                Flavor = "\"I'm glad she's on our side.\" —Star-Lord",
                DeckLimit = 3, Quantity = 3, ImagePath = "Images/Cards/01074.png",
            },
            new Card
            {
                Id = 43, Code = "01075", Title = "Black Widow", Subtitle = "Natasha Romanoff",
                TypeId = ally.Id, AspectId = protection.Id, PackId = core.Id, Position = 75,
                Cost = 3, ResourcePhysical = 1,
                Attack = 1, AttackCost = 1, Thwart = 2, ThwartCost = 1, Health = 2,
                Traits = "S.H.I.E.L.D. Spy.",
                Text = "<b>Interrupt</b>: When a card is revealed from the encounter deck, exhaust Black Widow and spend a [mental] resource → cancel the effects of that card and discard it. Then, reveal another card from the encounter deck.",
                IsUnique = true, DeckLimit = 1, Quantity = 1, ImagePath = "Images/Cards/01075.png",
            },
            new Card
            {
                Id = 44, Code = "01076", Title = "Luke Cage",
                TypeId = ally.Id, AspectId = protection.Id, PackId = core.Id, Position = 76,
                Cost = 4, ResourceEnergy = 1,
                Attack = 2, AttackCost = 1, Thwart = 1, ThwartCost = 1, Health = 5,
                Traits = "Defender.",
                Text = "Toughness. <i>(This character enters play with a tough status card.)</i>",
                Flavor = "\"Power Man for hire—Cage speakin'.\"",
                IsUnique = true, DeckLimit = 1, Quantity = 1, ImagePath = "Images/Cards/01076.png",
            },
            new Card
            {
                Id = 45, Code = "01077", Title = "Counter-Punch",
                TypeId = evt.Id, AspectId = protection.Id, PackId = core.Id, Position = 77,
                Cost = 0, ResourcePhysical = 1,
                Traits = "Attack.",
                Text = "<b>Response</b> <i>(attack)</i>: After your hero defends against an enemy attack, deal damage to that enemy equal to your hero's ATK.",
                Flavor = "\"That's what you get!\" —Iron Fist",
                DeckLimit = 3, Quantity = 3, ImagePath = "Images/Cards/01077.png",
            },
            new Card
            {
                Id = 46, Code = "01078", Title = "Get Behind Me!",
                TypeId = evt.Id, AspectId = protection.Id, PackId = core.Id, Position = 78,
                Cost = 1, ResourceMental = 1,
                Text = "<b>Hero Interrupt</b>: When a treachery card is revealed from the encounter deck, cancel its \"<b>When Revealed</b>\" effects. The villain attacks you instead.",
                Flavor = "\"Ahem! Stand aside, citizens!\" —Ms. Marvel",
                DeckLimit = 3, Quantity = 3, ImagePath = "Images/Cards/01078.png",
            },
            new Card
            {
                Id = 47, Code = "01079", Title = "The Power of Protection",
                TypeId = resource.Id, AspectId = protection.Id, PackId = core.Id, Position = 79,
                ResourceWild = 1,
                Text = "Max 2 per deck.\nDouble the number of resources this card generates while paying for a Protection <i>(green)</i> card.",
                DeckLimit = 2, Quantity = 2, ImagePath = "Images/Cards/01079.png",
            },
            new Card
            {
                Id = 48, Code = "01081", Title = "Armored Vest",
                TypeId = upgrade.Id, AspectId = protection.Id, PackId = core.Id, Position = 81,
                Cost = 1, ResourceMental = 1,
                Traits = "Armor.",
                Text = "Play under any player's control. Max 1 per player.\nYour hero gets +1 DEF.",
                Flavor = "Life-saving and stylish.",
                DeckLimit = 3, Quantity = 3, ImagePath = "Images/Cards/01081.png",
            },
            new Card
            {
                Id = 49, Code = "01082", Title = "Indomitable",
                TypeId = upgrade.Id, AspectId = protection.Id, PackId = core.Id, Position = 82,
                Cost = 1, ResourceEnergy = 1,
                Traits = "Condition.",
                Text = "<b>Response</b>: After your hero defends, discard indomitable → ready your hero.",
                Flavor = "\"We have no choice. So we fight — and we win. There are no other options.\" —Captain America",
                DeckLimit = 3, Quantity = 3, ImagePath = "Images/Cards/01082.png",
            },
            new Card
            {
                Id = 50, Code = "01083", Title = "Mockingbird", Subtitle = "Bobbi Morse",
                TypeId = ally.Id, AspectId = basic.Id, PackId = core.Id, Position = 83,
                Cost = 3, ResourcePhysical = 1,
                Attack = 1, AttackCost = 1, Thwart = 1, ThwartCost = 1, Health = 3,
                Traits = "S.H.I.E.L.D. Spy.",
                Text = "<b>Response</b>: After Mockingbird enters play, stun an enemy.",
                IsUnique = true, DeckLimit = 1, Quantity = 1, ImagePath = "Images/Cards/01083.png",
            },
            new Card
            {
                Id = 51, Code = "01084", Title = "Nick Fury",
                TypeId = ally.Id, AspectId = basic.Id, PackId = core.Id, Position = 84,
                Cost = 4, ResourceMental = 1,
                Attack = 2, AttackCost = 1, Thwart = 2, ThwartCost = 1, Health = 3,
                Traits = "S.H.I.E.L.D. Spy.",
                Text = "<b>Forced Response</b>: After Nick Fury enters play, choose one: remove 2 threat from a scheme, draw 3 cards, or deal 4 damage to an enemy. At the end of the round, if Nick Fury is still in play, discard him.",
                IsUnique = true, DeckLimit = 1, Quantity = 1, ImagePath = "Images/Cards/01084.png",
            },
            new Card
            {
                Id = 52, Code = "01085", Title = "Emergency",
                TypeId = evt.Id, AspectId = basic.Id, PackId = core.Id, Position = 85,
                Cost = 0, ResourceEnergy = 1,
                Traits = "Thwart.",
                Text = "<b>Interrupt</b> <i>(thwart)</i>: When the villain schemes, reduce the amount of threat placed on the scheme by 1.",
                Flavor = "\"CALLING ALL UNITS! CALLING ALL UNITS!\"",
                DeckLimit = 3, Quantity = 3, ImagePath = "Images/Cards/01085.png",
            },
            new Card
            {
                Id = 53, Code = "01086", Title = "First Aid",
                TypeId = evt.Id, AspectId = basic.Id, PackId = core.Id, Position = 86,
                Cost = 1, ResourceMental = 1,
                Text = "<b>Action</b>: Heal 2 damage from any character.",
                Flavor = "\"Does it still qualify as first aid if it's your second day in the hospital?\" —Clint Barton",
                DeckLimit = 3, Quantity = 3, ImagePath = "Images/Cards/01086.png",
            },
            new Card
            {
                Id = 54, Code = "01087", Title = "Haymaker",
                TypeId = evt.Id, AspectId = basic.Id, PackId = core.Id, Position = 87,
                Cost = 2, ResourceEnergy = 1,
                Traits = "Attack.",
                Text = "<b>Hero Action</b> <i>(attack)</i>: Deal 3 damage to an enemy.",
                Flavor = "WHAM!",
                DeckLimit = 3, Quantity = 3, ImagePath = "Images/Cards/01087.png",
            },
            new Card
            {
                Id = 55, Code = "01088", Title = "Energy",
                TypeId = resource.Id, AspectId = basic.Id, PackId = core.Id, Position = 88,
                ResourceEnergy = 2,
                Text = "Max 1 per deck.",
                DeckLimit = 1, Quantity = 4, ImagePath = "Images/Cards/01088.png",
            },
            new Card
            {
                Id = 56, Code = "01089", Title = "Genius",
                TypeId = resource.Id, AspectId = basic.Id, PackId = core.Id, Position = 89,
                ResourceMental = 2,
                Text = "Max 1 per deck.",
                DeckLimit = 1, Quantity = 4, ImagePath = "Images/Cards/01089.png",
            },
            new Card
            {
                Id = 57, Code = "01090", Title = "Strength",
                TypeId = resource.Id, AspectId = basic.Id, PackId = core.Id, Position = 90,
                ResourcePhysical = 2,
                Text = "Max 1 per deck.",
                DeckLimit = 1, Quantity = 4, ImagePath = "Images/Cards/01090.png",
            },
            new Card
            {
                Id = 58, Code = "01091", Title = "Avengers Mansion",
                TypeId = support.Id, AspectId = basic.Id, PackId = core.Id, Position = 91,
                Cost = 4, ResourceMental = 1,
                Traits = "Avenger. Location.",
                Text = "Max 1 per player.\n<b>Action</b>: Exhaust Avengers Mansion → choose a player. That player draws 1 card.",
                Flavor = "\"Did you remember to turn off the stove?\" —Janet Van Dyne",
                DeckLimit = 3, Quantity = 4, ImagePath = "Images/Cards/01091.png",
            },
            new Card
            {
                Id = 59, Code = "01092", Title = "Helicarrier",
                TypeId = support.Id, AspectId = basic.Id, PackId = core.Id, Position = 92,
                Cost = 3, ResourcePhysical = 1,
                Traits = "Location. S.H.I.E.L.D.",
                Text = "Max 1 per player.\n<b>Action</b>: Exhaust Helicarrier → choose a player. Reduce the resource cost of the next card that player plays this phase by 1.",
                Flavor = "\"A flying aircraft carrier? You're kidding, right?\" —Jennifer Walters",
                DeckLimit = 3, Quantity = 4, ImagePath = "Images/Cards/01092.png",
            },
            new Card
            {
                Id = 60, Code = "01093", Title = "Tenacity",
                TypeId = upgrade.Id, AspectId = basic.Id, PackId = core.Id, Position = 93,
                Cost = 2, ResourceEnergy = 1,
                Traits = "Condition.",
                Text = "<b>Hero Action</b>: Spend a [physical] resource and discard this card → ready your hero.",
                DeckLimit = 3, Quantity = 3, ImagePath = "Images/Cards/01093.png",
            },
        ]);

        // ---- Sample deck ----
        store.Decks.Add(new Deck
        {
            Id = 1,
            Name = "Spidey Justice",
            HeroId = spiderMan.Id,
            AspectId = justice.Id,
            Slots = new List<DeckSlot>
            {
                new DeckSlot { Id = 1, CardId = 3, Quantity = 1 }, // Black Cat
                new DeckSlot { Id = 2, CardId = 4, Quantity = 2 }, // Backflip
                new DeckSlot { Id = 3, CardId = 5, Quantity = 2 }, // Enhanced Spider-Sense
                new DeckSlot { Id = 4, CardId = 6, Quantity = 3 }, // Swinging Web Kick
                new DeckSlot { Id = 5, CardId = 7, Quantity = 1 }, // Aunt May
                new DeckSlot { Id = 6, CardId = 8, Quantity = 2 }, // Spider-Tracer
                new DeckSlot { Id = 7, CardId = 9, Quantity = 2 }, // Web-Shooter
                new DeckSlot { Id = 8, CardId = 10, Quantity = 2 }, // Webbed Up
                new DeckSlot { Id = 9, CardId = 28, Quantity = 1 }, // Daredevil
                new DeckSlot { Id = 10, CardId = 29, Quantity = 1 }, // Jessica Jones
                new DeckSlot { Id = 11, CardId = 30, Quantity = 3 }, // For Justice!
                new DeckSlot { Id = 12, CardId = 31, Quantity = 3 }, // Great Responsibility
                new DeckSlot { Id = 13, CardId = 32, Quantity = 2 }, // The Power of Justice
                new DeckSlot { Id = 14, CardId = 33, Quantity = 3 }, // Interrogation Room
                new DeckSlot { Id = 15, CardId = 34, Quantity = 3 }, // Heroic Intuition
                new DeckSlot { Id = 16, CardId = 50, Quantity = 1 }, // Mockingbird
                new DeckSlot { Id = 17, CardId = 51, Quantity = 1 }, // Nick Fury
                new DeckSlot { Id = 18, CardId = 52, Quantity = 3 }, // Emergency
                new DeckSlot { Id = 19, CardId = 53, Quantity = 2 }, // First Aid
                new DeckSlot { Id = 20, CardId = 54, Quantity = 2 }, // Haymaker
                new DeckSlot { Id = 21, CardId = 55, Quantity = 1 }, // Energy
                new DeckSlot { Id = 22, CardId = 56, Quantity = 1 }, // Genius
                new DeckSlot { Id = 23, CardId = 57, Quantity = 1 }, // Strength
                new DeckSlot { Id = 24, CardId = 58, Quantity = 1 }, // Avengers Mansion
                new DeckSlot { Id = 25, CardId = 59, Quantity = 1 }, // Helicarrier
            },
        });

        var now = DateTime.Now;
        foreach (var card in store.Cards)
        {
            card.DateCreation = card.DateUpdate = now;
        }
        foreach (var deck in store.Decks)
        {
            deck.DateCreation = deck.DateUpdate = now;
        }

        // Fill the object references (card.Aspect, hero.Cards, slot.Card...) from the ids.
        store.Link();
        return store;
    }
}
