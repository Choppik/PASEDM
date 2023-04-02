using PASEDM.Infrastructure.Command;
using PASEDM.Models;
using PASEDM.Services;
using PASEDM.Store;
using PASEDM.ViewModels.Base;
using System.Windows.Input;
using System.Windows.Navigation;

namespace PASEDM.ViewModels
{
    public class UserEntryViewModel : BaseViewModels
    {
        private string _login;
        private string _password;
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public ICommand NavigateGreatUserCommand { get; }
        public ICommand LoginMainMenuCommand { get; }
        public UserEntryViewModel (UserStore userStore, NavigationStore navigationStore)
        {
            NavigateGreatUserCommand = new NavigateCommand<UserGreatViewModel>(new NavigationService<UserGreatViewModel>(navigationStore, () => new UserGreatViewModel(userStore, navigationStore)));
            
            NavigationService<MenuViewModel> navigationService = new NavigationService<MenuViewModel> (
                navigationStore, () => new MenuViewModel(userStore, navigationStore));

            LoginMainMenuCommand = new LoginCommand(this, userStore, navigationService);
        }
    }
}
