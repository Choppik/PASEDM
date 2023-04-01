using PASEDM.Infrastructure.Command;
using PASEDM.Store;
using PASEDM.ViewModels.Base;
using System.Windows.Input;
using PASEDM.Services;

namespace PASEDM.ViewModels
{
    public class MenuViewModel : BaseViewModels
    {
        public ICommand NavigateMainMenuCommand { get; }
        public MenuViewModel(NavigationStore navigationStore)
        {
            NavigateMainMenuCommand = new NavigateCommand<UserEntryViewModel>(new NavigationService<UserEntryViewModel>(navigationStore, () => new UserEntryViewModel(navigationStore)));
        }
    }
}
