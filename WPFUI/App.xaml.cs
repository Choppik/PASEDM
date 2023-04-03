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

            INavigationService<UserEntryViewModel> navigationService = CreateEntryUserNavigationService();
            navigationService.Navigate();

            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(_navigationStore)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }

        private INavigationService<MenuViewModel> CreateMainMenuNavigationService()
        {
            return new LayoutNavigationService<MenuViewModel>(_navigationStore, () => 
            new MenuViewModel(_userStore, CreateEntryUserNavigationService()), CreateNavigationBarViewModel);
        }
        private INavigationService<UserGreatViewModel> CreateUserNewNavigationService()
        {
            return new NavigationService<UserGreatViewModel>(_navigationStore, () =>
            new UserGreatViewModel(CreateEntryUserNavigationService()));
        }

        private INavigationService<UserEntryViewModel> CreateEntryUserNavigationService()
        {
            return new NavigationService<UserEntryViewModel>(_navigationStore, () =>
            new UserEntryViewModel(_userStore, CreateMainMenuNavigationService(), CreateUserNewNavigationService()));
        }
        private NavigationBarViewModel CreateNavigationBarViewModel()
        {
            return new NavigationBarViewModel(_userStore,
                            CreateMainMenuNavigationService(),
                            CreateUserNewNavigationService(), 
                            CreateEntryUserNavigationService());
        }
    }
}
