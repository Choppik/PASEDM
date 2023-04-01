using PASEDM.Infrastructure.Command;
using PASEDM.Services;
using PASEDM.Store;
using PASEDM.ViewModels.Base;
using System.Windows.Input;

namespace PASEDM.ViewModels
{
    public class UserGreatViewModel : BaseViewModels
    {
        public ICommand NavigateEntryUserCommand { get; }
        //public ICommand NavigateMainMenuCommand { get; }
        public UserGreatViewModel (NavigationStore navigationStore)
        {
            NavigateEntryUserCommand = new NavigateCommand<UserEntryViewModel>(new NavigationService<UserEntryViewModel>(navigationStore, () => new UserEntryViewModel(navigationStore)));
            //NavigateMainMenuCommand = new NavigateCommand<MenuViewModel>(navigationStore, () => new MenuViewModel(navigationStore));
        }
    }
}
