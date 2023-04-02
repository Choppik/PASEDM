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
            _navigationBarViewModel = new NavigationBarViewModel(GreateHomeNavigationService());
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            NavigationService<UserEntryViewModel> navigationService = GreateHomeNavigationService();
            navigationService.Navigate();

            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(_navigationStore)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }

        private NavigationService<UserEntryViewModel> GreateHomeNavigationService()
        {
            return new NavigationService<UserEntryViewModel>(_navigationStore, () => 
            new UserEntryViewModel(_navigationBarViewModel, _userStore, _navigationStore));
        }
    }
}
