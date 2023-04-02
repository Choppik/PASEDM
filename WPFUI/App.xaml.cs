using PASEDM.ViewModels;
using System.Windows;
using PASEDM.Store;
using PASEDM.View;

namespace PASEDM
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationStore navigationStore = new();
            UserStore userStore = new UserStore();

            navigationStore.CurrentViewModel = new UserEntryViewModel(userStore, navigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(navigationStore)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
