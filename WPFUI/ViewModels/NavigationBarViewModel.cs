using PASEDM.Infrastructure.Command;
using PASEDM.Services;
using PASEDM.Store;
using PASEDM.ViewModels.Base;
using System.Windows.Input;

namespace PASEDM.ViewModels
{
    public class NavigationBarViewModel : BaseViewModels
    {
        private UserStore _userStore;
        public bool IsLoggedId => _userStore.IsLoggedIn;
        public ICommand NavigateExitOfAccount { get; }
        public ICommand NavigateCreateUser { get; }
        public ICommand NavigateEntryUser { get; }
        public ICommand LogoutCommand { get; }
        public NavigationBarViewModel(UserStore userStore, INavigationService navigationServiceMenu,
            INavigationService navigationServiceNewUser,
            INavigationService navigationServiceEntryUser) 
        {
            _userStore = userStore;
            NavigateExitOfAccount = new NavigateCommand(navigationServiceMenu);
            NavigateCreateUser = new NavigateCommand(navigationServiceNewUser);
            NavigateEntryUser = new NavigateCommand(navigationServiceEntryUser);
            LogoutCommand = new LogoutCommand(userStore);

            _userStore.CurrentUserChanged += OnCurrentUserChanged;
        }

        private void OnCurrentUserChanged()
        {
            OnPropertyChanged(nameof(IsLoggedId));
        }
        public override void Dispose()
        {
            _userStore.CurrentUserChanged -= OnCurrentUserChanged;
            base.Dispose();
        }
    }
}
