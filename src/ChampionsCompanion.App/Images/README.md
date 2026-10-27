# Images

Copied next to the .exe on build (`CopyToOutputDirectory`), so they can be replaced without rebuilding.

| File | Used by | Notes |
|---|---|---|
| `Cards/<code>.png` | Card list, card editor, deck editor | One file per card code. The seed cards are included. Cards created in the app get theirs here when you choose an image. |
| `Decks/<deckId>.<ext>` | Deck list, deck editor | Created by the deck editor (*Image…*). |
| `splash_background.webp` | Splash screen | **Not included.** Add it here (`.jpg` and `.png` also work). Without it the splash is black. |
| `nebula_background.jpg` | Main window, behind the pages | **Not included.** Add it here. Without it the background is plain dark. |
