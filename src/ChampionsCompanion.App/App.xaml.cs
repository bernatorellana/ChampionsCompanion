using System.Windows;

namespace ChampionsCompanion.App;

public partial class App : Application
{
    private void OnStartup(object sender, StartupEventArgs e)
    {
        // Phase 1: the data lives in memory (see AppServices and Core/Data/InMemory).
        AppServices.UseInMemoryData();

        // TODO (requirements A): show a splash screen first, while the data loads.
        var main = new MainWindow();
        MainWindow = main;
        main.Show();
    }
}
