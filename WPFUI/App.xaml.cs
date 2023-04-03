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

        public App()
        {
            _navigationStore = new NavigationStore();
            _userStore = new UserStore();
        }


        protected override void OnStartup(StartupEventArgs e)
        {

            INavigationService<UserEntryViewModel> navigationService = GreateEntryUserNavigationService();
            navigationService.Navigate();

            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(_navigationStore)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }

        private INavigationService<MenuViewModel> GreateMainMenuNavigationService()
        {
            return new LayoutNavigationService<MenuViewModel>(_navigationStore, () => 
            new MenuViewModel(_userStore, GreateEntryUserNavigationService()), CreateNavigationViewModel);
        }
        private INavigationService<UserGreatViewModel> GreateUserNewNavigationService()
        {
            return new NavigationService<UserGreatViewModel>(_navigationStore, () =>
            new UserGreatViewModel(GreateEntryUserNavigationService()));
        }

        private INavigationService<UserEntryViewModel> GreateEntryUserNavigationService()
        {
            return new NavigationService<UserEntryViewModel>(_navigationStore, () =>
            new UserEntryViewModel(_userStore, GreateMainMenuNavigationService(), GreateUserNewNavigationService()));
        }
        private NavigationBarViewModel CreateNavigationViewModel()
        {
            return new NavigationBarViewModel(
                            GreateMainMenuNavigationService(),
                            GreateUserNewNavigationService(), 
                            GreateEntryUserNavigationService());
        }
    }
}
