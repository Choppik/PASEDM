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
        public ICommand NavigateExitOfAccount { get; }
        public ICommand NavigateCreateUser { get; }
        public ICommand NavigateEntryUser { get; }
        public ICommand LogoutCommand { get; }
        public NavigationBarViewModel(UserStore userStore, INavigationService<MenuViewModel> navigationServiceMenu,
            INavigationService<UserGreatViewModel> navigationServiceNewUser,
            INavigationService<UserEntryViewModel> navigationServiceEntryUser) 
        {
            _userStore = userStore;
            NavigateExitOfAccount = new NavigateCommand<MenuViewModel>(navigationServiceMenu);
            NavigateCreateUser = new NavigateCommand<UserGreatViewModel>(navigationServiceNewUser);
            NavigateEntryUser = new NavigateCommand<UserEntryViewModel>(navigationServiceEntryUser);
            LogoutCommand = new LogoutCommand(userStore);

            _userStore.CurrentUserChanged += OnCurrentUserChanged;
        }

        private void OnCurrentUserChanged()
        {
            OnPropertyChanged(nameof(float.MinValue));
        }
        public override void Dispose()
        {
            _userStore.CurrentUserChanged -= OnCurrentUserChanged;
            base.Dispose();
        }
    }
}
