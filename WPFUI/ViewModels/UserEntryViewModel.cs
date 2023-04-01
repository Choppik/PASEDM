using PASEDM.Infrastructure.Command;
using PASEDM.Services;
using PASEDM.Store;
using PASEDM.ViewModels.Base;
using System.Windows.Input;

namespace PASEDM.ViewModels
{
    public class UserEntryViewModel : BaseViewModels
    {
        public ICommand NavigateGreatUserCommand { get; }
        public ICommand NavigateMainMenuCommand { get; }
        public UserEntryViewModel (NavigationStore navigationStore)
        {
            NavigateGreatUserCommand = new NavigateCommand<UserGreatViewModel>(new NavigationService<UserGreatViewModel>(navigationStore, () => new UserGreatViewModel(navigationStore)));
            NavigateMainMenuCommand = new NavigateCommand<MenuViewModel>(new NavigationService<MenuViewModel>(navigationStore, () => new MenuViewModel(navigationStore)));
        }
    }
}
