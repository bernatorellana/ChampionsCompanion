using ChampionsCompanion.App.Pages;
using Wpf.Ui.Controls;

namespace ChampionsCompanion.App;

public partial class MainWindow : FluentWindow
{
    public MainWindow()
    {
        InitializeComponent();

    }

    private void FluentWindow_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
        // The card list is the default page (requirements B).
        RootNavigation.Navigate(typeof(CardsPage));

    }
}
