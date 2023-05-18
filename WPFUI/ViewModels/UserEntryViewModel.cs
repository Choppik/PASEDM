using PASEDM.Data;
using PASEDM.Infrastructure.Command;
using PASEDM.Services;
using PASEDM.Store;
using PASEDM.ViewModels.Base;
using System.Windows.Input;

namespace PASEDM.ViewModels
{
    public class UserEntryViewModel : BaseViewModels
    {
        private string _userName;
        private string _password;

        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
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
        public UserEntryViewModel (UserStore userStore,
            INavigationService accountNavigationService,
            INavigationService createUserNavigationService,
            PASEDMDbContextFactory deferredContextFactory)
        {
            NavigateGreatUserCommand = new NavigateCommand(createUserNavigationService);
            
            LoginMainMenuCommand = new LoginCommand(this, userStore, accountNavigationService, deferredContextFactory);
        }
    }
}