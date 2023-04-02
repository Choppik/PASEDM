using PASEDM.Infrastructure.Command;
using PASEDM.Store;
using PASEDM.ViewModels.Base;
using System.Windows.Input;
using PASEDM.Services;
using PASEDM.Models;

namespace PASEDM.ViewModels
{
    public class MenuViewModel : BaseViewModels
    {
        private readonly UserStore _user;
        public string Name => _user.CurrentUser?.Login;
        public NavigationBarViewModel NavigationBarViewModel { get; }
        public ICommand NavigateHomeCommand { get; }
        public MenuViewModel(NavigationBarViewModel navigationBarViewModel, UserStore userStore, NavigationStore navigationStore)
        {
            NavigationBarViewModel = navigationBarViewModel;

            _user = userStore;

            NavigateHomeCommand = new NavigateCommand<UserEntryViewModel>(new NavigationService<UserEntryViewModel>(navigationStore, 
                () => new UserEntryViewModel(navigationBarViewModel, userStore, navigationStore)));
        }
    }
}
