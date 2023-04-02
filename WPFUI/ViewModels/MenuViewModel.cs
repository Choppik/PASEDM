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
        public ICommand NavigateMainMenuCommand { get; }
        public MenuViewModel(UserStore userStore, NavigationStore navigationStore)
        {
            _user = userStore;

            NavigateMainMenuCommand = new NavigateCommand<UserEntryViewModel>(new NavigationService<UserEntryViewModel>(navigationStore, 
                () => new UserEntryViewModel(userStore, navigationStore)));
        }
    }
}
