using PASEDM.ViewModels;
using System.Windows;
using PASEDM.Store;
using PASEDM.View;
using PASEDM.Services;
using System;

namespace PASEDM
{
    public partial class App : Application
    {
        private NavigationStore _navigationStore;
        private UserStore _userStore;
        private readonly NavigationBarViewModel _navigationBarViewModel;

        public App()
        {
            _navigationStore = new NavigationStore();
            _userStore = new UserStore();
            _navigationBarViewModel = new NavigationBarViewModel(GreateMainMenuNavigationService(),
                GreateUserNewNavigationService(), GreateEntryUserNavigationService());
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            NavigationService<UserEntryViewModel> navigationService = GreateEntryUserNavigationService();
            navigationService.Navigate();

            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(_navigationStore)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }

        private NavigationService<MenuViewModel> GreateMainMenuNavigationService()
        {
            return new NavigationService<MenuViewModel>(_navigationStore, () => 
            new MenuViewModel(_navigationBarViewModel, _userStore, GreateEntryUserNavigationService()));
        }
        private NavigationService<UserGreatViewModel> GreateUserNewNavigationService()
        {
            return new NavigationService<UserGreatViewModel>(_navigationStore, () =>
            new UserGreatViewModel(GreateEntryUserNavigationService()));
        }

        private NavigationService<UserEntryViewModel> GreateEntryUserNavigationService()
        {
            return new NavigationService<UserEntryViewModel>(_navigationStore, () =>
            new UserEntryViewModel(_userStore, GreateMainMenuNavigationService(), GreateUserNewNavigationService()));
        }
    }
}
