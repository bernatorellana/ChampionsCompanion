using System.Windows;
using System.Windows.Controls;

namespace ChampionsCompanion.App.Pages;

/// <summary>D.1 Deck list. TODO: everything, starting with the methods of IDeckDao.</summary>
public partial class DecksPage : Page
{
    public DecksPage()
    {
        InitializeComponent();
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        // TODO: read the decks through AppServices.Decks once IDeckDao has a method for it.
        // InMemoryDataStore already holds one sample deck, "Spidey Justice".
        StatusText.Text = "Deck list: to do.";
    }
}
