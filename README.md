# Champions Companion: Phase 1 starter

A WPF (.NET 10) companion app for *Marvel Champions: The Card Game*. This is the starting point for Phase 1: the model and the data to play with are done; the data access objects (DAOs) and the user interface are yours.

## Open and run

1. Open `src/ChampionsCompanion.sln` in Visual Studio 2022 (17.14 or later) or 2026, with the **.NET desktop development** workload and the .NET 10 SDK.
2. Set **ChampionsCompanion.App** as the startup project and run it (F5).

You'll see the main window with the **Cards** and **Decks** menu. The Cards page only prints what it read from `AppServices.Cards.GetAll()`, to show how to use a DAO.

## What's in the solution

| Project / folder | What it is | Do you change it? |
|---|---|---|
| `ChampionsCompanion.Core/Model` | The model classes: `Card`, `Aspect`, `CardType`, `Pack`, `Hero`, `Deck`, `DeckSlot`. Plain C# classes, in game terms. | Only to add calculated properties if you need them. |
| `ChampionsCompanion.Core/Data` | The DAO interfaces: `ICardDao`, `IDeckDao`, `ILookupDao`. The pages only talk to these. `ICardDao.GetAll()` is the example; the rest is empty. | **Yes: add the methods your pages need.** |
| `ChampionsCompanion.Core/Data/InMemory` | Phase 1 DAOs (`InMemoryCardDao`, `InMemoryDeckDao`, `InMemoryLookupDao`) over lists in memory (`InMemoryDataStore`, filled by `SeedData`). Only `InMemoryCardDao.GetAll()` is written. | **Yes: implement your DAO methods.** Don't change `InMemoryDataStore` or `SeedData`. |
| `ChampionsCompanion.Core/Rules/DeckRules.cs` | Deck-building rules S1–S5. **Empty: you implement it.** | Yes. |
| `ChampionsCompanion.App` | The WPF app (WPF-UI for the Fluent look and `NavigationView`). | Yes: everything. |
| `ChampionsCompanion.App/AppServices.cs` | The one place that decides where the data comes from. | No (Phase 2 changes it). |
| `ChampionsCompanion.App/Themes` | Colours and icon shapes from the UI design. | Add your own styles. |
| `ChampionsCompanion.App/Images/Cards` | One image per card, named by card code. | Add images for cards you create. |

## The data you get

`SeedData.cs` builds a real subset of the card database (the Core Set):

- **2 heroes**, Spider-Man and Captain Marvel, with their identity cards and 8 hero cards each (15 copies).
- **40 Basic and aspect cards** (Justice, Aggression, Protection, Leadership).
- **1 deck**, "Spidey Justice": Spider-Man, Justice, 45 cards, complete.

Everything is lost when you close the app. That's expected in Phase 1: **don't add file persistence**. Phase 2 replaces the in-memory data with a MariaDB database.

## Rules for working with the data

These rules are what make Phase 2 easy. Break them now and you'll rewrite your pages later.

1. **Pages never create a DAO.** Use `AppServices.Cards`, `AppServices.Decks` and `AppServices.Lookups`.
2. **Every data access goes through a DAO method.** A page never touches `InMemoryDataStore` or its lists. If a page needs something new (the decks that use a card, the next free position in a pack...), add a method to the DAO interface and implement it in the in-memory DAO. In Phase 2 you write a second implementation of the same interfaces that reads the database, and the pages don't change.
3. **Never edit a card or deck object directly from a form.** In Phase 1 the objects a DAO returns are the stored ones. Bind the form to your own copy of the values (an edit model) and call your DAO's add or update method on Save. Otherwise *Cancel* can't undo anything.
4. **Use ids to compare.** Two `Aspect` objects with the same `Id` are the same aspect, even if they are different instances (in Phase 2 they often will be).
5. **After adding or changing a card or deck in memory, call `InMemoryDataStore.Link()`** (inside the DAO) so its references (`Aspect`, `Type`, `Hero`, `Card`...) point to the right objects.

## Things the model does for you

- `Card.IsHeroCard`, `Card.IsHeroDeckCard`, `Card.EffectiveDeckLimit`, `Card.CostText` ("3", "X" or "—").
- `Hero.DeckCards` (the cards rule S3 adds), `Hero.DeckCardCount`, `Hero.AlterEgoName`, `Hero.IdentityCard`.
- `Deck.CardCount`, `Deck.MinCards`, `Deck.MaxCards`.
- `Card.Text` contains markup: `<b>`, `<i>`, icon tokens like `[energy]` and traits like `[[Aerial]]`. Showing it nicely is part of the work (requirements C.1).
