using PASEDM.Infrastructure.Command;
using PASEDM.Services;
using PASEDM.Store;
using PASEDM.ViewModels.Base;
using System.Windows.Input;

namespace PASEDM.ViewModels
{
    public class NavigationBarViewModel : BaseViewModels
    {
        private readonly UserStore _userStore;

        public bool IsLoggedId => _userStore.IsLoggedIn;
        public string Name => _userStore.CurrentUser?.UserName;
        public ICommand NavigateEntryUser { get; }
        public ICommand LogoutCommand { get; }
        public ICommand NavigateIncomingCommand { get; }
        public NavigationBarViewModel(
            UserStore userStore, 
            INavigationService navigationServiceIncoming,
            INavigationService navigationServiceEntryUser) 
        {
            _userStore = userStore;
            NavigateIncomingCommand = new NavigateCommand(navigationServiceIncoming);
            NavigateEntryUser = new NavigateCommand(navigationServiceEntryUser);
            LogoutCommand = new LogoutCommand(userStore);

            _userStore.CurrentUserChanged += OnCurrentUserChanged;
        }

        private void OnCurrentUserChanged()
        {
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(IsLoggedId));
        }
        public override void Dispose()
        {
            _userStore.CurrentUserChanged -= OnCurrentUserChanged;
            base.Dispose();
        }
    }
}